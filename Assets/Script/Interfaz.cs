using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interfaz : MonoBehaviour
{
    //TEXTO
    public TMP_Text aranum;
    public TMP_Text huenum;
    public TMP_Text peznum;

    //SCRIPTS
    public Inventario inventario;
    public Vida_Player vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AumentoAlimento();
    }
    public void AumentoAlimento()
    {
        aranum.text = "x " + inventario.NumeroArandanos().ToString();
        huenum.text = "x " + inventario.NumeroHuevos().ToString();
        peznum.text = "x " + inventario.NumeroPescados().ToString();
    }
    public void AlimentoSeleccionado()
    {
        
    }

}
