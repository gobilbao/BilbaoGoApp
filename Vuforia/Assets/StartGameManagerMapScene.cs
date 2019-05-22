using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartGameManagerMapScene : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _manager;

    public Button debugRaButton;
    public Text debugCoord;

    void Start()
    {
        _manager = GameObject.Find("GameManager");

        if (_manager != null)
        {
            Debug.Log("StartingTransitionToMap");
            _manager.GetComponent<GameManager>().Map_TriggerRA = debugRaButton;
            _manager.GetComponent<GameManager>().DebugCoord = debugCoord;
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