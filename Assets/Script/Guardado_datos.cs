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


    public void GuardarAlimentos()
    {
        PlayerPrefs.SetInt("arandanos", Inventario.singleton.arandano);
        PlayerPrefs.SetInt("huevos", Inventario.singleton.huevo);
        PlayerPrefs.SetInt("pescado", Inventario.singleton.pescado);
        PlayerPrefs.Save();
    }
    public void BorrarAlimentos()
    {
        PlayerPrefs.SetInt("arandanos", 0);
        PlayerPrefs.SetInt("huevos", 0);
        PlayerPrefs.SetInt("pescado", 0);
        PlayerPrefs.Save();
    }
    public void CargarArandanos()
    {
        int arandanoguardado = PlayerPrefs.GetInt("arandanos", 0);
        Inventario.singleton.arandano = arandanoguardado;
    }
    public void CargarHuevos()
    {
        int huevosguardado = PlayerPrefs.GetInt("huevos", 0);
        Inventario.singleton.huevo = huevosguardado;
    }
    public void CargarPeces()
    {
        int pecesguardado = PlayerPrefs.GetInt("peces", 0);
        Inventario.singleton.pescado = pecesguardado;
    }
}
