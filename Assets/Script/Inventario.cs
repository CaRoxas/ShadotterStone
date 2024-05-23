using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //OBJECTOS
    int arandano = 0;
    int huevo = 0;
    int pescado = 0;

    //
    //¿cual está activo?
    // activa = 0 -> arandano
    // activa = 1 -> huevo
    // activa = 2 -> pescado
    public static float comidactiva = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int NumeroArandanos()
    {
        return arandano;
    }
    public int NumeroHuevos() 
    {
        return huevo;
    }
    public int NumeroPescados()
    {
        return pescado;
    }

    public void GuadarArandano() 
    {
        arandano++;
    }
    public void GuardarHuevo()
    {
        huevo++;
    }
    public void GuardarPescado()
    {
        pescado++;
    }
    public void QuitarArandano()
    {
        arandano--;
        comidactiva = 0;
    }
    public void QuitarHuevo()
    {
        huevo--;
        comidactiva = 1;
    }
    public void QuitarPescado()
    {
        pescado--;
        comidactiva = 2;
    }
    public void ActivoDerecha()
    {
        if (comidactiva >= 3)
        {
            comidactiva = 0;
        }
    }
    public void ActivoIzquierda()
    {
        if (comidactiva <= 0)
        {
            comidactiva = 3;
        }
    }
}
