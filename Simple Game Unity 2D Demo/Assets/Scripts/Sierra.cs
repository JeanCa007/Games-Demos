using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sierra : MonoBehaviour
{
    public float danno = 0.1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador_Movimiento.vidaActual -= danno;
            if (Jugador_Movimiento.vidaActual <= 0)
            {
                SceneManager.LoadScene("Nivel_01");
            }
        }
    }
}
