using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    //VARIABLES
    float rotasol = 2f;
    float pasatiempo = 0.5f;
    float timer = 10;

    //SCRIPTS
    public Vida_Player vidilla;

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
                timer = 10;
            }
        }
        //Debug.Log(vidilla.vidanow);
    }
}
