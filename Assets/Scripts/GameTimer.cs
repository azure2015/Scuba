using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] public float resetTime;
    [SerializeField] float bonusTime;
    public bool isActive;

    
    // Update is called once per frame

    void Update()
    {
        currentTime -= (Time.deltaTime- bonusTime);
    }

    public int GetTimer()
    {
        return (int)currentTime;
    }

    public void resetTimer()
    {
        currentTime= resetTime;
    }
}
