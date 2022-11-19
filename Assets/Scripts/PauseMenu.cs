using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    // bool pauseGame = false;
    // float timeCounter;
    // int tapCount;
  //  int clickCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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

