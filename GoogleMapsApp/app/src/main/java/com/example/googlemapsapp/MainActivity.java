package com.example.googlemapsapp;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import androidx.appcompat.app.AppCompatActivity;


public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button mapBtn = findViewById(R.id.mapButton);
        Button poiBtn = findViewById(R.id.poiButton);
        Button locationBtn = findViewById(R.id.locationButton);


        mapBtn.setOnClickListener(v ->
                startActivity(new Intent(MainActivity.this, GoogleMapsActivity.class)));

        poiBtn.setOnClickListener(v ->
                startActivity(new Intent(MainActivity.this, PoiActivity.class)));

        locationBtn.setOnClickListener(v ->
                startActivity(new Intent(MainActivity.this, LocationActivity.class)));
    }
}