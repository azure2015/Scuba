using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideparticle : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] float fadeTime;

    float particleTime;
    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        particleTime = fadeTime;
    }

    // Update is called once per frame
    void Update()
    {

        particleTime -= Time.deltaTime;
        if(particleTime < 0)
        {
    
            isActive = !isActive; 
            if(isActive) {
                StartCoroutine(EnabledBox());
                ps.Play();
            } else
            {
                GetComponentInParent<BoxCollider2D>().enabled = false;
                ps.Stop();
            }
            particleTime = fadeTime;

        }
    }

    IEnumerator EnabledBox()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponentInParent<BoxCollider2D>().enabled = true;
    }
    
}
