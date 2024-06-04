using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Nadar : MonoBehaviour
{
    //SCRIPTS
    public Principal_Player jugador;
    public Flotar flotacion;

    //GAMEOBJECT
    public GameObject Diva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider trigger)
    {
        Debug.Log("ENTER " + trigger.gameObject.tag);
        if (trigger.gameObject.tag == "Awita")
        {
            jugador.aguain = true;
            Diva.transform.Rotate(90f, 0f, 0f);
            //flotacion.privalturaOlas = 3.5f;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            jugador.aguain = false;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            jugador.aguain = true;
        }
    }
    public void OnTriggerExit(Collider trigger)
    {
        Debug.Log("exit " + trigger.gameObject.tag);
        if (trigger.gameObject.tag == "Awita")
        {
            jugador.aguain = false;
            Diva.transform.Rotate(-90f, 0f, 0f);
            //flotacion.privalturaOlas = 0f;
        }
    }
}