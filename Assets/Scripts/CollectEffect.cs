using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] SpriteRenderer sprite;
    private bool once = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && once) 
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.main.duration;
            collisionParticleSystem.transform.position = sprite.transform.position;

            em.enabled = true;
            collisionParticleSystem.Play();

            once=false;
            Destroy(sprite);
            Invoke(nameof(DestroyObj), dur);
        }
        
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
