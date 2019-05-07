using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;
    public float attitude;
    public float timer = 0.0f;

    private void Start()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        Input.compass.enabled = true;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= -3)
        {
            StartLocationService();
        }


    }
    private void StartLocationService()
    {

        if (!Input.location.isEnabledByUser)
        {
            Input.location.Start();
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                new WaitForSeconds(1);
                maxWait--;
            }
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("El servicio de localizacion fallo");

            }
            else
            {
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
                attitude = Input.compass.trueHeading;
            }

            Input.location.Stop();
        }

    }
}
