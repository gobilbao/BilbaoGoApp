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
        DontDestroyOnLoad(gameObject);
        Input.compass.enabled = true;
    }

    private void Update()
    {
        if (timer <= 0)
        {
            Input.location.Start();
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            //attitude = Input.compass.trueHeading;
            Input.location.Stop();
            timer = 3;
        }
        else
        {
            timer -= 0.1f;
        }
        
    }

}
    