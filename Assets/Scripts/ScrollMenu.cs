using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollMenu : MonoBehaviour
{
  [SerializeField] GameObject musicPlayer;
  
  void OnStart()
  {
    Destroy(FindObjectOfType<GameSession>());
  }
  public void ResetMenu()
  {
    Application.Quit();
    
      Destroy(musicPlayer);
      FindObjectOfType<GameSession>().Awake();
      
      SceneManager.LoadScene(0);
  }

}
