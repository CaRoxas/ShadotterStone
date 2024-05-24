using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    //VARIABLES
    float rotasol = 2f;
    float pasatiempo = 0.5f;
    float tiempo;
    //SCRIPTS
    public Vida_Player vidilla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        transform.Rotate(0, rotasol * Time.deltaTime, 0);
        vidilla.vidanow -= pasatiempo;
    }
}
