using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola_Atraer : MonoBehaviour
{
	Vector2 direccion_objetivo;
	GameObject objeto_objetivo;

	public Transform puntoDisparo;
	public LineRenderer cableGarra_render;
	public SpringJoint2D cableGarra_fisico;

	public GameObject garra;
	public float velocidad_garra;
	public Animator animador;

	public GameObject player;


    void Start()
	{
		cableGarra_render.enabled = false;
		cableGarra_fisico.enabled = false;
	}

	void Update()
	{
		Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		direccion_objetivo = MousePos - (Vector2)transform.position;

		ApuntarHaciaMouse();

		if (Input.GetMouseButtonDown(0))
		{
			DispararGarra();
			animador.SetBool("estaDisparando", true);
			animador.SetBool("isJumping", false);
		}

		if (Input.GetMouseButtonUp(0))
		{
			LiberarGarra();
			animador.SetBool("estaDisparando", false);
			animador.SetBool("isJumping", true);
		}

		if (objeto_objetivo != null)
		{
			cableGarra_render.SetPosition(0, puntoDisparo.position);
			cableGarra_render.SetPosition(1, objeto_objetivo.transform.position);
		}
	}

	void ApuntarHaciaMouse()
	{
		transform.right = direccion_objetivo;
	}

	void DispararGarra()
	{
		GameObject garraPistola = Instantiate(garra, puntoDisparo.position, Quaternion.identity);
		if(Arma_Nivel01.puedeDestruir)
        {
			garraPistola.GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		garraPistola.GetComponent<Rigidbody2D>().AddForce(transform.right * velocidad_garra);
	}

	public void VerificaObjetivo(GameObject hit)
	{
		objeto_objetivo = hit;
		cableGarra_render.enabled = true;
		cableGarra_fisico.enabled = true;
		cableGarra_fisico.connectedBody = objeto_objetivo.GetComponent<Rigidbody2D>();
	}

	void LiberarGarra()
	{
		cableGarra_render.enabled = false;
		cableGarra_fisico.enabled = false;
		objeto_objetivo = null;
	}
}
