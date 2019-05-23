using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista2TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            gameObject.transform.parent.GetComponent<StatueScript>().enablePista2();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("Player"))
        {
            gameObject.transform.parent.GetComponent<StatueScript>().disablePista3();
        }
    }
}
