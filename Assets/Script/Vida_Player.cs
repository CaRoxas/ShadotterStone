using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Vida_Player : MonoBehaviour
{
    //VARIABLES
    public float vidamax = 5;
    public float vidanow = 5;

    //OBJETOS
    public GameObject Pescado;
    public GameObject Arandano;
    public GameObject Huevo;
    public Image BarraVida;

    //SCRIPTS

    void Start()
    {

    }

    void Update()
    {
        BarraVida.fillAmount = vidanow / vidamax;
    }
    public void ComerArandano()
    {
        vidanow = vidanow + 0.5f;
    }
    public void ComerHuevo()
    {
        vidanow = vidanow + 1;
    }
    public void ComerPescao()
    {
        vidanow = vidanow + 2;
    }
    public void PasaTiempo()
    {
        //vidanow = vidanow - 0.5f;
    }

}
