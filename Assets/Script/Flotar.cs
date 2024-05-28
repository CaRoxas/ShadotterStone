using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotar : MonoBehaviour
{
    public Rigidbody rb;
    public float profundidadsumergida = 1f;
    public float cantidaddesplazada = 3f;
    private void FixedUpdate()
    {
        if (transform.position.y < 15)
        {
            float multiplicadordesplazamiento = Mathf.Clamp01(-transform.position.y / profundidadsumergida) * cantidaddesplazada;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * multiplicadordesplazamiento, 0f), ForceMode.Acceleration);
        } 
    }
}
