﻿using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void MainMenu_StartAction()
    {
        SceneManager.LoadScene(1);
    }

    public void Map_TriggerRA_Pista1()
    {
        var map = LocationProviderFactory.Instance.mapManager;

        Vector3 t = map.GeoToWorldPosition(LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation
            .LatitudeLongitude);
        gameObject.GetComponent<GameManager>().RA_LatLong = t;
        gameObject.GetComponent<GameManager>().numPistas = 1;

        SceneManager.LoadScene(2);
    }
    
    public void Map_TriggerRA_Pista2()
    {
        var map = LocationProviderFactory.Instance.mapManager;

        Vector3 t = map.GeoToWorldPosition(LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation
            .LatitudeLongitude);
        gameObject.GetComponent<GameManager>().RA_LatLong = t;
        gameObject.GetComponent<GameManager>().numPistas = 2;

        SceneManager.LoadScene(2);
    }
    
    public void Map_TriggerRA_Pista3()
    {
        var map = LocationProviderFactory.Instance.mapManager;

        Vector3 t = map.GeoToWorldPosition(LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation
            .LatitudeLongitude);
        gameObject.GetComponent<GameManager>().RA_LatLong = t;
        gameObject.GetComponent<GameManager>().numPistas = 3;

        SceneManager.LoadScene(2);
    }
}