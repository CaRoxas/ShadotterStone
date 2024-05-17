using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //OBJECTOS
    int arandano = 0;
    int huevo = 0;
    int pescado = 0;

    //¿cual está activo?
    // activo = 0 -> arandano
    // actio = 1 -> huevo
    // activo = 2 -> pescado
    //float activo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GuadarArandano() 
    {
        arandano++;
        Debug.Log(arandano);
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
    }
    public void QuitarHuevo()
    {
        huevo--;
    }
    public void QuitarPescado()
    {
        pescado--;
    }
}
