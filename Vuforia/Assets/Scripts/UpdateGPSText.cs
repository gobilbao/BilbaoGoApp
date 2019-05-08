using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public TextMesh coordenadas;
    public TextMesh coor;
    private string coordenadasOtro = "43,31238|-3,005846";
    private string encontrado;
    private float X = 0;
     private float Y = 0;
    int menorX = 1;
    int menorY = 1;

    private void calcularDistancia()
    {
       
        
        string[] coordendasoto =coordenadasOtro.Split('|');
        if (coordendasoto.Length < 2)
        {
            Debug.Log("No contiene lso parametros correctos");
            return;
        }

        Y = float.Parse(coordendasoto[0]);
        X = float.Parse(coordendasoto[1]);

        

        if (Y > 0)
        {
            menorY = -1;
        }
        if(X > 0)
        {
            menorX = -1;
        }


        if(GPS.Instance.latitude<Y+(0.00001*menorY) && GPS.Instance.longitude<X+(0.00001*menorX))
        {
            encontrado = "Encontrado";
        }
        else
        {
            encontrado = "No encontrado";
        }
    }
   
    private void Update()
    {
        calcularDistancia();
        coordenadas.text = "Lat: "+ GPS.Instance.latitude + Environment.NewLine +
                           "Long: " + GPS.Instance.longitude + Environment.NewLine +
                           "Timer: " + GPS.Instance.timer + Environment.NewLine +
                           "Estatua: " + encontrado + Environment.NewLine +
                           "X: " + (X + (0.00001 * menorX)) + " Y:"+ (Y + (0.00001 * menorY));
    }                                                                                                                                                                                                                                       
}
