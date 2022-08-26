using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Llave : MonoBehaviour
{
    public GameObject canvasllave;
    public Text texto_llave;

    void tiempo()
    {
        canvasllave.SetActive(true);
        Destroy(canvasllave, 5);
    }
     void OnCollisionEnter2D(Collision2D  other)
   {
      if (other.transform.CompareTag("Player"))
      {
         
        other.transform.GetComponent<Jugador_Movimiento>().setflagLLave(true);
        texto_llave.text = "X 1";
        Destroy(this.gameObject);
        tiempo();
      }
   }

}
