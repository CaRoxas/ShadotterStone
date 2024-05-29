using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Flotar : MonoBehaviour
{
    //Variables
    public float Bajoaguadrag = 3f;
    public float BajoaguaAngulardrag = 1f;
    public float Airedrag = 0f;
    public float Aireangulardrag = 0.05f;
    public float fuerzaFlotacion = 15f;
    public float alturaOlas = 0f;

    bool underwater;

    //Componentes
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float diferencia = transform.position.y - alturaOlas;
        if (diferencia < 14)
        {
            rb.AddForceAtPosition(Vector3.up * fuerzaFlotacion * Mathf.Abs(diferencia), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;
            }
        }
        else if (underwater)
        {
            underwater = false;
        }
    }

    void SwitchState(bool estaBajoagua)
    {
        if (estaBajoagua)
        {
            rb.drag = Bajoaguadrag;
            rb.angularDrag = BajoaguaAngulardrag;
        }
        else
        {
            rb.drag = Airedrag;
            rb.angularDrag = Aireangulardrag;
        }
    }



    //SHOUTOUT V.A. - Indie Dev
}
