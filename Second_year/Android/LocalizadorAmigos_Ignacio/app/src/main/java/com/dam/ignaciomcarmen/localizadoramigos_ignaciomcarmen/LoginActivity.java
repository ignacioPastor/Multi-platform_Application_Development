package com.dam.ignaciomcarmen.localizadoramigos_ignaciomcarmen;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
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

public class LoginActivity extends AppCompatActivity implements View.OnClickListener{

    Boolean loginCorrecto;
    TextView tvResultado;
    Button bLogin;
    Button bNuevaCuenta;
    EditText etUsuario;
    EditText etPassword;
    ObtenerWebService hiloconexion;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        loginCorrecto = false;

        bNuevaCuenta = (Button)findViewById(R.id.bNuevaCuenta);
        bLogin = (Button)findViewById(R.id.bLogin);
        etUsuario = (EditText)findViewById(R.id.etUsuario);
        etPassword = (EditText)findViewById(R.id.etPassword);
        tvResultado = (TextView)findViewById(R.id.tvResultado);

        bLogin.setOnClickListener(this);
        bNuevaCuenta.setOnClickListener(this);
    }

    /**
     * Navega a NavigationAmigos llevándose el JSON del usuario traído de la base de datos
     * @param userString objeto usuarioLogeado en formato string
     */
    public void goToNavigationAmigos(String userString){
        Intent intent = new Intent(this, NavigationAmigos.class);

        //Creamos la información a pasar entre actividades
        Bundle b = new Bundle();
        b.putString("USUARIO", userString);

        //Añadimos la información al intent
        intent.putExtras(b);

        //Iniciamos la nueva actividad
        startActivity(intent);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            // Si se pulsa login, llamamos a un servicio que pasa al servidor el usuario y el password
            case R.id.bLogin:
                hiloconexion = new ObtenerWebService();
                hiloconexion.execute(etUsuario.getText().toString(), etPassword.getText().toString());
                break;
            // Si se pulsa "Nueva Cuenta", pasamos a la activity Nueva Cuenta
            case R.id.bNuevaCuenta:
                Intent intent = new Intent(this, NuevaCuenta.class);
                //Iniciamos la nueva actividad
                startActivity(intent);
                break;
            default:
                break;
        }
    }

    /**
     *  Gestiona una servicio Post con nuestro servidor
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
                loginCorrecto = true;
                String line;
                BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                while ((line=br.readLine()) != null) {
                    response+=line;
                }
            }
            else {
                loginCorrecto = false;
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
            result.append(URLEncoder.encode(entry.getValue(), "UTF-8"));
        }
        return result.toString();
    }

    /**
     * Hilo que conforma el servicio que utilizaremos para comunicarnos con el servidor
     * Envía el usuario y su contraseña, y si es correcto iremos a la activity NavigationAmigos
     * En caso de que el usuario o la contraseña no sean correctos, informamos del error
     */
    public class ObtenerWebService extends AsyncTask<String, Integer, String> {
        @Override
        protected String doInBackground(String... params) {
            HashMap<String, String> myParams = new HashMap<>();
            myParams.put("email", params[0]);
            myParams.put("password", params[1]);
            return performPostCall("http://217.182.205.94/api/authIgnacio", myParams);
        }

        @Override protected void onCancelled(String aVoid) {
            super.onCancelled(aVoid);
        }

        @Override
        protected void onPostExecute(String aVoid) {
            if(loginCorrecto){   // checkeamos que se ha logeado bien y conseguimos la última localización almacenada en la BD
                tvResultado.setText("Logeado correctamente");
                goToNavigationAmigos(aVoid);
            }else{
                tvResultado.setText(aVoid);
            }
        }

        @Override
        protected void onPreExecute() {
            tvResultado.setText("");
            super.onPreExecute();
        }

        @Override protected void onProgressUpdate(Integer... values) {
            super.onProgressUpdate(values);
        }
    }// end ObtenerWebService
}