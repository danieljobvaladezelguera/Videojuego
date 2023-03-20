using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public int salud = 100;
    public bool invencible = false;
    public float tiempo_in = 1f;
    public float tiempo_frenado = 0.2f;

    public void RestarVida(int cantidad){
        if(!invencible && salud > 0){
            salud -= cantidad;
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelo());
        }
    }

    IEnumerator Invulnerabilidad(){
        //invencible = true;
        yield return new WaitForSeconds(tiempo_in);
    }
    IEnumerator FrenarVelo()
    {
        var velocidadActual = GetComponent<mover_personaje>().speed;
        GetComponent<mover_personaje>().speed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<mover_personaje>().speed = velocidadActual;
    }

}
