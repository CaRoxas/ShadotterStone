using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNoche_Tiempo : MonoBehaviour
{
    float rotasol = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotasol * Time.deltaTime, 0);
    }
}
