using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento_Player : MonoBehaviour
{
    //En este script se gestiona todo del jugador, ya sea de su imput o tal, llamando eso sí, a los scripts respectivos de vida, contador...

    //PERSONAJE
    Rigidbody rb;
    PlayerInput playerinput;

    //VARIABLES
    bool suelo = true;
    float velocidad = 4f;
    float gradosrot = 20f;
    float fuerzaSalto = 4f;
    bool alimentoin = false;

    //OBJETOS
    GameObject objetoInteractuado;

    //SCRIPTS
    public Vida_Player Vidas;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       playerinput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Rotaciones();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            suelo = true;
        }
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
    }
    private void Rotaciones()
    {
        Vector2 rotAction = playerinput.actions["TurnAround"].ReadValue<Vector2>();
        //Debug.Log(rotAction.ToString());
        transform.Rotate(0,rotAction.x * gradosrot * Time.deltaTime,0);
    }
    public void Salto(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && suelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            suelo = false;
        }
    }
    //AQUI GUARDAMOS LA COMIDA EN EL INVENTARIO CUANDO CHOCAMOS CON ELLA
    public void CogerComidayGuardar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && alimentoin)
        {
            //Guardar en inventario y añadir imagen en el menu
            
            if (objetoInteractuado.name.Contains("Food_Fish"))
            {
                Debug.Log("pescaito cogido");
            }
            if (objetoInteractuado.name.Contains("Food_Egg"))
            {
                Debug.Log("huevo cogido");
            }
            if (objetoInteractuado.name == "Food_Blueberry")
            {
                Debug.Log("arandanito cogido");
            }
            Destroy(objetoInteractuado);
            // inventario.anyadircomida
            // vida_player.anyadirvida
            // uimanager.cambiarloquesea
            objetoInteractuado = null;
            alimentoin = false;

        }
    }
    public void ComerComida(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vidas.Comer();
        }
    }
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Alimento")
        {
            objetoInteractuado = trigger.gameObject;
            alimentoin = true;
 
        }
    }

    public void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Alimento")
        {
            alimentoin = false;
            objetoInteractuado = null;
        }
    }
}
