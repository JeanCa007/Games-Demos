using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_Nivel02 : MonoBehaviour
{
    private bool permitirPresionar;
    private Animator animador_componente;
    public GameObject puerta_a_desbloquear;
    public GameObject canvas1;
    public GameObject canvastexto;
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
        if (collision.gameObject.CompareTag("Player"))
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
        puerta_a_desbloquear.GetComponent<Animator>().SetBool("Unlocked", true);
        puerta_a_desbloquear.GetComponent<SpriteRenderer>().color = Color.black;
        puerta_a_desbloquear.GetComponent<Collider2D>().enabled = false;
        canvas1.SetActive(true);
        canvastexto.SetActive(false);
        Destroy(canvas1, 5);
    }
}
