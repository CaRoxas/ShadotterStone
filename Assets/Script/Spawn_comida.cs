using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_comida : MonoBehaviour
{
    //OBJETOS
    public GameObject arandillos;
    public GameObject huevillos;
    public GameObject pescaillos;

    //SCRIPTS
    public Principal_Player jugador;

    //VARIABLES
    public Vector3 empezar;
    float maxaran = 50;
    float maxhue = 30;
    float maxpez = 10;
    float cantidadaran = 0;
    float cantidadhue = 0;
    float cantidadpez = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cantidadaran < maxaran)
        {
            SpawnArandano();
            cantidadaran++;
            if (jugador.arandanocogido == true)
            {
                cantidadaran--;
                jugador.arandanocogido = false;
            }
        }
        //Debug.Log(cantidadaran);
        if (cantidadhue < maxhue)
        {
            SpawnHuevo();
            cantidadhue++;
            if (jugador.huevocogido == true)
            {
                cantidadhue--;
                jugador.huevocogido = false;
            }
        }
        if (cantidadpez  < maxpez)
        {
            SpawnPez();
            cantidadpez++;
            if (jugador.pezcogido == true)
            {
                cantidadpez--;
                jugador .pezcogido = false;
            }
        }
    }
    void SpawnArandano()
    {
        int posx = Random.Range(190, 500);
        int posz = Random.Range(440, 890);
        empezar = new Vector3(posx, 20.12f, posz);
        GameObject comidauno = GameObject.Instantiate(arandillos,empezar,Quaternion.identity);
    }
    void SpawnHuevo()
    {
        int posx = Random.Range(190, 500);
        int posz = Random.Range(440, 890);
        empezar = new Vector3(posx, 20.5f, posz);
        GameObject comidados = GameObject.Instantiate(huevillos, empezar, Quaternion.identity);
    }
    void SpawnPez()
    {
        int posx = Random.Range(73, 125);
        int posz = Random.Range(311, 422);
        empezar = new Vector3(posx, 15.7f, posz);
        GameObject comidauno = GameObject.Instantiate(pescaillos, empezar, Quaternion.identity);
    }
}
