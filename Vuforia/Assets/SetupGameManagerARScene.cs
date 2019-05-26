using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGameManagerARScene : MonoBehaviour
{
    private GameManager _manager;
    public GameObject ARCamera;
    public Button btnCloseInfo;
    public Button btnBackToMap;
    
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        btnCloseInfo.onClick.AddListener(closeInfoListener);
        btnBackToMap.onClick.AddListener(backToMapListener);
        
        ARCamera.SetActive(true);
    }



    public void closeInfoListener()
    {
        _manager.gameObject.GetComponent<ButtonActions>().closeInfo();
    }

    public void backToMapListener()
    {
        _manager.gameObject.GetComponent<ButtonActions>().returnToMapScene();
    }
}
