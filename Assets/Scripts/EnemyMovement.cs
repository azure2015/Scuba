using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] bool leftRight = true;
  

    Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(leftRight)
        {
             enemyRigidBody.velocity = new Vector2(moveSpeed,0);
        }
        else{
            enemyRigidBody.velocity = new Vector2(0,moveSpeed);
        }

    }
 
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Background")
        {
        moveSpeed = -moveSpeed;
        if(leftRight)
            {
                transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)),1f);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            FindObjectOfType<Player>().PlayerDeath();
        }
    }
}
