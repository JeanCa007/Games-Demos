using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola_Atraer_Garra : MonoBehaviour
{
	Pistola_Atraer garra;

	void Start()
	{
		garra = GameObject.FindGameObjectWithTag("puntoDisparo").GetComponent<Pistola_Atraer>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (Arma_Nivel01.puedeDestruir && col.gameObject.CompareTag("Atraer") && Arma_Nivel02.puedeAtraer)
        {
			garra.VerificaObjetivo(col.gameObject);
		}
		if (Arma_Nivel01.puedeDestruir && col.gameObject.CompareTag("Destructible"))
        {
			col.GetComponent<Animator>().SetBool("CajaDestruida", true);
			GameObject.FindWithTag("CajaExplode")?.GetComponent<AudioSource>().Play();
			col.GetComponent<Rigidbody2D>().gravityScale = 0;
			col.GetComponent<Collider2D>().enabled = false;
		}
		Destroy(gameObject);
	}
}
