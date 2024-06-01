using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Principal_Player : MonoBehaviour
{
    //En este script se gestiona todo del jugador, ya sea de su imput o tal, llamando eso sí, a los scripts respectivos de vida, contador...

    //PERSONAJE
    Rigidbody rb;
    PlayerInput playerinput;
    Animator animacion;

    //VARIABLES
    bool suelo = true;
    float velocidad = 4f;
    float gradosrot = 45f;
    public float fuerzaSalto = 45f;
    public float bajadaSalto = 60f;
    bool alimentoin = false;
    bool puertain = false;
    bool laberintoin = false;
    bool aguain = false;
    [HideInInspector]
    public bool arandanocogido = false;
    [HideInInspector]
    public bool huevocogido = false;
    [HideInInspector]
    public bool pezcogido = false;
    Quaternion rotaciones;

    //OBJETOS
    GameObject objetoInteractuado;
    public CinemachineVirtualCamera camaraseguimiento;
    public CinemachineVirtualCamera camaralaberinto;

    //SCRIPTS
    public Vida_Player Vidas;
    public Inventario Mochila;
    public Casita Casa;
    public Interfaz Interfaz;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       playerinput = GetComponent<PlayerInput>();
       animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Rotaciones();
    }
    void Movimiento()
    {
        /*/ESTA ES LA VERSIÓN QUE SE MUEVA NORMAL EN X e Y
        rb.velocity = new Vector3(movAction.x * velocidad, rb.velocity.y, movAction.y * velocidad);*/

        /*/ESTA HACE QUE CUANDO SE GIRE SE MUEVA EN EL EJE LOCAL DEL PERSONAJE
        NOTA: TRANSFORM.FORWARD = ADELANTE EN LOCAL, FORWARD (SIN TRANSAFORM) = ADELANTE EN GLOBAL (EL MUNDO)*/

        Vector2 movAction = playerinput.actions["Move"].ReadValue<Vector2>();
        Vector3 adelante = movAction.y * velocidad * transform.forward;
        Vector3 lado = movAction.x * velocidad * transform.right;
        Vector3 movimiento = adelante + lado;
        movimiento.y = rb.velocity.y;
        rb.velocity = movimiento;
        if ((movAction.y > 0 || movAction.x >0) && !aguain)
        {
            animacion.SetBool("SeMueve", true);
            animacion.SetFloat("Velocidad", movAction.y);
        }
        else
        {
            animacion.SetBool("SeMueve", false);
            animacion.SetFloat("Velocidad", movAction.y);
        }
        if ((movAction.y > 0 || movAction.x > 0) && aguain)
        {
            //adelante = movAction.y * velocidad * transform.up;
            animacion.SetBool("Nadar", true);
        }
        else
        {
            animacion.SetBool("Nadar", false);
        }
    }
    private void Rotaciones()
    {
        Vector2 rotAction = playerinput.actions["TurnAround"].ReadValue<Vector2>();
        transform.Rotate(0,rotAction.x * gradosrot * Time.deltaTime,0);
    }
    public void SaltoCamara(InputAction.CallbackContext context)
    {
        //NOTA: "laberintoin == true" sería como poner "laberintoin" solo :)
        if (context.phase == InputActionPhase.Performed && laberintoin) 
        {
            camaralaberinto.Priority = 11;
            camaraseguimiento.Priority = 10;
        }
        else
        {
            camaralaberinto.Priority = 10;
            camaraseguimiento.Priority = 11;
        }
        Debug.Log(camaraseguimiento.Priority);
    }
    public void Salto(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && suelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            suelo = false;
            animacion.SetBool("Saltar", true);
        }
        else
        {
            animacion.SetBool("Saltar", false);
        }
        float altura = transform.position.z;
        if (altura > 21)
        {
            rb.AddForce(Vector3.down * bajadaSalto, ForceMode.Acceleration);
        }
    }
    public void AccionesCogerAbrir(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && alimentoin)
        {
            if (objetoInteractuado.name.Contains("Food_Fish"))
            {
                Debug.Log("pescaito cogido");
                Mochila.GuardarPescado();
                pezcogido = true;
            }
            if (objetoInteractuado.name.Contains("Food_Egg"))
            {
                Debug.Log("huevo cogido");
                Mochila.GuardarHuevo();
                huevocogido = true;
            }
            if (objetoInteractuado.name.Contains ("Food_Blueberry"))
            {
                Debug.Log("arandanito cogido");
                Mochila.GuadarArandano();
                arandanocogido = true;
            } 
            animacion.SetTrigger("Recoger");
            Invoke("RetardoRecogerAlimento", animacion.GetCurrentAnimatorStateInfo(0).length);
            alimentoin = false;
        }
        if (context.phase == InputActionPhase.Performed && puertain)
        {
            Casa.AnimacionPuerta();
            puertain = false;
        }
        else if (context.phase == InputActionPhase.Performed)
        {
            Casa.CerrarPuerta();
            puertain = true;
        }
    }
    public void RetardoRecogerAlimento()
    {
        Destroy(objetoInteractuado);
        objetoInteractuado = null;
        Interfaz.MostrarAlimento();
    }
    public void InventarioDerecha (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Mochila.ActivoDerecha();
        }
    }
    public void InventarioIzquierda (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Mochila.ActivoIzquierda();
        }
    }
    public void Comer(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (Mochila.comidactiva == 0 && Mochila.arandano > 0)
            {
                //Poner que cuando interactua con el arandano en el inventario haga lo siguiente:
                Vidas.ComerArandano();
                Mochila.QuitarArandano();
            }
            else if (Mochila.comidactiva == 1 && Mochila.huevo > 0)
            {
                //Poner que cuando interactua con el arandano en el inventario haga lo siguiente:
                Vidas.ComerHuevo();
                Mochila.QuitarHuevo();
            }
            else if (Mochila.comidactiva == 2 && Mochila.pescado > 0)
            {
                //Poner que cuando interactua con el pescado en el inventario haga lo siguiente:
                Vidas.ComerPescao();
                Mochila.QuitarPescado();
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.tag == "Suelo")
        {
            suelo = true;
        }
    }
    public void OnTriggerEnter(Collider trigger)
    {
        Debug.Log("eNTER " + trigger.gameObject.tag);
        if (trigger.gameObject.tag == "Alimento")
        {
            objetoInteractuado = trigger.gameObject;
            alimentoin = true;
        }
        if (trigger.gameObject.tag == "Puerta")
        {
            objetoInteractuado = trigger.gameObject;
            puertain = true;
        }
        if (trigger.gameObject.tag == "Laberinto")
        {
            objetoInteractuado = trigger.gameObject;
            laberintoin = true;
        }
        if (trigger.gameObject.tag == "Awita")
        {
            objetoInteractuado = trigger.gameObject;
            aguain = true;
            //rotaciones = Quaternion.Euler(this.gameObject.transform.eulerAngles.x + 90, this.gameObject.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z);
            gameObject.transform.Rotate(45f, 0f, 0f);
        }
    }
    public void OnTriggerExit(Collider trigger)
    {
        Debug.Log("exit " + trigger.gameObject.tag);
        if (trigger.gameObject.tag == "Alimento")
        {
            alimentoin = false;
            objetoInteractuado = null;
        }
        if (trigger.gameObject.tag == "Puerta")
        {
            puertain = false;
            objetoInteractuado = null;
        }
        if (trigger.gameObject.tag == "Awita")
        {
            objetoInteractuado = null;
            aguain = false;
            transform.Rotate(-45f, 0f, 0f);
        }
    }
}
