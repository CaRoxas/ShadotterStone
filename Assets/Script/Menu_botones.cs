using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    // Start is called before the first frame update
    void Start()
    {
        
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

    }
    public void ActivoAbajo()
    {
        botonactivo--;
        if (botonactivo < 0)
        {
            botonactivo = 3;
        }
    }
}
