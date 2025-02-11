package com.example.googlemapsapp;

import android.content.Intent;
import android.graphics.Color;
import android.view.View;
import android.widget.Button;
import androidx.fragment.app.FragmentActivity;
import android.os.Bundle;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.CircleOptions;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.example.googlemapsapp.databinding.ActivityGoogleMapsBinding;

public class GoogleMapsActivity extends FragmentActivity implements OnMapReadyCallback {

    private GoogleMap mMap;
    private float zoomvar = 10;

    private final LatLng SofiaCenter = new LatLng(42.6977082, 23.3218675);
    private final LatLng TUsofia = new LatLng(42.6570607, 23.3551086);


    private final LatLng SofiaLibrary = new LatLng(42.696897, 23.325877);
    private final LatLng SofiaUniversity = new LatLng(42.693978, 23.334181);
    private final LatLng IvanVazovTheater = new LatLng(42.694978, 23.324604);


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_google_maps);

        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);

        if (mapFragment != null) {
            mapFragment.getMapAsync(this);
        }
    }

    /**
     * Manipulates the map once available.
     * This callback is triggered when the map is ready to be used.
     * This is where we can add markers or lines, add listeners or move the camera. In this case,
     * we just add a marker near Sydney, Australia.
     * If Google Play services is not installed on the device, the user will be prompted to install
     * it inside the SupportMapFragment. This method will only be triggered once the user has
     * installed Google Play services and returned to the app.
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;

        // Add markers
        mMap.addMarker(new MarkerOptions().position(SofiaCenter).title("Marker in Sofia Center"));
        mMap.addMarker(new MarkerOptions().position(TUsofia).title("Marker at TU Sofia"));


        mMap.addMarker(new MarkerOptions().position(SofiaLibrary).title("Sofia Library"));
        mMap.addMarker(new MarkerOptions().position(SofiaUniversity).title("Sofia University"));
        mMap.addMarker(new MarkerOptions().position(IvanVazovTheater).title("Ivan Vazov Theater"));

        // Move camera to Sofia Center
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(SofiaCenter, 10));

        // Buttons
        Button plusZOOM = findViewById(R.id.zoomIN);
        Button minusZOOM = findViewById(R.id.zoomOUT);
        Button hybrid = findViewById(R.id.hybridBUT);
        Button normal = findViewById(R.id.normalBUT);
        Button satellite = findViewById(R.id.satelliteBUT);
        Button terrain = findViewById(R.id.terrainBUT);
        Button tus = findViewById(R.id.tusBUT);
        Button back = findViewById(R.id.BACK);

        Button capitalLibraryBut = findViewById(R.id.capitalLibraryBut);
        Button sofiaUniversityBut = findViewById(R.id.sofiaUniversityBut);
        Button theaterBut = findViewById(R.id.theaterBut);

        CircleOptions circleOptions = new CircleOptions()
                .center(TUsofia)
                .radius(25)
                .fillColor(Color.BLUE)
                .strokeColor(Color.RED)
                .strokeWidth(4);

        mMap.addCircle(circleOptions);

        // Zoom In
        plusZOOM.setOnClickListener(v -> {
            zoomvar = Math.min(21, zoomvar + 1); // Ensure zoom doesn't exceed 21
            mMap.animateCamera(CameraUpdateFactory.zoomTo(zoomvar));
        });

        // Zoom Out
        minusZOOM.setOnClickListener(v -> {
            zoomvar = Math.max(2, zoomvar - 1); // Ensure zoom doesn't go below 2
            mMap.animateCamera(CameraUpdateFactory.zoomTo(zoomvar));
        });

        // Switch to Hybrid View
        hybrid.setOnClickListener(v -> mMap.setMapType(GoogleMap.MAP_TYPE_HYBRID));

        // Switch to Normal View
        normal.setOnClickListener(v -> mMap.setMapType(GoogleMap.MAP_TYPE_NORMAL));

        // Switch to Satellite View
        satellite.setOnClickListener(v -> mMap.setMapType(GoogleMap.MAP_TYPE_SATELLITE));

        // Switch to Terrain View
        terrain.setOnClickListener(v -> mMap.setMapType(GoogleMap.MAP_TYPE_TERRAIN));

        // Move to TU Sofia
        tus.setOnClickListener(v -> mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(TUsofia, 15)));

        //Move to Libary
        capitalLibraryBut.setOnClickListener(v -> mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(SofiaLibrary, 15)));
        sofiaUniversityBut.setOnClickListener(v -> mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(SofiaUniversity, 15)));
        theaterBut.setOnClickListener(v -> mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(IvanVazovTheater, 15)));

        // Back Button
        back.setOnClickListener(v -> {
            Intent intent = new Intent(GoogleMapsActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });
    }
}
