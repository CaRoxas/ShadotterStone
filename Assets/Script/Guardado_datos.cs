using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Guardado_datos
{
    //VARIABLES
    public int arandanos;
    public int huevos;
    public int peces;

    //SCRIPTS
    
    public Guardado_datos (Inventario comida)
    {
        arandanos = comida.arandano;
        huevos = comida.huevo;
        peces = comida.pescado;

    }
    void GuardarAlimentos(int score)
    {
        PlayerPrefs.SetInt("arandanos", score);
        PlayerPrefs.SetInt("huevos", score);
        PlayerPrefs.SetInt("huevos", score);
        PlayerPrefs.Save();
    }
    void CargarAlimentos()
    {

    }
}
