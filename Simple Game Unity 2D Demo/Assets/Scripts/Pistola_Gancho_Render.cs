using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola_Gancho_Render : MonoBehaviour
{
    [Header("Objeto principal:")]
    public Pistola_Gancho pistolaGancho;

    public LineRenderer cableGancho_render;

    [Header("Características Generales:")]
    [SerializeField] private int precision = 40;
    [Range(0, 20)] [SerializeField] private float velocidad_endurecer_cable = 5;

    [Header("Animación Cable:")]
    public AnimationCurve curvaAnimacion_cable;
    [Range(0.01f, 4)] [SerializeField] private float tamanhoInicial_onda = 2;
    float tamanhoOnda = 0;

    [Header("Progresión Cable:")]
    public AnimationCurve curvaProgresion_cable;
    [SerializeField] [Range(1, 50)] private float velocidadProgresion_cable = 1;

    float tiempo_movimiento = 0;

    [HideInInspector] public bool estaEnganchado = true;

    bool cable_recto = true;

    private void OnEnable()
    {
        tiempo_movimiento = 0;
        cableGancho_render.positionCount = precision;
        tamanhoOnda = tamanhoInicial_onda;
        cable_recto = false;

        PuntosLineaHaciaPuntoObjetivo();

        cableGancho_render.enabled = true;
    }

    private void OnDisable()
    {
        cableGancho_render.enabled = false;
        estaEnganchado = false;
    }

    private void PuntosLineaHaciaPuntoObjetivo()
    {
        for (int i = 0; i < precision; i++)
        {
            cableGancho_render.SetPosition(i, pistolaGancho.puntoDisparo.position);
        }
    }

    private void Update()
    {
        tiempo_movimiento += Time.deltaTime;
        DibujarCable();
    }

    void DibujarCable()
    {
        if (!cable_recto)
        {
            if (cableGancho_render.GetPosition(precision - 1).x == pistolaGancho.puntoEnganche.x)
            {
                cable_recto = true;
            }
            else
            {
                DibujarCableConOndas();
            }
        }
        else
        {
            if (!estaEnganchado)
            {
                pistolaGancho.Enganche();
                estaEnganchado = true;
            }
            if (tamanhoOnda > 0)
            {
                tamanhoOnda -= Time.deltaTime * velocidad_endurecer_cable;
                DibujarCableConOndas();
            }
            else
            {
                tamanhoOnda = 0;

                if (cableGancho_render.positionCount != 2) { cableGancho_render.positionCount = 2; }

                DibujarCableSinOndas();
            }
        }
    }

    void DibujarCableConOndas()
    {
        for (int i = 0; i < precision; i++)
        {
            float delta = (float)i / ((float) precision - 1f);
            Vector2 offset = Vector2.Perpendicular(pistolaGancho.vectorDistanciaEnganche).normalized * curvaAnimacion_cable.Evaluate(delta) * tamanhoOnda;
            Vector2 posicionObjetivo = Vector2.Lerp(pistolaGancho.puntoDisparo.position, pistolaGancho.puntoEnganche, delta) + offset;
            Vector2 posicionActual = Vector2.Lerp(pistolaGancho.puntoDisparo.position, posicionObjetivo, curvaProgresion_cable.Evaluate(tiempo_movimiento) * velocidadProgresion_cable);

            cableGancho_render.SetPosition(i, posicionActual);
        }
    }

    void DibujarCableSinOndas()
    {
        cableGancho_render.SetPosition(0, pistolaGancho.puntoDisparo.position);
        cableGancho_render.SetPosition(1, pistolaGancho.puntoEnganche);
    }
}
