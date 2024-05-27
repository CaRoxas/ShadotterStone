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
        aranfoto.SetActive(true);
        huefoto.SetActive(false);
        pezfoto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarAlimento()
    {
        aranum.text = "x " + inventario.NumeroArandanos().ToString();
        huenum.text = "x " + inventario.NumeroHuevos().ToString();
        peznum.text = "x " + inventario.NumeroPescados().ToString();
    }
    public void AlimentoSeleccionado(int comidactiva)
    {
        //la comidactiva actúa como el valor que necesita ser llamando solo en el inventario, sin necesidad de llamarlo aquí como +
        //"inventario.comidaactiva == X", de esta forma tendría que estar en el update siempre preguntando si está en ese vagón del inventario
        if (comidactiva  == 0)
        {
            aranfoto.SetActive(true);
            huefoto.SetActive(false);
            pezfoto.SetActive(false);
        }
        else if (comidactiva == 1)
        {
            aranfoto.SetActive(false);
            huefoto.SetActive(true);
            pezfoto.SetActive(false);
        }
        else if (comidactiva == 2)
        {
            aranfoto.SetActive(false);
            huefoto.SetActive(false);
            pezfoto.SetActive(true);
        }
    }

}
