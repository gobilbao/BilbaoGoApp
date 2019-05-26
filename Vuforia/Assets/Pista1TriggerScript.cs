using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            gameObject.transform.parent.GetComponent<StatueScript>().enablePista1();
            Debug.Log("Ha entrado en pista1");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            gameObject.transform.parent.GetComponent<StatueScript>().disablePista1();
            Debug.Log("Ha salido de pista1");
        }
    }
}
