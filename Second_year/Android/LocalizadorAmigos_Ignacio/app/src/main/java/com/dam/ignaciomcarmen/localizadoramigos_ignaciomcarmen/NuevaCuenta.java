package com.dam.ignaciomcarmen.localizadoramigos_ignaciomcarmen;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.HashMap;
import java.util.Map;
import javax.net.ssl.HttpsURLConnection;

/**
 * Clase que gestiona la creación de una nueva cuenta de usuario para la aplicación
 */
public class NuevaCuenta extends AppCompatActivity implements View.OnClickListener {

    static final int MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION = 1;
    static final int MY_PERMISSIONS_REQUEST_SMS_READ = 2;

    InsertarNuevoUsuario hiloconexion;

    Button bCrearNuevaCuenta;
    EditText etNuevoNombre;
    EditText etNuevoMail;
    EditText etNuevoPassword;
    EditText etTelefono;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nueva_cuenta);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        ActivityCompat.requestPermissions(this,
                new String[]{Manifest.permission.READ_SMS},
                MY_PERMISSIONS_REQUEST_SMS_READ);

        bCrearNuevaCuenta = (Button)findViewById(R.id.bCrearNuevaCuenta);
        etNuevoNombre = (EditText)findViewById(R.id.etNuevoNombre);
        etNuevoMail = (EditText)findViewById(R.id.etNuevoMail);
        etNuevoPassword = (EditText)findViewById(R.id.etNuevoPassword);
        etTelefono = (EditText)findViewById(R.id.etTelefono);

        // En algunos dispositivos no es posible recuperar el número de la tarjeta SIM, así que
        // hemos optado por intentar recuperar el número y ponerlo directamente en el campo para
        // el número. Así el usuario solo tiene que rellenarlo si no se ha podido recuperar.
        etTelefono.setText(getPhoneNumber());

        bCrearNuevaCuenta.setOnClickListener(this);
    } // end onCreate

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.bCrearNuevaCuenta:
                String mPhoneNumber = "indefinido";
                mPhoneNumber = etTelefono.getText().toString();
                hiloconexion = new InsertarNuevoUsuario();
                hiloconexion.execute(etNuevoNombre.getText().toString(), etNuevoMail.getText().toString(),
                        etNuevoPassword.getText().toString(), mPhoneNumber, "", "");
                break;
            default:
                break;
        }
    }

    /**
     * Función que devuelve el número de teléfono del dispositivo
     * @return número de teléfono del dispositivo
     */
    private String getPhoneNumber(){
        TelephonyManager mTelephonyManager;
        mTelephonyManager = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
        String miNumero = mTelephonyManager.getLine1Number();

        return miNumero;
        //return mTelephonyManager.getLine1Number();
    }

    /**
     * Gestiona la inserción en la Base de Datos de un nuevo usuario en un hilo distinto del principal
     */
    public class InsertarNuevoUsuario extends AsyncTask<String, Integer, String> {

        @Override
        protected String doInBackground(String... params) {

            HashMap<String, String> myParams = new HashMap<>();
            myParams.put("name", params[0]);
            myParams.put("email", params[1]);
            myParams.put("password", params[2]);
            myParams.put("telefono", params[3]);
            myParams.put("latitud", params[4]);
            myParams.put("longitud", params[5]);

            return performPostCall("http://217.182.205.94/api/authIgnacio/insert", myParams);
        }

        @Override protected void onCancelled(String aVoid) {
            super.onCancelled(aVoid);
        }

        @Override
        protected void onPostExecute(String aVoid) {
            Intent intent = new Intent(getApplicationContext(), NavigationAmigos.class);
            Bundle b = new Bundle();
            b.putString("USUARIO", aVoid);
            intent.putExtras(b);
            startActivity(intent);
        }

        @Override protected void onPreExecute() { super.onPreExecute(); }

        @Override protected void onProgressUpdate(Integer... values) { super.onProgressUpdate(values); }
    }// end ActualizarUsuarioServicio

    /**
     * Prepara el servicio mediante llamada post
     * @param requestURL , url a la que conectarse
     * @param postDataParams , conjunto de clave - valor para configurar el JSON que enviaremos por post al servidor
     * @return  string con el resultado de la llamada
     * http://stackoverflow.com/questions/9767952/how-to-add-parameters-to-httpurlconnection-using-post
     */
    public String performPostCall(String requestURL, HashMap<String, String> postDataParams) {
        URL url;
        String response = "";
        try {
            url = new URL(requestURL);

            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setReadTimeout(15000);
            conn.setConnectTimeout(15000);
            conn.setRequestMethod("POST");
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
            if (responseCode == HttpsURLConnection.HTTP_OK) {
                String line;
                BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                while ((line=br.readLine()) != null) {
                    response+=line;
                }
            }
            else {
                String lineError;
                BufferedReader brError = new BufferedReader(new InputStreamReader(conn.getErrorStream()));
                while ((lineError=brError.readLine()) != null) {
                    response+=lineError;
                }
            }
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
    private String getPostDataString(HashMap<String, String> params) throws UnsupportedEncodingException {
        StringBuilder result = new StringBuilder();
        boolean first = true;
        for(Map.Entry<String, String> entry : params.entrySet()){
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
                } else {
                }
                return;
            }
            case MY_PERMISSIONS_REQUEST_SMS_READ: {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                } else {
                }
                return;
            }
        }
    }
}
