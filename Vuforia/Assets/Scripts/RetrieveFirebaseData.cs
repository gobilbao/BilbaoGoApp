using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveFirebaseData : MonoBehaviour
{
    private string url = "https://bilbaogo-2c61c.firebaseio.com/data/.json";
    private WWW www;
    List<Punto> puntos;
 
    void Start() {
        www = new WWW (url);
        StartCoroutine (ReceiveResponse());
    }
 
    private IEnumerator ReceiveResponse() {
        yield return www;
        
        JSONObject json = new JSONObject(www.text);
        puntos = new List<Punto>();
        for (int i = 0; i < json.Count; i++)
        {
            Punto p = new Punto();
            p.Id = json[i].GetField("sitio").GetField("idSitio").ToString();
            p.Informacion = json[i].GetField("sitio").GetField("infor").ToString();
            p.Nombre = json[i].GetField("sitio").GetField("nombre").ToString();
            p.Pista = json[i].GetField("sitio").GetField("pista").ToString();
            p.Ubicacion = json[i].GetField("sitio").GetField("ubicacion").ToString();
            puntos.Add(p);
        }
        sendDataToGameManager();
    }
    private void sendDataToGameManager()
    {
        gameObject.GetComponent<GameManager>().MapPoints = puntos;
    }
}
