using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;
    public float timer = 0.0f;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Input.location.Start();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= -5)
        {
            StartCoroutine(StartLocationService());
            timer = 0;
        }


    }
    private IEnumerator StartLocationService()
    {

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("El ususario no ha habilitado el GPS");
            
        }

       
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Tiempo agotado");
            
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("El servicio de localizacion fallo");
           
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
    }
}
