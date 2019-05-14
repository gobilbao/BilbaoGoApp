using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance { set; get; }

    public int numero = 3;


    #region GPS

    public decimal latitude;
    public decimal longitude;

    #endregion

    #region GetDatos

     public List<Punto> puntos = new List<Punto>();
     public List<string> id = new List<string>();
    
    #endregion

    public void Start()
    {
        Instance = this;

        for(int i = 0; i < numero; i++)
        {
            id.Add(i.ToString());
        }
       
    }

   


   



}
