using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] public float resetTime;
    [SerializeField] float bonusTime;
    public bool isActive = true;

    
    // Update is called once per frame

    void Update()
    {
        if(isActive)
        {
            currentTime -= (Time.deltaTime- bonusTime);
        }
    }

    public int GetTimer()
    {
        return (int)currentTime;
    }

    public void resetTimer()
    {
        currentTime= resetTime;
    }

    public void TimerControl(bool state)
    {
        isActive = state;
    }
}
