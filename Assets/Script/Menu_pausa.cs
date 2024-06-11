using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu_pausa : MonoBehaviour
{
    //VARIABLES
    bool pausa = false;

    //ELEMENTOS UNITY
    public GameObject pausita;
    public Principal_Player jugador;

    //SCRIPTS
    public Guardado_datos guardado;

    // Start is called before the first frame update
    void Start()
    {
        jugador.ambiente.Play();
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
                Time.timeScale = 0;
                pausita.SetActive(true);
                pausa = true;
                jugador.ambiente.Pause();
            }
           
        }
    }
    public void SalirYGuardar()
    {

    }
    public void Salir()
    {

    }
}
