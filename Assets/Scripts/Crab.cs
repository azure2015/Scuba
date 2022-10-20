using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Enemy"){
            transform.position= new Vector2(Random.Range(-10.0f,10.0f),Random.Range(3.5f,4.5f));
        }
    } 
}
