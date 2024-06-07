using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_botones : MonoBehaviour
{
    public GameObject creditos;
    public GameObject controles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonContinuar(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }
    public void BotonNuevoJuego(string Shadotter_juego)
    {
        SceneManager.LoadScene(Shadotter_juego);
    }
    public void BotonControles()
    {
        controles.SetActive(true);
    }
    public void BotonCreditos()
    {
        creditos.SetActive(true);
    }
}
