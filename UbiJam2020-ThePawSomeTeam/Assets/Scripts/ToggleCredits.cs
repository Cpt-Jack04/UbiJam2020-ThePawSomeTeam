using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCredits : MonoBehaviour
{
    public static Action showCredits = delegate {  };
    private bool triggere = false;
    
    public static void invokeCredits()
    {
        showCredits?.Invoke();
    }

    public void triggered()
    {
        if (!triggere)
        {
            GetComponent<Canvas>().enabled = true;
            triggere = true;
        }
        
    }
}
