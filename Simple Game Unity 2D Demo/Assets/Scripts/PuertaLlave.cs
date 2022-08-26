using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaLlave : MonoBehaviour
{   
        public string nivel="Nivel_02";
        public GameObject canvas1;


    public IEnumerator Tiempocanvas(float tiempo, GameObject canvas)
    {
        //creo una corrutina par esperar X segundos.
        yield return new WaitForSeconds(tiempo);
        canvas.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D  other)
   {

      if (other.transform.CompareTag("Player"))
      {
         
         if(other.transform.GetComponent<Jugador_Movimiento>().getFlagLLave()){

              Destroy(this.gameObject);
            
            if(SceneManager.GetActiveScene().name.Equals("Nivel_02")){

                this.nivel="Ganaste";//Aca va la escena de los creditos

            }

             SceneManager.LoadScene(this.nivel);
             
         } else
            {
                canvas1.SetActive(true);
                // comienzo la corrutina tiempo canvas por 5 segundos.
                StartCoroutine(Tiempocanvas(5,canvas1));
                // despues de 5 segundos desactiva el canvas de la puerta.
               //


                

            }



        
      }
   }
}
