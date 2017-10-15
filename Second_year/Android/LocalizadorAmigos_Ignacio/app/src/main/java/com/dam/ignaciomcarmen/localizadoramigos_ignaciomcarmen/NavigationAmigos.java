package com.dam.ignaciomcarmen.localizadoramigos_ignaciomcarmen;

import android.content.Intent;
import android.content.SharedPreferences;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;
import org.json.JSONException;
import org.json.JSONObject;

public class NavigationAmigos extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {

    JSONObject usuarioLogeado;
    TextView textoBienvenida;
    Boolean sonido;
    Boolean sonidoYaActivo;
    String cancion;
    String cancionPrevia;
    Boolean cambioCancion;
    MediaPlayer mediaPlayer;
    SharedPreferences pref;
    Boolean primeraEntrada;
    TextView tvMenuNav;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_navigation_amigos);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        //------------------------------------------------------------------------
        primeraEntrada = true;
        Bundle b = this.getIntent().getExtras();
        textoBienvenida = (TextView)findViewById(R.id.textoBienvenida);
        tvMenuNav = (TextView)findViewById(R.id.tvMenuNav);
        try {
            usuarioLogeado = new JSONObject(b.getString("USUARIO"));
        } catch (JSONException e) {
            e.printStackTrace();
        }
        mediaPlayer = new MediaPlayer();
        this.setVolumeControlStream(AudioManager.STREAM_MUSIC);
        sonidoYaActivo = false; // Con este booleano evitaremos que relanzar el hilo cuando ya esté activo el sonido
        recuperarPreferencias();

    }// end onCreate

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.navigation_amigos, menu);
        return true;
    }

    /**
     * Toolbar, cuando pulsas los tres puntos de arriba a la derecha
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            //goToMapa(usuarioLogeado.toString());
        }
        return super.onOptionsItemSelected(item);
    }
    /**
     * Navega a NavigationAmigos llevándose el JSON del usuario traído de la base de datos
     * @param userString usuarioLogeado en string
     */
    public void goToMapa(String userString){
        Intent intent = new Intent(this, Mapa.class);
        Bundle b = new Bundle();
        b.putString("USUARIO", userString);
        intent.putExtras(b);
        startActivity(intent);
    }

    /**
     * El navigationMenu de la izquierda
     * @param item
     * @return
     */
    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        int id = item.getItemId();
        if (id == R.id.ver_amigos) {
            goToMapa(usuarioLogeado.toString());
        } else if (id == R.id.editar_preferencias) {
            startActivity(new Intent(this, Preferencias.class));
        }
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    /**
     * Recupera las preferencias del fichero alojado en nuestro dispositivo
     */
    private void recuperarPreferencias(){
        pref = PreferenceManager.getDefaultSharedPreferences(this);
        try {
            // Si el usuario tiene un alias en las preferencias lo recogemos, si no, le asignamos su nombre como alias
            usuarioLogeado.put("alias", pref.getString("opcionAlias", usuarioLogeado.getString("name")));
            sonido = pref.getBoolean("opcionSonido", false);
            cancion = pref.getString("cancion", "PVS");
            if(cancionPrevia == null) {
                cancionPrevia = cancion;
            }
            else if(cancionPrevia != cancion){
                cambioCancion = true;
            }else{
                cambioCancion = false;
            }
            cancionPrevia = cancion;
            textoBienvenida.setText("Bienvenido " + usuarioLogeado.get("alias"));
        } catch (JSONException e) {
            e.printStackTrace();
        }
        gestionarSonido();
    }

    /**
     * Gestiona el inicio y pausa del sonido, así como la canción que va a reproducirse
     * Para el mediaPlayer probamos primero a lanzarlo desde un hilo como haces en los vídeos, pero daba error,
     * cuando probamos sin los hilos funcionaba bien
     */
    private void gestionarSonido(){
        // Si se quiere sonido, y todavía la canción no está sonando, la lanzamos
        if(sonido && !sonidoYaActivo){
            sonidoYaActivo = true;
            if(cancion.equals("PVS")){
                mediaPlayer = MediaPlayer.create(NavigationAmigos.this, R.raw.por_verte_sonreir);
            }
            else if(cancion.equals("BTL")){
                mediaPlayer = MediaPlayer.create(NavigationAmigos.this, R.raw.born_to_lose);
            }
            else if(cancion.equals("TVB")){
                mediaPlayer = MediaPlayer.create(NavigationAmigos.this, R.raw.tendrias_que_haberla_visto_bailar);
            }
            mediaPlayer.start();
        }else if(!sonido && sonidoYaActivo){    // Si no se quiere sonido, y la canción está sonando, la paramos
            sonidoYaActivo = false;
            mediaPlayer.stop();
        }
    }

    /**
     * Cada vez que la activity se activa pasa por aquí, aprovechamos para recuperar las preferencias y gestionar el sonido
     */
    @Override
    protected void onResume() {
        super.onResume();
        // Si recuperamos las preferencias y gestionamos el sonido aquí cuando se crea la activity daba error,
        // con este booleano e if, solucionamos el problema
        if(primeraEntrada){
            primeraEntrada = false;
        }
        else{
            recuperarPreferencias();
            gestionarSonido();
        }
    }

    /**
     * Cuando la activity pierde el foco pasa por aquí, aprovechamos para parar la canción
     */
    @Override
    protected void onPause() {
        super.onPause();
        mediaPlayer.stop();
        sonidoYaActivo = false;
    }
}
