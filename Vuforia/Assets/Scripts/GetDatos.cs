using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW ruta = new WWW ("https://bilbaogo-2c61c.firebaseio.com/.json");
        yield return ruta;
        string datos = ruta.    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
