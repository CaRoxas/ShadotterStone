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

    //Este bot�n lo llamamos en un onclick del propio continuar para que empiece la partida por donde se dej�
    public void BotonContinuar(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }

    //Este bot�n lo llamamos en onclick en el propio de nuevo juego para empezar la partida desde 0
    public void BotonNuevoJuego(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }

    //Activa el men� de los controles con su imagen con la opci�n onclick
    public void BotonControlesOn()
    {
        menucontroles.SetActive(true);
    }

    //Activa el men� de los cr�ditos con su imagen con la opci�n onclick
    public void BotonCreditosOn()
    {
        menucreditos.SetActive(true);
    }

    /*/Est� opci�n hace que que se desactive en men� controles al pulsar el bot�n atr�s y hace que el actual bot�n seleccionado (que ser�a el controles)
    se deseleccione y pase al bot�n primero del men� principal en este caso el continuar*/
    public void BotonControlesOff()
    {
        menucontroles.SetActive(false);
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(botonContinuar);
    }

    /*/Est� opci�n hace que que se desactive en men� cr�ditos al pulsar el bot�n atr�s y hace que el actual bot�n seleccionado (que ser�a el de cr�ditos)
    se deseleccione y pase al bot�n primero del men� principal en este caso el continuar*/
    public void BotonCreditosOff()
    {
        menucreditos.SetActive(false);
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(botonContinuar);
    }

    //Aqu� activa los m�todos de arriba pulsando el bot�n f�sicamente (el rat�n, mando o teclado) lo bueno ser�a separarlo con un bool
    public void BotonCancelar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) 
        {
            BotonCreditosOff();
            BotonControlesOff();
        }
    }
}
