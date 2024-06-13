using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_pausa : MonoBehaviour
{
    //VARIABLES
    bool pausa = false;

    //ELEMENTOS UNITY
    public GameObject menupausa;
    public Principal_Player jugador;
    public GameObject botonguardarsalir;
    public GameObject botonsalir;
    public AudioSource sonidopausa;

    //SCRIPTS
    public Guardado_datos guardado;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausa(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (!pausa)
            {
                //Este evento hace que al pulsar el botón abra el menú y el botón selecionado sea el de guardar y salir el mismo evento que llamamos en el menu principal
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(botonguardarsalir);

                sonidopausa.Play();
                Time.timeScale = 0;
                menupausa.SetActive(true);
                pausa = true;
                jugador.sonidoambiente.Pause();
            }
            else
            {
                Time.timeScale = 1;
                menupausa.SetActive(false);
                pausa = false;
                jugador.sonidoambiente.Play();
            }
        }
    }
    public void SalirYGuardar()
    {
        guardado.GuardarAlimentos();
        Time.timeScale = 1;
        SceneManager.LoadScene("Shadotter_menu");
    }
    public void Salir()
    {
        SceneManager.LoadScene("Shadotter_menu");
        Time.timeScale = 1;
        guardado.BorrarAlimentos();
    }
}
