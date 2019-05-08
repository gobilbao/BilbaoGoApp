using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public TextMesh coordenadas;
    public TextMesh coor;

    // Update is called once per frame
    private void Update()
    {
        coordenadas.text = "Lat: "+ GPS.Instance.latitude + Environment.NewLine +
                           "Long: " + GPS.Instance.longitude + Environment.NewLine +
                           "Timer: " + GPS.Instance.timer;
    }                                                                                                                                                                                                                                       
}
