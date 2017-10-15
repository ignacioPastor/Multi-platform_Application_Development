package com.dam.ignaciomcarmen.localizadoramigos_ignaciomcarmen;

import android.content.Context;
import android.app.Fragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.Toast;

import static com.dam.ignaciomcarmen.localizadoramigos_ignaciomcarmen.R.id.bLogin;

/**
 * A placeholder fragment containing a simple view.
 */
public class LoginActivityFragment extends Fragment{


    public LoginActivityFragment() {
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_login, container, false);
    }




}
