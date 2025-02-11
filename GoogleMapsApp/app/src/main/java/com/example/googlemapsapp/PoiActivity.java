package com.example.googlemapsapp;

import android.content.Intent;
import android.graphics.Color;
import android.util.Log;
import android.widget.Button;
import androidx.fragment.app.FragmentActivity;
import android.os.Bundle;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.*;

public class PoiActivity extends FragmentActivity implements OnMapReadyCallback {

    private GoogleMap mMap;

    private final LatLng TUsofia = new LatLng(42.6570607, 23.3551086);
    private final LatLng unss = new LatLng(42.651266, 23.3466593);
    private final LatLng lty = new LatLng(42.6537179, 23.3564474);
    private final LatLng nsa = new LatLng(42.6484442, 23.3466905);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_poi);

        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.location_map);

        if (mapFragment == null) {
            Log.e("PoiActivity", "SupportMapFragment is NULL!");
        } else {
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
        Log.i("PoiActivity", "onMapReady() TRIGGERED");
        mMap = googleMap;

        // Add markers for points of interest
        addMarker(TUsofia, "TU Sofia", BitmapDescriptorFactory.HUE_BLUE);
        addMarker(unss, "UNSS", BitmapDescriptorFactory.HUE_RED);
        addMarker(lty, "LTY", BitmapDescriptorFactory.HUE_YELLOW);
        addMarker(nsa, "HCA", BitmapDescriptorFactory.HUE_GREEN);

        // Move camera to TU Sofia
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(TUsofia, 14));

        // Buttons
        Button tusofiaB = findViewById(R.id.tusofia);
        Button unssB = findViewById(R.id.unss);
        Button ltyB = findViewById(R.id.lty);
        Button nsaB = findViewById(R.id.nsa);
        Button line = findViewById(R.id.line);
        Button polygon = findViewById(R.id.polygon);
        Button back = findViewById(R.id.BACK);

        if (tusofiaB == null || unssB == null || ltyB == null || nsaB == null || line == null || polygon == null || back == null) {
            throw new NullPointerException("One or more buttons are NULL. Check XML IDs.");
        }

        // Event handlers
        tusofiaB.setOnClickListener(v -> moveCamera(TUsofia));
        unssB.setOnClickListener(v -> moveCamera(unss));
        ltyB.setOnClickListener(v -> moveCamera(lty));
        nsaB.setOnClickListener(v -> moveCamera(nsa));

        // Draw line between TU Sofia and UNSS
        line.setOnClickListener(v -> drawLine(TUsofia, unss));

        // Draw polygon connecting all locations
        polygon.setOnClickListener(v -> drawPolygon());

        // Back button
        back.setOnClickListener(v -> {
            Intent intent = new Intent(PoiActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });
    }

    private void addMarker(LatLng location, String title, float color) {
        MarkerOptions markerOptions = new MarkerOptions()
                .position(location)
                .title(title)
                .icon(BitmapDescriptorFactory.defaultMarker(color));

        Marker marker = mMap.addMarker(markerOptions);

        if (marker != null) marker.showInfoWindow();
    }

    private void moveCamera(LatLng location) {
        if (mMap == null) {
            Log.e("PoiActivity", "GoogleMap is NULL in moveCamera()");
            return;
        }

        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(location, 15));
    }

    private void drawLine(LatLng start, LatLng end) {
        PolylineOptions plo = new PolylineOptions()
                .add(start)
                .add(end)
                .color(Color.YELLOW)
                .geodesic(true)
                .startCap(new RoundCap())
                .width(10)
                .jointType(JointType.BEVEL);

        mMap.addPolyline(plo);
        mMap.moveCamera(CameraUpdateFactory.newLatLng(start));
    }

    private void drawPolygon() {
        PolygonOptions polygonOptions = new PolygonOptions()
                .add(TUsofia, unss, lty, nsa)
                .strokeJointType(JointType.ROUND)
                .strokeColor(Color.BLUE)
                .strokeWidth(10);

        mMap.addPolygon(polygonOptions);
        mMap.moveCamera(CameraUpdateFactory.newLatLng(unss));
    }
}