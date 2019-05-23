using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region MAINMENU

    bool initialize = true;
    public GameObject statuePrefab;
    
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
        
        if(initialize && mapPoints!=null)
        {
            String coordinate;
            String[] coordinates = new string[mapPoints.Count];
            for (int i = 0; i < mapPoints.Count-1; i++)
            {
                coordinate = mapPoints[i].Ubicacion.Split('|')[0] + "," + mapPoints[i].Ubicacion.Split('|')[1];
                coordinates[i] = coordinate;
                Debug.Log(i + coordinate);
            }

            gameObject.GetComponent<SpawnOnMap>().LocationStrings = coordinates;
            
            if (statuePrefab != null)
            {
                gameObject.GetComponent<SpawnOnMap>().MarkerPrefab = statuePrefab;
            }
            else
            {
                throw new Exception("No Marker Prefab assigned on GameManager");
            }
            initialize = false;
        }
    }

    public void changeToMapState()
    {
        Map_TriggerRA.onClick.AddListener(TriggerRA);
        gameObject.GetComponent<SpawnOnMap>().enabled = true;
        
    }

    public void TriggerRA()
    {
        GetComponent<ButtonActions>().Map_TriggerRA();
        DebugCoord.text = RA_LatLong.ToString();
    }
}