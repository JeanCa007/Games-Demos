using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola_Gancho : MonoBehaviour
{
    [Header("Script de Referencia:")]
    public Pistola_Gancho_Render pistolaGancho_render;

    [Header("Opciones de Capas:")]
    [SerializeField] private bool engancharATodasCapas = false;
    [SerializeField] private int engancharSoloUnaCapa = 9;

    [Header("Cámara Principal:")]
    public Camera camara;

    [Header("Referencia para Transform:")]
    public Transform pistolaPoseedor;
    public Transform pìstolaPivot;
    public Transform puntoDisparo;

    [Header("Física:")]
    public SpringJoint2D cableGancho_fisico;
    public Rigidbody2D rigidBody;

    [Header("Rotación:")]
    [SerializeField] private bool rotarSobreTiempo = true;
    [Range(0, 60)] [SerializeField] private float velocidad_rotacion = 4;

    [Header("Distancia:")]
    [SerializeField] private bool tieneMaximaDistancia = false;
    [SerializeField] private float distancia_cuerda;
    [SerializeField] private float maximaDistancia = 20;

    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    [Header("Lanzamiento:")]
    [SerializeField] private bool lanzarHaciaPunto = true;
    [SerializeField] private LaunchType tipoLanzamiento = LaunchType.Physics_Launch;
    [SerializeField] private float velocidad_lanzamiento = 1;

    [Header("Sin lanzamiento hacia punto:")]
    [SerializeField] private bool autoConfigurarDistancia = false;
    [SerializeField] private float distanciaObjetivo = 3;
    [SerializeField] private float frecuenciaObjetivo = 1;

    [HideInInspector] public Vector2 puntoEnganche;
    [HideInInspector] public Vector2 vectorDistanciaEnganche;

    private void Start()
    {
        pistolaGancho_render.enabled = false;
        cableGancho_fisico.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EstablecerPuntoEnganche();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            if (pistolaGancho_render.enabled)
            {
                GirarPistola(puntoEnganche, false);
            }
            else
            {
                Vector2 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
                GirarPistola(mousePos, true);
            }

            if (lanzarHaciaPunto && pistolaGancho_render.estaEnganchado)
            {
                if (tipoLanzamiento == LaunchType.Transform_Launch)
                {
                    Vector2 firePointDistnace = puntoDisparo.position - pistolaPoseedor.localPosition;
                    Vector2 targetPos = puntoEnganche - firePointDistnace;
                    pistolaPoseedor.position = Vector2.Lerp(pistolaPoseedor.position, targetPos, Time.deltaTime * velocidad_lanzamiento);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            pistolaGancho_render.enabled = false;
            cableGancho_fisico.enabled = false;
        }
        else
        {
            Vector2 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
            GirarPistola(mousePos, true);
        }
    }

    void GirarPistola(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - pìstolaPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotarSobreTiempo && allowRotationOverTime)
        {
            pìstolaPivot.rotation = Quaternion.Lerp(pìstolaPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * velocidad_rotacion);
        }
        else
        {
            pìstolaPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void EstablecerPuntoEnganche()
    {
        Vector2 distanceVector = camara.ScreenToWorldPoint(Input.mousePosition) - pìstolaPivot.position;
        if (Physics2D.Raycast(puntoDisparo.position, distanceVector.normalized))
        {
            RaycastHit2D _hit = Physics2D.Raycast(puntoDisparo.position, distanceVector.normalized);
            if (_hit.transform.gameObject.layer == engancharSoloUnaCapa || engancharATodasCapas)
            {
                if (Vector2.Distance(_hit.point, puntoDisparo.position) <= maximaDistancia || !tieneMaximaDistancia)
                {
                    puntoEnganche = _hit.point;
                    vectorDistanciaEnganche = puntoEnganche - (Vector2) pìstolaPivot.position;
                    pistolaGancho_render.enabled = true;
                }
            }
        }
    }

    public void Enganche()
    {
        cableGancho_fisico.autoConfigureDistance = false;
        if (!lanzarHaciaPunto && !autoConfigurarDistancia)
        {
            cableGancho_fisico.distance = distanciaObjetivo;
            cableGancho_fisico.frequency = frecuenciaObjetivo;
        }
        if (!lanzarHaciaPunto)
        {
            if (autoConfigurarDistancia)
            {
                cableGancho_fisico.autoConfigureDistance = true;
                cableGancho_fisico.frequency = 0;
            }

            cableGancho_fisico.connectedAnchor = puntoEnganche;
            cableGancho_fisico.enabled = true;
        }
        else
        {
            switch (tipoLanzamiento)
            {
                case LaunchType.Physics_Launch:
                    cableGancho_fisico.connectedAnchor = puntoEnganche;

                    Vector2 distanceVector = new Vector2(distancia_cuerda,0);//puntoDisparo.position - pistolaPoseedor.position;

                    cableGancho_fisico.distance = distanceVector.magnitude;
                    cableGancho_fisico.frequency = velocidad_lanzamiento;
                    cableGancho_fisico.enabled = true;
                    break;
                case LaunchType.Transform_Launch:
                    rigidBody.velocity = Vector2.zero;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoDisparo != null && tieneMaximaDistancia)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(puntoDisparo.position, maximaDistancia);
        }
    }
}
