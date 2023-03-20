using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dano : MonoBehaviour{
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player")
        {
            other.GetComponent<vida>().RestarVida(cantidad);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<vida>().RestarVida(cantidad);
        }

    }
}
   
