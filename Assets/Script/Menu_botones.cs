using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_botones : MonoBehaviour
{
    //VARIABLES
    public int botonactivo = 0;

    //GAMEOBJECT
    public GameObject menucreditos;
    public GameObject menucontroles;
    public GameObject continu3d;
    public GameObject nuevo3d;
    public GameObject credit3d;
    public GameObject control3d;

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
    public void BotonContinuar(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }
    public void BotonNuevoJuego(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }
    public void BotonControlesOn()
    {
        menucontroles.SetActive(true);
    }
    public void BotonCreditosOn()
    {
        menucreditos.SetActive(true);
    }
    public void BotonControlesOff()
    {
        menucontroles.SetActive(false);
    }
    public void BotonCreditosOff()
    {
        menucreditos.SetActive(false);
    }
    public void ActivoArriba()
    {
        botonactivo++;
        if (botonactivo > 3)
        {
            botonactivo = 0;
        }
        BotonSeleccionado(botonactivo);
    }
    public void ActivoAbajo()
    {
        botonactivo--;
        if (botonactivo < 0)
        {
            botonactivo = 3;
        }
        BotonSeleccionado(botonactivo);
    }
    public void BotonSeleccionado(int botonactivo)
    {
        if (botonactivo == 0)
        {
            continu3d.SetActive(true);
            nuevo3d.SetActive(false);
            control3d.SetActive(false);
            credit3d.SetActive(false);
        }
        else if (botonactivo == 1)
        {
            continu3d.SetActive(false);
            nuevo3d.SetActive(true);
            control3d.SetActive(false);
            credit3d.SetActive(false);
        }
        else if (botonactivo == 2)
        {
            continu3d.SetActive(false);
            nuevo3d.SetActive(false);
            control3d.SetActive(true);
            credit3d.SetActive(false);
        }
        else if (botonactivo == 3)
        {
            continu3d.SetActive(false);
            nuevo3d.SetActive(false);
            control3d.SetActive(false);
            credit3d.SetActive(true);
        }
    }
    public void SwitchCurrentActionMap()
    {
        input.SwitchCurrentActionMap("Menu");
    }
}
