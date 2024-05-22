using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_comida : MonoBehaviour
{
    //OBJETOS
    public GameObject arandillos;
    public GameObject huevillos;
    public GameObject pescaillos;

    //VARIABLES
    public Vector3 empezar;
    bool maximo;
    float cantidadaran = 50;
    float cantidadhue = 30;
    float cantidadpez = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maximo == false)
        {
            SpawnArandano();
        }
        else
        {
            if (cantidadaran <= 50) 
            {
                SpawnArandano();
            }
            else
            {
                maximo = false;
            }
        }
    }
    void SpawnArandano()
    {
        int posx = Random.Range(500, 599);
        int posz = Random.Range(500, 55);
        empezar = new Vector3(posx, 0, posz);
        GameObject comidauno = GameObject.Instantiate(arandillos,empezar,Quaternion.identity);
    }
}
