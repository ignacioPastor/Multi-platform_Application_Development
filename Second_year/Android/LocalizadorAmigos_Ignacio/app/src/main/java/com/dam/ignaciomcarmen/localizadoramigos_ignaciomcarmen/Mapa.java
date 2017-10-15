package com.dam.ignaciomcarmen.localizadoramigos_ignaciomcarmen;

import android.Manifest;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.provider.ContactsContract;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

import static android.Manifest.permission.ACCESS_FINE_LOCATION;

public class Mapa extends FragmentActivity implements OnMapReadyCallback {
    static final int MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION = 1;

    JSONObject usuarioLogeado;
    JSONArray amigos;
    List<String> numerosAgenda;

    ObtenerWebServicePosicion hiloconexion;
    ActualizarUsuarioServicio hiloActualizarUsuario;
    GetUsuarios hiloGetUsuarios;

    LocationManager locationManager;
    LocationListener locationListener;
    AlertDialog alert = null;
    Location location;

    private GoogleMap mMap;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mapa);
        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);

        //------------------------------------------------------------------------

        ActivityCompat.requestPermissions(this,
                new String[]{Manifest.permission.ACCESS_FINE_LOCATION,
                        Manifest.permission.READ_CONTACTS,
                        Manifest.permission.WRITE_CONTACTS},1);

        // Recuperamos el usuario que se ha logeado y nos hemos traído por un bundle
        Bundle b = this.getIntent().getExtras();
        try {
            usuarioLogeado = new JSONObject(b.getString("USUARIO"));
        } catch (JSONException e) {
            e.printStackTrace();
        }

        // Recuperamos la ultima localizacion del usuario y actualizamos la que nos viene de la base de datos
        locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        /****Mejora****/
        if (!locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
            AlertNoGps();
        } else {
        }
        getMyLastLocation();
        MostrarLocalizacion(location);
        ObtenerDatos(); // llama en postExecute a Obtener usuarios de la BD

        locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(Location location) {
                Log.d("test6", "aaaaaaaaaaaaaaaaaaaaa");
                MostrarLocalizacion(location);
                actualizarUsuario();
            }
            @Override public void onStatusChanged(String provider, int status, Bundle extras) { }
            @Override public void onProviderEnabled(String provider) { }
            @Override public void onProviderDisabled(String provider) { }
        };

        if (ActivityCompat.checkSelfPermission(this, ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, locationListener);

    }   // endOncreate

    /**
     * Manipulates the map once available.
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;
        marcarUsuario(usuarioLogeado, "rojo", true);
    }

    /**
     * Muestra al usuario en el mapa con el color que le indicamos
     * @param usuario
     */
    public void marcarUsuario(JSONObject usuario, String color, Boolean moveCamera){

        double myLatitud = 0;
        double myLongitud = 0;
        String nombre = "Usuario";

        try {
            myLatitud = Double.parseDouble(usuario.getString("latitud"));
            myLongitud = Double.parseDouble(usuario.getString("longitud"));
            nombre = usuario.getString("name");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        if(color.equals("rojo")){
            mMap.addMarker(new MarkerOptions().position(new LatLng(myLatitud, myLongitud)).title(nombre));
        }else if(color.equals("azul")){
            mMap.addMarker(new MarkerOptions().position(new LatLng(myLatitud, myLongitud)).title(nombre)
                .icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_AZURE)));
        }

        if(moveCamera){
            mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(new LatLng(myLatitud, myLongitud),15));
        }
    }

    /**
     * Recorre el array de amigos y los va mostrando en el mapa con un marcador azúl
     */
    public void mostrarAmigosEnMapa(){
        for(int i=0; i<amigos.length();i++){
            try {
                marcarUsuario(new JSONObject(amigos.get(i).toString()), "azul", false);
            } catch (JSONException e) { e.printStackTrace(); }
        }
    }

    /**
     * Obtiene información de dónde está el usuario usando la longitud y latitud leída, y llamando a la api de google
     * @param loc
     */
    public void MostrarLocalizacion(Location loc){
        if (loc != null){
            hiloconexion = new ObtenerWebServicePosicion();
            hiloconexion.execute(String.valueOf(loc.getLatitude()),String.valueOf(loc.getLongitude()));
        }
    }

    /**
     * Obtiene la última localizacion del usuario
     */
    public void getMyLastLocation() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            if (checkSelfPermission(ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
                    && checkSelfPermission(Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
                return;
            } else {
                location = locationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);
            }
        } else {
            location = locationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);
        }
        try {
            usuarioLogeado.put("longitud", String.valueOf(location.getLongitude()));
            usuarioLogeado.put("latitud", String.valueOf(location.getLatitude()));
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }

    /**
     * Actualiza en la base de datos los datos del usuario logeado
     */
    public void actualizarUsuario(){
        HashMap<String, JSONObject> myParams = new HashMap<>();
        myParams.put("user", usuarioLogeado);
        hiloActualizarUsuario = new ActualizarUsuarioServicio();
        hiloActualizarUsuario.execute();
    }

    /**
     * Servicio para actualizar los datos del usuario en la Base de Datos
     */
    public class ActualizarUsuarioServicio extends AsyncTask<String, Integer, String> {
        @Override
        protected String doInBackground(String... params) {
            HashMap<String, JSONObject> myParams = new HashMap<>();
            myParams.put("user", usuarioLogeado);
            return performPatchCall("http://217.182.205.94/api/authIgnacio", myParams);
        }
        @Override
        protected void onCancelled(String aVoid) {
            super.onCancelled(aVoid);
        }
        @Override protected void onPostExecute(String aVoid) { }
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }
        @Override
        protected void onProgressUpdate(Integer... values) {
            super.onProgressUpdate(values);
        }
    }// end ActualizarUsuarioServicio

    /**
     * Obtiene información de la posición del usuario
     */
    public class ObtenerWebServicePosicion extends AsyncTask<String, Integer, String> {

        @Override
        protected String doInBackground(String... params) {
            String cadena = "http://maps.googleapis.com/maps/api/geocode/json?latlng=";
            cadena = cadena + params[0];
            cadena = cadena + ",";
            cadena = cadena + params[1];
            cadena = cadena + "&sensor=false";
            String devuelve = "";
            URL url = null; // Url de donde queremos obtener información
            try {
                url = new URL(cadena);
                HttpURLConnection connection = (HttpURLConnection) url.openConnection(); //Abrir la conexión
                connection.setRequestProperty("User-Agent", "Mozilla/5.0" +
                        " (Linux; Android 1.5; es-ES) Ejemplo HTTP");
                int respuesta = connection.getResponseCode();
                StringBuilder result = new StringBuilder();
                if (respuesta == HttpURLConnection.HTTP_OK){
                    InputStream in = new BufferedInputStream(connection.getInputStream());  // preparo la cadena de entrada
                    BufferedReader reader = new BufferedReader(new InputStreamReader(in));  // la introduzco en un BufferedReader
                    // El siguiente proceso lo hago porque el JSONOBject necesita un String y tengo
                    // que tranformar el BufferedReader a String. Esto lo hago a traves de un
                    // StringBuilder.
                    String line;
                    while ((line = reader.readLine()) != null) {
                        result.append(line);        // Paso toda la entrada al StringBuilder
                    }
                    //Creamos un objeto JSONObject para poder acceder a los atributos (campos) del objeto.
                    JSONObject respuestaJSON = new JSONObject(result.toString());   //Creo un JSONObject a partir del StringBuilder pasado a cadena
                    //Accedemos al vector de resultados
                    JSONArray resultJSON = respuestaJSON.getJSONArray("results");   // results es el nombre del campo en el JSON

                    //Vamos obteniendo todos los campos que nos interesen.
                    //En este caso obtenemos la primera dirección de los resultados.
                    String direccion="SIN DATOS PARA ESA LONGITUD Y LATITUD";
                    if (resultJSON.length()>0){
                        direccion = resultJSON.getJSONObject(0).getString("formatted_address");    // dentro del results pasamos a Objeto la seccion formated_address
                    }
                    devuelve = "Dirección: " + direccion;   // variable de salida que mandaré al onPostExecute para que actualice la UI
                }
            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            } catch (JSONException e) {
                e.printStackTrace();
            }
            return devuelve;
        }
        @Override
        protected void onCancelled(String aVoid) {
            super.onCancelled(aVoid);
        }
        @Override
        protected void onPostExecute(String aVoid) {
            marcarUsuario(usuarioLogeado, "rojo", false);
        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }
        @Override
        protected void onProgressUpdate(Integer... values) {
            super.onProgressUpdate(values);
        }
    }// end ObtenerWebServicePosicion

    /**
     * Obtiene los números de los contactos del dispositivo
     * Llama el hilo para obtener los usuarios de la BD
     */
    public void ObtenerDatos(){
        String[] projeccion = new String[] { ContactsContract.Data._ID, ContactsContract.Data.DISPLAY_NAME, ContactsContract.CommonDataKinds.Phone.NUMBER, ContactsContract.CommonDataKinds.Phone.TYPE };

        String selectionClause = ContactsContract.Data.MIMETYPE + "='" +
                ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE + "' AND "
                + ContactsContract.CommonDataKinds.Phone.NUMBER + " IS NOT NULL";
        String sortOrder = ContactsContract.Data.DISPLAY_NAME + " ASC";
        Cursor c = getContentResolver().query(
                ContactsContract.Data.CONTENT_URI,
                projeccion,
                selectionClause,
                null,
                sortOrder);
        numerosAgenda = new ArrayList<>();
        String myTexto = "";
        String n = "";
        String tmp = "";
        while(c.moveToNext()){
            n = c.getString(2);
            n = n.replace("-", "");     // Quitamos los guiones de los números (ej: 111-111)
            n = n.replace(" ", "");     // Quitamos los espacios de los números (ej: 111 111)
            n = n.contains("+") ? n.substring(3,n.length()) : n;     // Quitamos los prefijos
            // Quitamos los numeros duplicados
            if(!n.equals(tmp))
                numerosAgenda.add(n);
            tmp = n;
        }
        c.close();
        hiloGetUsuarios = new GetUsuarios();
        hiloGetUsuarios.execute();
    }

    // Obtiene todos los usuarios de la base de datos
    public class GetUsuarios extends AsyncTask<Object, Object, JSONArray> {
        @Override
        protected JSONArray doInBackground(Object... params) {
            String devuelve = "";
            JSONArray usuarios = new JSONArray();
            URL url = null; // Url de donde queremos obtener información
            try {
                url = new URL("http://217.182.205.94/api/authIgnacio/getAll");
                HttpURLConnection connection = (HttpURLConnection) url.openConnection(); //Abrir la conexión
                connection.setRequestProperty("User-Agent", "Mozilla/5.0" +
                        " (Linux; Android 1.5; es-ES) Ejemplo HTTP");
                int respuesta = connection.getResponseCode();
                StringBuilder result = new StringBuilder();
                if (respuesta == HttpURLConnection.HTTP_OK){
                    InputStream in = new BufferedInputStream(connection.getInputStream());  // preparo la cadena de entrada
                    BufferedReader reader = new BufferedReader(new InputStreamReader(in));  // la introduzco en un BufferedReader

                    String line;
                    while ((line = reader.readLine()) != null) {
                        result.append(line);        // Paso toda la entrada al StringBuilder
                    }
                    usuarios = new JSONArray(result.toString());
                }
            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            } catch (JSONException e) {
                e.printStackTrace();
            }
            return usuarios;
        }

        @Override protected void onPostExecute(JSONArray aVoid) {
            filtarAmigos(aVoid);
        }
        @Override
        protected void onCancelled(JSONArray aVoid) {
            super.onCancelled(aVoid);
        }
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }
        @Override
        protected void onProgressUpdate(Object... values) {
            super.onProgressUpdate(values);
        }
    }// end GetUsuarios

    /**
     * Filtra nuestros amigos. Mira todos los usuarios de la BD, y saca las coincidencias con nuestra lista de contactos
     * @param usuariosBD
     */
    public void filtarAmigos(JSONArray usuariosBD) {
        amigos = new JSONArray();

        for(int i=0; i<usuariosBD.length(); i++){
            try {
                if(numerosAgenda.contains(usuariosBD.getJSONObject(i).get("telefono"))){
                    amigos.put(usuariosBD.getJSONObject(i));
                }
            } catch (JSONException e) { e.printStackTrace();}
        }
        mostrarAmigosEnMapa();
    }

    /**
     *  Configura una llamada por patch al servidor
     * @param requestURL , url a la que conectarse
     * @param postDataParams , conjunto de clave - valor para configurar el JSON que enviaremos por post al servidor
     * @return  string con el resultado de la llamada
     * http://stackoverflow.com/questions/9767952/how-to-add-parameters-to-httpurlconnection-using-post
     */
    public String performPatchCall(String requestURL, HashMap<String, JSONObject> postDataParams) {
        URL url;
        String response = "";
        try {
            url = new URL(requestURL);

            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setReadTimeout(15000);
            conn.setConnectTimeout(15000);
            conn.setRequestMethod("PATCH");
            conn.setDoInput(true);
            conn.setDoOutput(true);

            OutputStream os = conn.getOutputStream();
            BufferedWriter writer = new BufferedWriter(
                    new OutputStreamWriter(os, "UTF-8"));
            writer.write(getPostDataString(postDataParams));

            writer.flush();
            writer.close();
            os.close();
            int responseCode=conn.getResponseCode();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return response;
    }

    /**
     * Prepara los parámetros de un hashMap para utilizarlos en una llamada (como si fuera un JSON)
     * @param params HashMap con los parametros a pasar en el post
     * @return  los parámetros configurados para la llamada por post
     * @throws UnsupportedEncodingException
     */
    private String getPostDataString(HashMap<String, JSONObject> params) throws UnsupportedEncodingException {
        StringBuilder result = new StringBuilder();
        boolean first = true;
        for(Map.Entry<String, JSONObject> entry : params.entrySet()){
            if (first)
                first = false;
            else
                result.append("&");

            result.append(URLEncoder.encode(entry.getKey(), "UTF-8"));
            result.append("=");
            result.append(URLEncoder.encode(entry.getValue().toString(), "UTF-8"));
        }
        return result.toString();
    }

    // Alerta y solicitud de permisos   -------------------------------------------------------------

    /**
     * Pide permisos en tiempo de ejecución al usuario
     * http://android-er.blogspot.ie/2016/04/requesting-permissions-of.html
     * @param requestCode
     * @param permissions
     * @param grantResults
     */
    @Override
    public void onRequestPermissionsResult(
            int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {

        switch (requestCode) {
            case MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION: {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    //Toast.makeText(this, "permission was granted, :)", Toast.LENGTH_LONG).show();
                } else {
                    //Toast.makeText(this, "permission denied, ...:(", Toast.LENGTH_LONG).show();
                }
                return;
            }
        }
    }

    private void AlertNoGps() {
        final AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("El sistema GPS esta desactivado, ¿Desea activarlo?")
                .setCancelable(false)
                .setPositiveButton("Si", new DialogInterface.OnClickListener() {
                    public void onClick(@SuppressWarnings("unused") final DialogInterface dialog, @SuppressWarnings("unused") final int id) {
                        startActivity(new Intent(android.provider.Settings.ACTION_LOCATION_SOURCE_SETTINGS));
                    }
                })
                .setNegativeButton("No", new DialogInterface.OnClickListener() {
                    public void onClick(final DialogInterface dialog, @SuppressWarnings("unused") final int id) {
                        dialog.cancel();
                    }
                });
        alert = builder.create();
        alert.show();
    }

    // Funciones ciclo de vida  ------------------------------------------------------------------------

    @Override
    protected void onDestroy(){
        super.onDestroy();
        if(alert != null)
        {
            alert.dismiss ();
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            if (checkSelfPermission(ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && checkSelfPermission(Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
                Toast.makeText(this, "Acceso al GPS denegado", Toast.LENGTH_LONG).show();
                return;
            } else {
                locationManager.removeUpdates(locationListener);
            }
        } else {
            locationManager.removeUpdates(locationListener);
        }
    }

    @Override
    protected void onStart() {
        Log.d("test3", "onStart");
        super.onStart();
    }

    @Override
    protected void onResume() {
        Log.d("test3", "onResume");
        super.onResume();
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            if (checkSelfPermission(ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && checkSelfPermission(Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
                Toast.makeText(this, "Acceso al GPS denegado", Toast.LENGTH_LONG).show();
                return;
            } else {
                locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, locationListener);
            }
        } else {
            locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, locationListener);
        }
    }

}
