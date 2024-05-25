using Microsoft.Unity.VisualStudio.Editor;
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

    //IMÁGENES
    public GameObject aranfoto;
    public GameObject huefoto;
    public GameObject pezfoto;

    //SCRIPTS
    public Inventario inventario;
    public Principal_Player jugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AumentoAlimento();
        AlimentoSeleccionado();
    }
    public void AumentoAlimento()
    {
        aranum.text = "x " + inventario.NumeroArandanos().ToString();
        huenum.text = "x " + inventario.NumeroHuevos().ToString();
        peznum.text = "x " + inventario.NumeroPescados().ToString();
    }
    public void AlimentoSeleccionado()
    {
        if (inventario.comidactiva == 0)
        {
            aranfoto.SetActive(true);
            huefoto.SetActive(false);
            pezfoto.SetActive(false);
        }
        else if (inventario.comidactiva == 1)
        {
            aranfoto.SetActive(false);
            huefoto.SetActive(true);
            pezfoto.SetActive(false);
        }
        else if (inventario.comidactiva == 2)
        {
            aranfoto.SetActive(false);
            huefoto.SetActive(false);
            pezfoto.SetActive(true);
        }
    }

}
