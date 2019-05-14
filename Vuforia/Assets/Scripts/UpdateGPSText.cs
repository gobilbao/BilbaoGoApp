using System;
using UnityEngine;

static class Constants
{
    public const decimal Encontrada = 0.00005m;
    public const decimal Pista = 0.00010m;
    
}


public class UpdateGPSText : MonoBehaviour
{
    public TextMesh coordenadas;
    public TextMesh coor;
    private string coordenadasOtro;
    private string encontrado;
    



    private void calcularDistancia()
    {
        coordenadasOtro = Data.Instance.puntos[0].Ubicacion;

        /*int valorY= 1;
        int valorX = 1;
        
        string[] coordenadasSitio =coordenadasOtro.Split('|');

        if (coordenadasSitio.Length < 2)
        {
            //Debug.Log("No contiene los parametros correctos");
            return;
        }

      
        decimal Y = decimal.Parse(coordenadasSitio[0]);
        decimal X = decimal.Parse(coordenadasSitio[1]);

        if (Y < 0){
            valorY = -1;
        }
        if(X < 0)
        {
            valorX = -1;
        }

        //Debug.Log("PistaY: " + (Y - Constants.Pista * valorY) + "|" + (Y + Constants.Pista * valorY));
        //Debug.Log("PistaX: " + (X - Constants.Pista * valorX) + "|" + (X + Constants.Pista * valorX));


        if ((Data.Instance.latitude> (Y - (Constants.Encontrada*valorY)) && Data.Instance.latitude < (Y + (Constants.Encontrada * valorY))) && ((Data.Instance.longitude < (X - (Constants.Encontrada*valorX) ) ) && (Data.Instance.longitude > (X + (Constants.Encontrada*valorX)))))
        {

            encontrado = (Y - (Constants.Pista * valorY))+"Encontrado"+(Y + (Constants.Pista * valorY));
      

        }else if ((Data.Instance.latitude > (Y - (Constants.Pista * valorY)) && Data.Instance.latitude < (Y + (Constants.Pista * valorY))) && ((Data.Instance.longitude < (X - (Constants.Pista * valorX)) && Data.Instance.longitude > (X + (Constants.Pista * valorX)))))
        {
            
            encontrado = "Pista";
            


        }
        else
        {
            encontrado = "No encontrado";
        }







    */
    }
   
    private void Update()
    {
        calcularDistancia();
        coordenadas.text = "Lat: "+ Data.Instance.latitude + Environment.NewLine +
                           "Long: " + Data.Instance.longitude + Environment.NewLine +
                           "Estatua: " + encontrado + Environment.NewLine+
                           "Nombre estatua: "+ Data.Instance.puntos[0].Nombre + Environment.NewLine +
                           "Pista: " + Data.Instance.puntos[0].Pista + Environment.NewLine +
                           "Ubicacion: " + Data.Instance.puntos[0].Ubicacion + Environment.NewLine +
                           "Informacion: " + Data.Instance.puntos[0].Informacion + Environment.NewLine;
    }                                                                                                                                                                                                                                       
}
