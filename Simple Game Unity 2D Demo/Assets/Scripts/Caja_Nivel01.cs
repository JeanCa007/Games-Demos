using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caja_Nivel01 : MonoBehaviour
{
    static public Animator animador_componente;
    static public bool flag_animacion = false;
    

    private void Awake()
    {
        animador_componente = transform.GetComponent<Animator>();
    }

    public void AnimacionCaja()
    {
         
        animador_componente.SetBool("CajaDestruida", true);
        transform.GetComponent<Collider2D>().enabled = false;
    }
}
