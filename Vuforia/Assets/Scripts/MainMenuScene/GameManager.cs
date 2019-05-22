using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region MAINMENU

    public Text DebugPoints;

    #endregion

    #region MAP

    public Text DebugCoord;

    public Button Map_TriggerRA;
    public Vector3 RA_LatLong;

    #endregion

    private List<Punto> mapPoints;
    public List<Punto> MapPoints
    {
        get => mapPoints;
        set => mapPoints = value;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()

    {
        if(DebugPoints!=null && mapPoints!=null)
        {
            for (int i = 0; i < mapPoints.Count-1; i++)
            {
                DebugPoints.text =DebugPoints.text + mapPoints[i].Nombre + " " + mapPoints[i].Informacion + " " + mapPoints[i].Pista +
                                   " " + mapPoints[i].Ubicacion + " \n ";
            }

            DebugPoints = null;
        }
    }

    public void changeToMapState()
    {
        Map_TriggerRA.onClick.AddListener(TriggerRA);
        Debug.Log("ChangedToMapState");
    }

    public void TriggerRA()
    {
        Debug.Log("TRIGGER_RA");
        GetComponent<ButtonActions>().Map_TriggerRA();
        DebugCoord.text = RA_LatLong.ToString();
    }
}