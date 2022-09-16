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
        collectables.text = "Collected : " +  " 0 / " + TotalCollectables;
        PlayerLivesUpdate();
        timerSlider.maxValue = timer.GetTimer(); 

    }

    void Update()
    {
        timerSlider.value = timer.GetTimer();
    }

    public void ItemCollected()
    {
        Collected++;
        collectables.text = $"Collected : {Collected} / {TotalCollectables}";
        if(IsEverythingCollected())
        {
            FindObjectOfType<NextLevel>().PlayParticle();
        }
    }

    public bool IsEverythingCollected()
    {
        return (Collected ==TotalCollectables);
    }

    public void PlayerLivesUpdate()
    {
        lives.text = $"Lives : {FindObjectOfType<GameSession>().GetLives()}";
    }
    
}
