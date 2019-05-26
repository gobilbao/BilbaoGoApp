using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

static class Constantes
{
    public const decimal Encontrada = 0.00005m;
    public const decimal Pista = 0.00010m;
}


public class UpdateGPSText : MonoBehaviour
{
    public TextMesh coordenadas;
    
    public GameObject PanelEncontrado;
    public Text Nombre;
    public Text Informacion;
    /*public TextMesh coordenadas;
    public TextMesh coordenadas;*/

    //A.E.C 26052019 Variables que alojan los datos obtenidos de Mapbox
    private string NombreEstatua;
    private string CoordenadasEstatua;
    private string InformacionEstatua;
    private string PistaEstatua;

    //A.E.C 26052019 Variables que alojan los datos especificos de coordenadas y pistas
    List<string> pistas = new List<string>();
    List<string> cordenadas = new List<string>();
    private string _CoordenadasEstatua;
    private string _PistaEstatua;
    public int numeroProximidad;
    private decimal y;
    private decimal x;
    private GameManager _manager;


    private void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ObtencionDatos();
        gestionarDatos();
        //A.E.C 26052019 Se encarga de gestionar la pista que debe mostrar
        pista();
        //A.E.C 26052019 Obtenemos la cercania con la estatua
        distancia();
    }

    private void ObtencionDatos()
    {
        
        NombreEstatua = _manager.pistaForRA.Nombre;
        CoordenadasEstatua = _manager.pistaForRA.Ubicacion;
        InformacionEstatua = _manager.pistaForRA.Informacion;
        PistaEstatua = _manager.pistaForRA.Pista;
        numeroProximidad = _manager.numPistas;
        
    }

    private void pista()
    {

        //A.E.C 26052019 Concretamos la proximidad para mostrar diferentes pistas
        switch (numeroProximidad)
        {
            case 1:
                _PistaEstatua = pistas[0];
                break;
            case 2:
                _PistaEstatua = pistas[1];
                break;
            case 3:
                _PistaEstatua = "Encontrado";

                break;
        }
    }

    private List<string> crearLista(string s)
    {
        List<string> a = new List<string>();
        string[] p = s.Split('|');
        a.AddRange(p);

        return a;
    }

    private void gestionarDatos()
    {
        //A.E.C 26052019 Creamos listas para almacenar todas las pistas y la coordenada
        pistas = crearLista(PistaEstatua);
        cordenadas = crearLista(CoordenadasEstatua);


        //A.E.C 26052019 Separamos coordenadas X e Y de el string
        string[] coord = CoordenadasEstatua.Split(',');

        y = decimal.Parse(coord[0]);
        x = decimal.Parse(coord[1]);

        
    }

    private void distancia()
    {

      

        if (_PistaEstatua.Equals("Encontrado"))
        {
            PanelEncontrado.SetActive(true);
            Nombre.text = NombreEstatua;
            Informacion.text = InformacionEstatua;
        }
        else
        {
            PanelEncontrado.SetActive(false);
        }

        
    }

    private void Update()
    {

        

        

        coordenadas.text =  NombreEstatua + Environment.NewLine +
                            _PistaEstatua;

    }

}
