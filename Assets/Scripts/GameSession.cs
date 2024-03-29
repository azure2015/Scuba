using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives;
    

    int timerValue;
    int currentLevel;

    bool isPlaying = false;

    public void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession >1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
     
    }

    void OnStart() {
        if(isPlaying ==false) {
            
            FindObjectOfType<Music>().PlayMusic();
            isPlaying = true;
            
        }
    }


    public void  PlayerExtraLife()
    {
        playerLives++;
    }
    public IEnumerator PlayerDeath()
    {
        yield return new WaitForSecondsRealtime(1f);
        if(playerLives > 1)
        {
            playerLives--;
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            ResetGameSession();
        }
    }

    

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        currentLevel++;
        if(currentLevel >= SceneManager.sceneCountInBuildSettings)
        {
            currentLevel = 1;
        }
        SceneManager.LoadScene(currentLevel);
    }

    public int GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void playMusicTrack(int trackNo)
    {

    }
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<Music>().PlayMusic();
        Destroy(gameObject);
    }

      public void LoadIntroSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public int GetLives()
    {
        return playerLives;
    }

    public void LoadGame()
    {
        currentLevel++;
        FindObjectOfType<Music>().StopMusic();
        SceneManager.LoadScene(currentLevel);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

}
