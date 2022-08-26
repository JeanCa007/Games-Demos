using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    public float recuperar_energia = 0.1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("BatterySound")?.GetComponent<AudioSource>().Play();     
            Jugador_Movimiento.vidaActual += recuperar_energia;
        }
         
        Destroy(gameObject);
    }
}
