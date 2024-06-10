using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu_pausa : MonoBehaviour
{
    public GameObject pausita;
    bool pausa = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausa(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && !pausa)
        {
            Time.timeScale = 0;
            pausita.SetActive(true);
            pausa = true;
        }
    }
    public void NoPausa(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && pausa)
        {
            Time.timeScale = 1;
            pausita.SetActive(false);
            pausa = false;
        }
    }
}
