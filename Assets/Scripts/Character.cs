using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // Class for movement of sprites on the three main screen
    //     Move object left to right / right to left and scale the sprite
    //      

    SpriteRenderer spriteRenderer;
    Rigidbody2D charRigidbody;
    public int action= 1;
    private float moveSpeed = 3f;
    private bool turn = true;
  
    // Get the component for the sprite and the rigid body
    void Start()
    {
        charRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Find the direction and call method.  If action is 1 then the sprite in foreground so move sprite faster and scale up
    //    If background move sprite slower and scale down.
    void Update()
    {
        if(turn) {rightDirection();}
        else { leftDirection();}

        if(action==1) {transform.localScale = new Vector3(2f,2f,1f); moveSpeed = 3f;spriteRenderer.sortingOrder=3;}
        if(action==2) {transform.localScale = new Vector3(0.5f,0.5f,0); moveSpeed = 1f; spriteRenderer.sortingOrder=1; }
    }

    void rightDirection()
    {
        charRigidbody.velocity = new Vector2(moveSpeed,0);
        transform.rotation = Quaternion.Euler(0f,0f,0f);
 
    }

    void leftDirection()
    {
        charRigidbody.velocity = new Vector2(-moveSpeed,0);
        transform.rotation = Quaternion.Euler(0f,180f,0f);
;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag =="Enemy")
        {
            action = Random.Range(1,3);
            turn =!turn;
        }    
    }
}
