using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tiempo : MonoBehaviour
{
    //VARIABLES
    float rotasol = 2f;
    [HideInInspector]
    public float timer = 50;

    //SCRIPTS
    public Vida_Player vidilla;
    public Principal_Player jugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotasol * Time.deltaTime, 0);
        PasaTiempo();
    }
    void PasaTiempo()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (vidilla.vidanow > 0)
            {
                vidilla.vidanow = vidilla.vidanow - 1;
                timer = 50;
            }
        }
        //Debug.Log(vidilla.vidanow);
    }
    /*/void Noche()
    {
        if (transform.eulerAngles.z >= 49)
        {
            jugador.sonidoambiente.volume = 0.3f;
        }
        else
        {
            jugador.sonidoambiente.volume = 1;
        }
    }*/
}
