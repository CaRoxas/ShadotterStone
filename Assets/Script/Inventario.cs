using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //OBJECTOS
    public int arandano = 0;
    public int huevo = 0;
    public int pescado = 0;

    // activa = 0 -> arandano
    // activa = 1 -> huevo
    // activa = 2 -> pescado
    public int comidactiva = 0;

    public Interfaz Interfaz;

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
        comidactiva++;
        if (comidactiva > 2)
        {
            comidactiva = 0;
        }
        Interfaz.AlimentoSeleccionado(comidactiva);

    }
    public void ActivoIzquierda()
    {
        comidactiva--;
        if(comidactiva < 0)
        {
            comidactiva = 2;
        }
        Interfaz.AlimentoSeleccionado(comidactiva);
    }
}
