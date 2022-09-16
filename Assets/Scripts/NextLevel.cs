using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    [SerializeField] ParticleSystem endEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
           bool allCollected = FindObjectOfType<UIDisplay>().IsEverythingCollected();
           if(other.tag=="Player" && allCollected)
           {
                StartCoroutine(FindObjectOfType<GameSession>().LoadNextLevel());
          }
           
    }

    public void PlayParticle()
    {
        endEffect.Play();
    }
}
