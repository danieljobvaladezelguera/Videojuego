using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_vida : MonoBehaviour
{
    public Image barravida;
    public float vidaActual;
    public float vidaMaxima;

    void Update()
    {
        barravida.fillAmount = vidaActual / vidaMaxima;
    }
}
