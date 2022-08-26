using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public float tiempoFinal=0f;
    public float tiempoActual=500f;
    public Text txt_tiempo;

    public Text txt_llave;


   void Start()
   {
       this.tiempoFinal=this.tiempoActual;
       
   }

    // Update is called once per frame
    void Update()
    {
        this.tiempoFinal-=1*Time.deltaTime;
        this.txt_tiempo.text= ""+this.tiempoFinal.ToString("0");
        if(this.tiempoFinal<=0)
        {
            this.resetLevel();
        }

        
    }

      private void resetLevel()
    {
        //TODO: Agtregar MSG
        SceneManager.LoadScene("Nivel_01");
    }

    

    

}
