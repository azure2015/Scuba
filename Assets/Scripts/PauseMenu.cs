using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        print("pause");
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        print("start");
    }
}

