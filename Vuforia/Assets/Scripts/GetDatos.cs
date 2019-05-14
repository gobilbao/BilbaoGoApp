using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GetDatos : MonoBehaviour
{
    public static GetDatos Instance { set; get; }

    
    
  
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        

        string screen_URL = "https://bilbaogo-2c61c.firebaseio.com/data/[numero]/sitio.json";
        
        StartCoroutine(RecogerDatos(screen_URL,Data.Instance.id));
    }


    IEnumerator RecogerDatos(string url,List<string> lista)
    {

        
        for (int i = 0; i < lista.Count; i++)
        {
            url = url.Replace("[numero]", lista[i]);
            Debug.Log(url);
            
         
            var uwr = new UnityWebRequest(url, "GET");
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                //Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                string[] corchete = uwr.downloadHandler.text.Split('{', '}');
                string[] comas = corchete[1].Split(',');
                string _nombre = null, _ubicacion = null, _informacion = null, _pista = null;
               
                for(int o = 0; o < comas.Length; o++)
                {
                   string[] datos =  comas[o].Split(':', '"');
                    switch (datos[1])
                    {
                        case ("nombre"):
                            _nombre = datos[4];
                            break;
                        case ("infor"):
                            _informacion = datos[4];
                            break;
                        case ("pista"):
                            _pista = datos[4];
                            break;
                        case ("ubicacion"):
                            _ubicacion = datos[4];
                            break;
                    }
                }

                Data.Instance.puntos.Add(new Punto { Nombre = _nombre, Ubicacion = _ubicacion, Informacion = _informacion, Pista = _pista });



            }
            url = "https://bilbaogo-2c61c.firebaseio.com/data/[numero]/sitio.json";
        }
        
    }
    
}
