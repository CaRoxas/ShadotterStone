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
    float gradosrot = 20f;
    float fuerzaSalto = 4f;
    bool alimentoin = false;
    bool puertain = false;

    //OBJETOS
    GameObject objetoInteractuado;

    //SCRIPTS
    public Vida_Player Vidas;
    public Inventario Mochila;
    public Casita Casa;

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
        if (movAction.y > 0 || movAction.x >0)
        {
            animacion.SetBool("SeMueve", true);
            animacion.SetFloat("Velocidad", movAction.y);
        }
        else
        {
            animacion.SetBool("SeMueve", false);
            animacion.SetFloat("Velocidad", movAction.y);
        }
        // MODIFICAR EL PARAMETRO VELOCIDAD DEL ANIMATOR

    }
    private void Rotaciones()
    {
        Vector2 rotAction = playerinput.actions["TurnAround"].ReadValue<Vector2>();
        transform.Rotate(0,rotAction.x * gradosrot * Time.deltaTime,0);
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
    }
    public void CogerComidayGuardar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && alimentoin)
        {
            if (objetoInteractuado.name.Contains("Food_Fish"))
            {
                Debug.Log("pescaito cogido");
                Mochila.GuardarPescado();
            }
            if (objetoInteractuado.name.Contains("Food_Egg"))
            {
                Debug.Log("huevo cogido");
                Mochila.GuardarHuevo();
            }
            if (objetoInteractuado.name.Contains ("Food_Blueberry"))
            {
                Debug.Log("arandanito cogido");
                Mochila.GuadarArandano();
            }
            animacion.SetTrigger("Recoger");
            Destroy(objetoInteractuado, animacion.GetCurrentAnimatorStateInfo(0).length);
            objetoInteractuado = null;
            alimentoin = false;
        }
        /*/if (context.phase == InputActionPhase.Performed && puertain)
        {
            Casa.AnimacionPuerta();
            puertain = false;
        }*/
    }
    public void CambiarComida (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {

        }
    }
    public void Comer(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //Poner que cuando interactua con el huevo en el inventario haga lo siguiente:
            Vidas.ComerHuevo();
            Mochila.QuitarHuevo();
            //Poner que cuando interactua con el pescado en el inventario haga lo siguiente:
            Vidas.ComerPescao();
            Mochila.QuitarPescado();
            //Poner que cuando interactua con el arandano en el inventario haga lo siguiente:
            Vidas.ComerArandano();
            Mochila.QuitarArandano();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Suelo")
        {
            suelo = true;
        }
    }
    public void OnTriggerEnter(Collider trigger)
    {
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
    }

    public void OnTriggerExit(Collider trigger)
    {
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
    }
}
