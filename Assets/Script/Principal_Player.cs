using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Principal_Player : MonoBehaviour
{
    //En este script se gestiona todo del jugador, ya sea de su imput o tal, llamando eso s�, a los scripts respectivos de vida, contador...

    //PERSONAJE
    Rigidbody rb;
    PlayerInput playerinput;
    Animator animacion;

    //VARIABLES
    bool suelo = true;
    float velocidad = 4f;
    float gradosrot = 45f;
    public float fuerzaSalto = 45f;
    public float bajadaSalto = 70f;
    bool alimentoin = false;
    bool puertain = false;
    bool laberintoin = false;
    bool cansadita = false;
    bool empuja = false;
    float movx, movy;
    [HideInInspector]
    public bool aguain = false;
    [HideInInspector]
    public bool arandanocogido = false;
    [HideInInspector]
    public bool huevocogido = false;
    [HideInInspector]
    public bool pezcogido = false;


    //OBJETOS
    GameObject objetoInteractuado;
    public GameObject pantallafinal;
    public AudioSource ambiente;
    public CinemachineVirtualCamera camaraseguimiento;
    public CinemachineVirtualCamera camaralaberinto;
    public CinemachineVirtualCamera camaranadar;

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
        ambiente = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Rotaciones();
    }

    //Movimiento que hace el personaje
    void Movimiento()
    {
        /*/ESTA ES LA VERSI�N QUE SE MUEVA NORMAL EN X e Y
        rb.velocity = new Vector3(movAction.x * velocidad, rb.velocity.y, movAction.y * velocidad);*/

        /*/ESTA HACE QUE CUANDO SE GIRE SE MUEVA EN EL EJE LOCAL DEL PERSONAJE
        NOTA: TRANSFORM.FORWARD = ADELANTE EN LOCAL, FORWARD (SIN TRANSAFORM) = ADELANTE EN GLOBAL (EL MUNDO)*/

        Vector2 movAction = playerinput.actions["Move"].ReadValue<Vector2>();
      
        if ((movAction.y != 0 || movAction.x != 0) && !aguain && !cansadita)
        {
            Vector3 adelante = movAction.y * velocidad * transform.forward;
            Vector3 lado = movAction.x * velocidad * transform.right;
            Vector3 movimiento = adelante + lado;
            movimiento.y = rb.velocity.y;
            rb.velocity = movimiento;
            animacion.SetBool("SeMueve", true);
            animacion.SetFloat("Velocidad", movAction.y);
        }
        else
        {
            animacion.SetBool("SeMueve", false);
            animacion.SetFloat("Velocidad", movAction.y);
        }
        //EST� DENTRO DEL AGUA
        if ((movAction.y != 0 || movAction.x != 0) && aguain)
        {
            Vector3 adelante = movAction.y * velocidad * transform.up;
            Vector3 lado = movAction.x * velocidad * transform.right;
            transform.Rotate(0,0, -movAction.x * gradosrot * Time.deltaTime);
            Vector3 movimiento = adelante + lado;
            movimiento.y = rb.velocity.y;
            rb.velocity = movimiento;
            animacion.SetBool("Nada", true);
            camaranadar.Priority = 11;
            camaralaberinto.Priority = 10;
            camaraseguimiento.Priority = 10;
        }
        else if (aguain == false && laberintoin == false)
        {
            animacion.SetBool("Nada", false);
            camaranadar.Priority = 10;
            camaralaberinto.Priority = 10;
            camaraseguimiento.Priority = 11;

        }
        //EST� CANSADO
        if (Vidas.vidanow <= 0)
        {
            animacion.SetBool("SeDetiene",true);
            cansadita = true;
        }
        else
        {
            animacion.SetBool("SeDetiene", false);
            cansadita = false;
        }
    }

    public void Correr(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            velocidad *= 2;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            velocidad /= 2;
        }
    }
    //Rotaciones que hace la c�mara en el eje y para su desplazamiento
    private void Rotaciones()
    {
        if (!aguain)
        {
            Vector2 rotAction = playerinput.actions["TurnAround"].ReadValue<Vector2>();
            transform.Rotate(0,rotAction.x * gradosrot * Time.deltaTime,0);
        }
    }

    //Cambio de la c�mara al entrar en el agua y el laberinto para que se ponga arriba del personaje y tenga una`perspectiva mejor
    public void SaltoCamara(InputAction.CallbackContext context)
    {
        //NOTA: "laberintoin == true" ser�a como poner "laberintoin" solo :)
        if (context.phase == InputActionPhase.Performed && laberintoin) 
        {
            camaralaberinto.Priority = 11;
            camaraseguimiento.Priority = 10;
            //movx = Input.GetAxis("Horizontal");
            //movy = Input.GetAxis("Vetical");
        }
        else
        {
            camaralaberinto.Priority = 10;
            camaraseguimiento.Priority = 11;
        }
    }

    //A�adir fuerza de salto para su desplazamiento en vertical
    public void Salto(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && suelo)
        {
            suelo = false;
            animacion.SetBool("Saltar", true);
        }
        else
        {
            animacion.SetBool("Saltar", false);
        }
    }

    //Llamamos cuando termine la anticipaci�n en la animaci�n un evento para que en ese momento haga el salto y no antes
    public void SaltoAnimacion()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }

    //Llamamos en el final de la animaci�n un evento para que en ese momento haga a�ada la fuerza de peso hacia abajo
    public void BajadaTierra()
    {
        rb.AddForce(Vector3.down * bajadaSalto, ForceMode.Impulse);
    }

    //Hacemos las acciones de coger los alimentos y guardarlos en el inventario tambi�n abrir la puerta de la casa
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

    //A�adimos un retardo en la contabilizaci�n del alimento y es su destrucci�n, solo cuando ha hecho la animaci�n se muestra el alimento en el inventario y se destruye
    public void RetardoRecogerAlimento()
    {
        Destroy(objetoInteractuado);
        objetoInteractuado = null;
        Interfaz.MostrarAlimento();
    }

    //Hacemos que traslade por botones la elecci�n de los alimentos en el inventario hacia la derecha y que vuelva a la izquierda
    public void InventarioDerecha (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Mochila.ActivoDerecha();
        }
    }

    //Hacemos que traslade por botones la elecci�n de los alimentos en el inventario hacia la derecha y que vuelva a la derecha
    public void InventarioIzquierda (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Mochila.ActivoIzquierda();
        }
    }

    //Acci�n de comer seg�n est� en un alimento de la interfaz seleccionado y si su n�mero es mayor a 1, es decir haya algo en el alimento seleccionado
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

    //Retardo de pantalla final despu�s de colisionar con las piedras
    public void RetardoFinal()
    {
        Destroy(objetoInteractuado);
        pantallafinal.SetActive(true);
        Time.timeScale = 0;
        ambiente.mute = false;
    }

    //Colisiones de entrada
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            suelo = true;
        }
        if (collision.gameObject.tag == "Piedra")
        {
            animacion.SetBool("Gana", true);
        }
        if (collision.gameObject.tag == "Obst�culos")
        {
            empuja = true;
            animacion.SetBool("Empuja", true);
            objetoInteractuado = collision.gameObject;
        }
        if (collision.gameObject.tag == "Premio")
        {
            animacion.SetBool("Gana", true);
            Invoke("RetardoFinal", animacion.GetCurrentAnimatorStateInfo(0).length);
            objetoInteractuado = collision.gameObject;
        }
    }

    //Colisiones de salida
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obst�culos")
        {
            empuja = false;
            animacion.SetBool("Empuja", false);
            objetoInteractuado = null;
        }
    }

    //Triggers de entrada
    public void OnTriggerEnter(Collider trigger)
    {
        //Debug.Log("eNTER " + trigger.gameObject.tag);
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
    }

    //Triggers de salida
    public void OnTriggerExit(Collider trigger)
    {
        //Debug.Log("exit " + trigger.gameObject.tag);
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
        if (trigger.gameObject.tag == "Laberinto")
        {
            objetoInteractuado = null;
            laberintoin = false;
        }
    }
}
