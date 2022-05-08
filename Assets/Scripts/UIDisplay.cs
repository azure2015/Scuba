using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider timerSlider;
    [SerializeField] GameTimer timer;
    void Start()
    {
        timerSlider.maxValue = timer.GetTimer(); ;
    }

    void Update()
    {
        timerSlider.value = timer.GetTimer();
    }
}
