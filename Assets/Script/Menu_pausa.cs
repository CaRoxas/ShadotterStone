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
    bool botonseleccionado = false;

    //ELEMENTOS UNITY
    public GameObject pausita;
    public Principal_Player jugador;
    public GameObject botonguardarsalir;
    public GameObject botonsalir;
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
            //boton.setselectec = true
            if (pausa)
            {
                Time.timeScale = 1;
                pausita.SetActive(false);
                pausa = false;
                jugador.ambiente.Play();
            }
            else
            {
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(botonguardarsalir);

                Time.timeScale = 0;
                pausita.SetActive(true);
                pausa = true;
                jugador.ambiente.Pause();
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

    }
}
