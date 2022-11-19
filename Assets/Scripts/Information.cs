using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Information : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textInfo;

    float timerInfo = 1.5f;
    bool exit; 
    // Start is called before the first frame update
    void Start()
    {
        exit = false;

        textInfo.text = "Level " + FindObjectOfType<GameSession>().GetCurrentLevel();

    }

    // Update is called once per frame
    void Update()
    {
        if(exit) return;

        timerInfo -= Time.deltaTime;
        if(timerInfo <0)
        {
            textInfo.text= "";
            exit = true;
        }
    }
}
