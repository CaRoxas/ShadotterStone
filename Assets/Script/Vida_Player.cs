using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vida_Player : MonoBehaviour
{
    //VARIABLES
    float vida = 5;

    //OBJETOS
    public GameObject Pescado;
    public GameObject Arandano;
    public GameObject Huevo;

    //SCRIPTS

    void Start()
    {

    }

    void Update()
    {

    }
    public void ComerArandano()
    {
        vida = vida + 0.5f;
    }
    public void ComerHuevo()
    {
        vida = vida + 1;
    }
    public void ComerPescao()
    {
        vida = vida + 2;
    }
    public void PasaTiempo()
    {
        vida = vida - 0.5f;
    }

}
