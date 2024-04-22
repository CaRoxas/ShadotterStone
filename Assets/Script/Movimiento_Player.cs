using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento_Player : MonoBehaviour
{
    //En este script se gestiona todo del jugador, ya se de su imput o tal, llamando eso sí, a los scripts respectivos de vida, contador...
    //PERSONAJE
    Rigidbody rb;
    PlayerInput playerinput;

    //VARIABLES
    bool suelo = true;
    float velocidad = 2f;
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
        Vector2 movAction = playerinput.actions["Move"].ReadValue<Vector2>();
        rb.velocity = new Vector3(movAction.x * velocidad, rb.velocity.y, movAction.y * velocidad);
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
            
            Debug.Log("Alimento cogido, next");
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
