using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuCommands : MonoBehaviour
{

    [SerializeField] AudioSource musicTune;
    [SerializeField] TextMeshProUGUI audioButton;

    public void LoadMenu()
    {
        FindObjectOfType<GameSession>().LoadIntroSession();
    }

     public void ResetMenu()
    {
        FindObjectOfType<GameSession>().ResetGameSession();
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
        Destroy(gameObject);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
        Destroy(gameObject);
    }
    public void ToggleMusic()
    {
        if(musicTune.isPlaying)
        {
            audioButton.text = "Audio Off";
            var musicPlayer = GetComponent<Music>();
            musicPlayer.GetComponent<AudioSource>().Pause();
        }
         else
         {
            audioButton.text = "Audio On";
            GetComponent<AudioSource>().Play();
         //  musicTune.Play();
         }

         
    }




}
