using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag =="Player")
        {
            FindObjectOfType<GameSession>().PlayerExtraLife();
            Destroy(gameObject);
        }    
    }
}
