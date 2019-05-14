using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance { set; get; }

   
    public int numero = 3;


    #region GPS

    public decimal latitude = 0;
    public decimal longitude = 0;

    #endregion

    #region GetDatos

    public List<string> id = new List<string>();
    public List<Punto> puntos = new List<Punto>();


    #endregion

    public void Start()
    {

        for (int i = 0; i < numero; i++)
        {
            id.Add(i.ToString());
        }
        Instance = this;
    }








}
