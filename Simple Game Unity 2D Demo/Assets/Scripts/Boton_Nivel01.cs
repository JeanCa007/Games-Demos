using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton_Nivel01 : MonoBehaviour
{
   
    private bool permitirPresionar;
    private Animator animador_componente;
    public Animator plataforma02;
    public Animator plataforma03;
    public GameObject puerta_a_desbloquear;

    private void Awake()
    {
        animador_componente = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (permitirPresionar && Input.GetKeyDown(KeyCode.E))
        {
            PresionarBoton();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           
            permitirPresionar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            permitirPresionar = false;
        }
    }

    void PresionarBoton()
    {
        animador_componente.SetBool("botonPresionado", true);
        plataforma02.SetBool("Activa", true);
        plataforma03.SetBool("Activa", true);
        puerta_a_desbloquear.GetComponent<Animator>().SetBool("Unlocked", true);
        puerta_a_desbloquear.GetComponent<SpriteRenderer>().color = Color.black;
        puerta_a_desbloquear.GetComponent<Collider2D>().enabled = false;
    }
}
