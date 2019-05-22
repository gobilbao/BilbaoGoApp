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

    public Button debugRaButton;
    public Text debugCoord;
    public AbstractMap map;

    void Start()
    {
        _manager = GameObject.Find("GameManager");

        if (_manager != null)
        {
            _manager.GetComponent<GameManager>().Map_TriggerRA = debugRaButton;
            _manager.GetComponent<GameManager>().DebugCoord = debugCoord;
            _manager.GetComponent<SpawnOnMap>().Map = map;
            
            _manager.GetComponent<GameManager>().changeToMapState();
            
        }
        else
        {
            throw new Exception("GameManager not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}