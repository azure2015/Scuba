using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    int currentLevel = 0;
    void Awake()
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
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayerDeath()
    {
        if(playerLives > 1)
        {
            playerLives--;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
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


    void ResetGameSession()
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
