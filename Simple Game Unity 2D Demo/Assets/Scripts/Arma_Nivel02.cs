using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma_Nivel02 : MonoBehaviour
{
    private bool permitirRecoger;
    private Animator animador_componente;
    static public bool puedeAtraer = false;
    public GameObject canvas1;
    public GameObject canvastexto;
    public Image imagen_latigo;

    private void Awake()
    {
        puedeAtraer = false;
        animador_componente = transform.GetComponent<Animator>();
        imagen_latigo.enabled = false;
    }

    void Update()
    {
        if (permitirRecoger && Input.GetKeyDown(KeyCode.E))
        {
            RecogerArma();
            imagen_latigo.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            permitirRecoger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            permitirRecoger = false;
        }
    }

    void RecogerArma()
    {
        puedeAtraer = true;
        //activo el canvas del arma
        canvas1.SetActive(true);
        // desactivo el canvas que dice presiona E
        canvastexto.SetActive(false);
        // Destruyo el canvas del arma despues de 5 segundos
        Destroy(canvas1, 5);
        Destroy(gameObject);
        Destroy(GameObject.FindGameObjectWithTag("colliderCAJA"));

    }
}
