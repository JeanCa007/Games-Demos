using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Jugador_Movimiento : MonoBehaviour
{
    private Rigidbody2D rigid_body;             // Componente para utilizar física en nuestro personaje
    private Animator animador_componente;       // Componente para animaciones del personaje

    private bool bandera_dobleSalto;            // Verifica si se puede realizar doble salto. Después del segundo salto se vuelve "false"
    private float camara_offset_Z = -10f;       // Retrocede la cámara para que se pueda ver el nivel

    [SerializeField] private float gravedad_normal;
    [SerializeField] private float gravedad_con_propulsor;

    [SerializeField] private Camera camara;                                 // Para que la cámara siga a nuestro personaje
    [SerializeField] private ParticleSystem sistema_particulas_propulsor;   // Se activa en los pies del personaje cuando "flota"
    [SerializeField] private float velocidad_movimiento;                    // Velocidad del movimiento del personaje
    [SerializeField] private float velocidad_salto;                         // Velocidad del salto del personaje
    [SerializeField] private LayerMask plataformas_layer;                   // Se establece en qué "capas (layers)" el personaje puede SALTAR

    public Image barraVida;
    static public float vidaMaxima = 1f;
    static public float vidaActual;

    public bool flagLlave=false;
    private void Awake()
    {
        rigid_body = transform.GetComponent<Rigidbody2D>();         // Se obtiene el componente para utilizar física

        animador_componente = transform.GetComponent<Animator>();   // Se obtiene el componente para animaciones en el movimiento del personaje
        if (SceneManager.GetActiveScene().name == "Nivel_02")
        {
            Arma_Nivel01.puedeDestruir = true;
        }
    }

    public void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void Update()
    {

        MovimientoPersonaje();                                                  // Mueve al personaje de acuerdo al INPUT ingresado

        // *************** DOBLE SALTO ***********************
        if (Input.GetKey(KeyCode.Space))                                        // Si se detecta la "barra espaciadora":
        {                                                                       //
            if (PersonajeEstaEnPiso())                                          // - Si el personaje está parado en el piso:
            {                                                                   //
                rigid_body.velocity = Vector2.up * velocidad_salto;             // a) El personaje realiza un salto hacia arriba con la magnitud "velocidad_salto"
            }                                                                   //
            else                                                                // - Sino:
            {                                                                   //
                if (Input.GetKeyDown(KeyCode.Space))                            // _ Si se presiona nuevamente la "barra espaciadora" durante el salto:
                {                                                               //
                    if (bandera_dobleSalto)                                     // __ Si podemos ejecutar un DOBLE SALTO (true):
                    {                                                           //
                        rigid_body.velocity = Vector2.up * velocidad_salto;     // El personaje vuelve a relizar un salto en el aire hacia arriba con la magnitud "velocidad_salto"
                        bandera_dobleSalto = false;                             // Se bloquea la opción de dar un salto nuevamente por lo que sólo se pueden realizar dos saltos
                    }                                                           //
                }                                                               //
            }                                                                   //
        }                                                                       // **************************************************

        // ************ ANIMACIÓN DEL PROPULSOR *************
        if (!PersonajeEstaEnPiso())                                 // Si el personaje no se encuentra en el piso:
        {
            animador_componente.SetBool("isJumping", true);
            animador_componente.SetBool("estaEnPiso", false);//
            if (Input.GetKey(KeyCode.W))                            // - Si se detecta la tecla "W":
            {                                                       //
                rigid_body.gravityScale = gravedad_con_propulsor;   // Reducimos la gravedad del personaje para que descienda más lento
                sistema_particulas_propulsor.Play();                // Se activa el sistema de partículas (propulsor)
            }                                                       //
            else                                                    // - Sino:
            {                                                       //
                rigid_body.gravityScale = gravedad_normal;          // La gravedad del jugador vuelve a la normalidad
                sistema_particulas_propulsor.Stop();                // Se detiene el sistema de partículas (propulsor)
            }                                                       //
        }                                                           // **************************************************

        if (PersonajeEstaEnPiso())                                          // **** ANIMACIONES DE MOVIMIENTO DEL PERSONAJE ****
        {                                                                   //
            bandera_dobleSalto = true;                                      // El personaje puede saltar dos veces
            sistema_particulas_propulsor.Stop();                            // Si el personaje está en el piso, se detiene el sistema de partículas (propulsor)
            animador_componente.SetBool("isJumping", false);
            animador_componente.SetBool("estaEnPiso", true);     // Cambia el animador del personaje
        }                                                                   //
                                                                            //
        if (rigid_body.velocity.x > 0)                                      // Si se detecta un SALTO:
        {                                                                   //
            animador_componente.SetBool("estaDisparando", false);
            //animador_componente.SetBool("isJumping", true);
            //animador_componente.SetBool("estaEnPiso", false);             //   a) inicia la animación de SALTO
        }                                                                   //
        /*else                                                              // Sino:
        {                                                                   //
            animador_componente.SetBool("isJumping", false);
            animador_componente.SetBool("estaEnPiso", true);                //   b) se detiene la animación de SALTO
        } */                                                                // *************************************************
        
        barraVida.fillAmount = vidaActual;                                  // Actualiza la barra de energía
    }

    void LateUpdate()
    {
        camara.transform.position = new Vector3(transform.position.x, transform.position.y, camara_offset_Z); // La camára sigue al jugador pero con diferente posición en eje Z
    }

    private void MovimientoPersonaje()
    {
        float magnitud_movimiento = Input.GetAxis("Horizontal");                                            // Se detecta la magnitud para el movimiento horizontal
        transform.position += new Vector3(magnitud_movimiento, 0, 0) * Time.deltaTime * velocidad_movimiento;  // Se "mueve" al personaje en la direccipon ingresada por la magnitud "velocidad_movimiento" respecto al tiempo "Time.deltaTime"
        animador_componente.SetFloat("Speed", Mathf.Abs(magnitud_movimiento));                                 // Se activa la animación "CAMINAR" para el personaje

        if (!Input.GetKey(KeyCode.LeftShift))                                                                               // Si se presiona cualquier tecla que no sea "Shift Izquierdo"
        {                                                                                                                   //
            if (!Mathf.Approximately(0, magnitud_movimiento))                                                            // a) Si se detecta movimiento
                transform.rotation = magnitud_movimiento <= 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;  // El personaje gira 180 grados horizontalmente
        }
    }

    private bool PersonajeEstaEnPiso()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, plataformas_layer); // Se detecta si el personaje está colisionando con un objeto determinado a través de un RayCast hacia abajo
        Debug.DrawRay(transform.position, new Vector2(0,-2), Color.green);                                      // También se establece con qué "capa - layer" queremos que interactúe la colisión
        return raycastHit2D.collider != null;                                                                             
    }

    public void setflagLLave(bool value){

        this.flagLlave=value;
    }

    public bool getFlagLLave(){
        return this.flagLlave;
    }
}
