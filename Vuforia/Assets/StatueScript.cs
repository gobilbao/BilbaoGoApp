using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatueScript : MonoBehaviour
{
    private Punto punto;
    public Punto Punto
    {
        get => punto;
        set => punto = value;
    }

    public Button btnPista1;
    public Button btnPista2;
    public Button btnPista3;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            enablePista3();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            disablePista3();
        }
    }

    public void enablePista1()
    {
        if (!btnPista2.IsActive() && !btnPista3.IsActive())
        {
            btnPista1.enabled = true;
        }
    }
    
    public void enablePista2()
    {
        if (!btnPista3.IsActive())
        {
            btnPista1.enabled = false;
            btnPista2.enabled = true;
        }
    }
    
    public void enablePista3()
    {
        btnPista1.enabled = false;
        btnPista2.enabled = false;
        btnPista3.enabled = true;
    }

    public void disablePista1()
    {
        btnPista1.enabled = false;
        btnPista2.enabled = false;
        btnPista3.enabled = false;
    }
    
    public void disablePista2()
    {
        btnPista1.enabled = true;
        btnPista2.enabled = false;
        btnPista3.enabled = false;
    }
    
    public void disablePista3()
    {
        btnPista1.enabled = false;
        btnPista2.enabled = true;
        btnPista3.enabled = false;
    }
}
