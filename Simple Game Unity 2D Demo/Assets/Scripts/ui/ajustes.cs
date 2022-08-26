using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ajustes : MonoBehaviour
{
    public static bool music = true;
    public static bool specialEffects = true;
    public GameObject yesSound;
    public GameObject noSound;
    public GameObject yesSpecial;
    public GameObject noSpecial;
    public GameObject musica;
    public GameObject efectos;


    private void Update()
    {
        Time.timeScale = GameObject.FindGameObjectWithTag("Pause") ? 0 : 1;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().enabled = GameObject.FindGameObjectWithTag("Pause") ? false : true;
    }
    void Start()
    {
       
        if (music)
        {
            musica.SetActive(true);
        }
        else
        {
            musica.SetActive(false);
        }

        if (specialEffects)
        {
            efectos.SetActive(true);
        }
        else
        {
            efectos.SetActive(false);
        }
    }

    public void Cambiocanvas(Canvas canvas)
    {
        if (canvas.gameObject.activeSelf == true)
        {
            canvas.gameObject.SetActive(false);


        }
        else
        {
            canvas.gameObject.SetActive(true);
        }
    }

    public void Deactive(GameObject objeto) 
    {
        objeto.SetActive(false);
    }

    public void Active(GameObject objeto)
    {
        objeto.SetActive(true);
    }

    public void Music(bool encendido) 
    {
        if (encendido)
        {
            music = true;
        }
        else
        {
            music = false;
        }
    }

    public void specialEff(bool encendido) 
    {
        if (encendido)
        {
            specialEffects = true;
        }
        else
        {
            specialEffects = false;
        }
    }

    public void SelectedSound(GameObject objeto)
    {
        if (objeto.activeSelf)
        {
            yesSound.GetComponent<Image>().color = Color.yellow;
            noSound.GetComponent<Image>().color = Color.red;
        }
        else
        {
            yesSound.GetComponent<Image>().color = Color.red;
            noSound.GetComponent<Image>().color = Color.yellow;
        }
    }

    public void SelectedSpecial(GameObject objeto)
    {
        if (objeto.activeSelf)
        {
            yesSpecial.GetComponent<Image>().color = Color.yellow;
            noSpecial.GetComponent<Image>().color = Color.red;
        }
        else
        {
            yesSpecial.GetComponent<Image>().color = Color.red;
            noSpecial.GetComponent<Image>().color = Color.yellow;
        }
    }

 
       
   

}
