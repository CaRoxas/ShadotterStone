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
    float maxpez = 20;
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
        if (cantidadaran <= maxaran)
        {
            SpawnArandano();
            cantidadaran++;
            if (jugador.comidacogida == true)
            {
                cantidadaran--;
                jugador.comidacogida = false;
            }
        }
        Debug.Log(cantidadaran);
    }
    void SpawnArandano()
    {
        int posx = Random.Range(500, 599);
        int posz = Random.Range(500, 55);
        empezar = new Vector3(posx, 0, posz);
        GameObject comidauno = GameObject.Instantiate(arandillos,empezar,Quaternion.identity);
    }
}
