using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GetDatos : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {

        WWW ruta = new WWW("https://bilbaogo-2c61c.firebaseio.com/data.json");
        yield return ruta;
        string datos = ruta.text;
        Debug.Log(CreateFromJSON(datos).Nombre);
        
       

    }

    public static Punto CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Punto>(jsonString);
    }
}
