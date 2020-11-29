using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameFunction : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            QuitApplication();
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
