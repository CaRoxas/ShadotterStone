using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casita : MonoBehaviour
{
    public Animator animatione;
    Collider colisionpuerta;
    // Start is called before the first frame update
    void Start()
    {
        colisionpuerta = GetComponent<Collider>();
        colisionpuerta.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AnimacionPuerta()
    {
        animatione.SetBool("Abril", true);
        colisionpuerta.enabled = false;
    }
}
