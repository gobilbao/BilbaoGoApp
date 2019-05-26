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

    private void Start()
    {
        if (gameObject.name.Equals("StatueMock"))
        {
            Punto p = new Punto();
            p.Nombre = "Mock";
            p.Id = "-1";
            p.Informacion = "Info Mock";
            p.Pista = "PistaMock1|PistaMock2|PistaMock3";
            p.Ubicacion = "2.132341,11.8879";
            punto = p;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            enablePista3();
            Debug.Log("Ha entrado en pista3");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            disablePista3();
            Debug.Log("Ha salido de pista3");
        }
    }

    public void enablePista1()
    {
        if (!btnPista2.IsActive() && !btnPista3.IsActive())
        {
            btnPista1.gameObject.SetActive(true);
            GameObject.Find("GameManager").GetComponent<GameManager>().numPistas = 1;
            GameObject.Find("GameManager").GetComponent<GameManager>().pistaForRA = punto;
        }
    }

    public void enablePista2()
    {
        if (!btnPista3.IsActive() && btnPista1.IsActive())
        {
            btnPista1.gameObject.SetActive(false);
            btnPista2.gameObject.SetActive(true);
            GameObject.Find("GameManager").GetComponent<GameManager>().numPistas = 2;
        }
    }

    public void enablePista3()
    {
        if (!btnPista1.IsActive() && btnPista2.IsActive())
        {
            btnPista1.gameObject.SetActive(false);
            btnPista2.gameObject.SetActive(false);
            btnPista3.gameObject.SetActive(true);
            GameObject.Find("GameManager").GetComponent<GameManager>().numPistas = 3;
        }
    }

    public void disablePista1()
    {
        btnPista1.gameObject.SetActive(false);
        btnPista2.gameObject.SetActive(false);
        btnPista3.gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().pistaForRA = null;
        GameObject.Find("GameManager").GetComponent<GameManager>().numPistas = 0;
    }

    public void disablePista2()
    {
        btnPista1.gameObject.SetActive(true);
        btnPista2.gameObject.SetActive(false);
        btnPista3.gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().numPistas = 1;
    }

    public void disablePista3()
    {
        btnPista1.gameObject.SetActive(false);
        btnPista2.gameObject.SetActive(true);
        btnPista3.gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().numPistas = 2;
    }
}