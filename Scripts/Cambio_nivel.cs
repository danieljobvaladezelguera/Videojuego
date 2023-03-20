using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_nivel : MonoBehaviour{
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Nivel_2");
        }
    }
}
