using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //OBJECTOS
    public int arandano = 0;
    public int huevo = 0;
    public int pescado = 0;

    //¿cual está activo?
    // activo = 0 -> ara
    // actio = 1 -> huevo
    // activo = 2 -> pescado
    public float activo = 0;

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
