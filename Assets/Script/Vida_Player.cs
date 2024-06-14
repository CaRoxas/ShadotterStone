using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Vida_Player : MonoBehaviour
{
    //VARIABLES
    public float vidamax = 50;
    public float vidanow = 50;

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
        if (vidanow > vidamax)
        {
            vidanow = vidamax;
        }
        if (vidanow <= 0)
        {
            vidanow = 0;
        }
    }
    public void ComerArandano()
    {
        vidanow = vidanow + 1;
    }
    public void ComerHuevo()
    {
        vidanow = vidanow + 2;
    }
    public void ComerPescao()
    {
        vidanow = vidanow + 5;
    }
}
