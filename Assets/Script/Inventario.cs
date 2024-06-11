using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //OBJECTOS
    public int arandano = 0;
    public int huevo = 0;
    public int pescado = 0;
    public int comidactiva = 0;

    //SCRIPTS
    public Interfaz Interfaz;
    public Guardado_datos guardado;

    //Para hacer que cargue el inventario en un singleton
    public static Inventario singleton;
    void Awake()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            guardado.CargarArandanos();
            guardado.CargarHuevos();
            guardado.CargarPeces();
            //DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }
    // Update is called once per frame


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
