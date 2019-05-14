using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    //public static GPS Instance { set; get; }

    public float attitude;
    public float timer = 0.0f;
    


    private void Start()
    {
       
        DontDestroyOnLoad(gameObject);
        Input.compass.enabled = true;
        
        //Instance = this;
    }

    private void Update()
    {
        if (timer <= 0)
        {

            Input.location.Start();
            Data.Instance.ath = Input.compass.trueHeading;
            Data.Instance.latitude = (decimal)Input.location.lastData.latitude;
            Data.Instance.longitude = (decimal)Input.location.lastData.longitude;
            attitude = Input.compass.trueHeading;
            Input.location.Stop();
            timer = 3;
        }
        else
        {
            timer -= 0.1f;
        }
        
    }

}
    