using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider timerSlider;
    [SerializeField] GameTimer timer;

    [SerializeField] TextMeshProUGUI collectables;

    private int TotalCollectables;
    private int Collected = 0;
    void Start()
    {
        TotalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        collectables.text = "Collected : " + TotalCollectables + " / 0";
        timerSlider.maxValue = timer.GetTimer(); 

    }

    void Update()
    {
        timerSlider.value = timer.GetTimer();
        collectables.text = $"Collected : {TotalCollectables} / {Collected}";
    }

    public void ItemCollected()
    {
        Collected++;
    }
    
}
