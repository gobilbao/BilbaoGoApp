using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartGameManagerMapScene : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _manager;
    public Text debugCoord;
    public AbstractMap map;
    public Button btnPista1;
    public Button btnPista2;
    public Button btnPista3;

    void Start()
    {
        _manager = GameObject.Find("GameManager");

        if (_manager != null)
        {

            _manager.GetComponent<GameManager>().DebugCoord = debugCoord;
            _manager.GetComponent<SpawnOnMap>().Map = map;
            _manager.GetComponent<SpawnOnMap>().btnPista1 = btnPista1;
            _manager.GetComponent<SpawnOnMap>().btnPista2 = btnPista2;
            _manager.GetComponent<SpawnOnMap>().btnPista3 = btnPista3;
            
            btnPista1.onClick.AddListener(triggerPista1);
            btnPista2.onClick.AddListener(triggerPista2);
            btnPista3.onClick.AddListener(triggerPista3);

            _manager.GetComponent<GameManager>().changeToMapState();

        }
        else
        {
            throw new Exception("GameManager not found");
        }
    }

    public void triggerPista1()
    {
        _manager.GetComponent<ButtonActions>().Map_TriggerRA_Pista1();
    }
    public void triggerPista2()
    {
        _manager.GetComponent<ButtonActions>().Map_TriggerRA_Pista2(); 
    }
    public void triggerPista3()
    {
        _manager.GetComponent<ButtonActions>().Map_TriggerRA_Pista3();
    }
}