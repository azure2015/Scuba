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
    [SerializeField] TextMeshProUGUI lives;

    private int TotalCollectables;
    private int Collected = 0;
    void Start()
    {
        TotalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        collectables.text = "Collected : " + TotalCollectables + " / 0";
        lives.text = $"Lives : {FindObjectOfType<GameSession>().GetLives()}";
        timerSlider.maxValue = timer.GetTimer(); 

    }

    void Update()
    {
        timerSlider.value = timer.GetTimer();
        
    }

    public void ItemCollected()
    {
        Collected++;
        collectables.text = $"Collected : {TotalCollectables} / {Collected}";
    }

    public void PlayerLivesUpdate()
    {
        lives.text = $"Lives : {FindObjectOfType<GameSession>().GetLives()}";
    }
    
}
