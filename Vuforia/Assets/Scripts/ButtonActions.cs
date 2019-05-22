using System.Collections;
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

    public void Map_TriggerRA()
    {
        var map = LocationProviderFactory.Instance.mapManager;

        Vector3 t = map.GeoToWorldPosition(LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation
            .LatitudeLongitude);
        Debug.Log(t);
        gameObject.GetComponent<GameManager>().RA_LatLong = t;
        SceneManager.LoadScene(2);
    }
}