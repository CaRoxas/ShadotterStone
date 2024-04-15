using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento_Player : MonoBehaviour
{
    //PERSONAJE
    Rigidbody rb;
    PlayerInput playerinput;

    //VARIABLES
    bool suelo = true;
    float velocidad = 3f;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       playerinput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            suelo = true;
        }
    }
    void Movimiento()
    {
        Vector2 movAction = playerinput.actions["Move"].ReadValue<Vector2>();
        rb.velocity = new Vector3(movAction.x * velocidad, rb.velocity.y, movAction.y * velocidad);
    }
    void Salto(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            suelo = false;
        }
    }
}
