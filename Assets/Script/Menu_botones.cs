using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_botones : MonoBehaviour
{
    //VARIABLES
    public int botonactivo = 0;

    //GAMEOBJECT
    public GameObject menucreditos;
    public GameObject menucontroles;
    public GameObject botonContinuar;

    //ELEMENTOS DE UNITY
    PlayerInput input;


    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Este botón lo llamamos en un onclick del propio continuar para que empiece la partida por donde se dejó
    public void BotonContinuar(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }

    //Este botón lo llamamos en onclick en el propio de nuevo juego para empezar la partida desde 0
    public void BotonNuevoJuego(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }

    //Activa el menú de los controles con su imagen con la opción onclick
    public void BotonControlesOn()
    {
        menucontroles.SetActive(true);
    }

    //Activa el menú de los créditos con su imagen con la opción onclick
    public void BotonCreditosOn()
    {
        menucreditos.SetActive(true);
    }

    /*/Está opción hace que que se desactive en menú controles al pulsar el botón atrás y hace que el actual botón seleccionado (que sería el controles)
    se deseleccione y pase al botón primero del menú principal en este caso el continuar*/
    public void BotonControlesOff()
    {
        menucontroles.SetActive(false);
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(botonContinuar);
    }

    /*/Está opción hace que que se desactive en menú créditos al pulsar el botón atrás y hace que el actual botón seleccionado (que sería el de créditos)
    se deseleccione y pase al botón primero del menú principal en este caso el continuar*/
    public void BotonCreditosOff()
    {
        menucreditos.SetActive(false);
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(botonContinuar);
    }

    //Aquí activa los métodos de arriba pulsando el botón físicamente (el ratón, mando o teclado) lo bueno sería separarlo con un bool
    public void BotonCancelar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) 
        {
            BotonCreditosOff();
            BotonControlesOff();
        }
    }
}
