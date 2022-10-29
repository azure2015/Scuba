using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
    bool walk=false;
    float walkSpeed = 0;
    Rigidbody2D enemyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(walk)
        {
            enemyRigidBody.velocity = new Vector2(walkSpeed,0);
            // if(transform.eulerAngles.z > 0) 
            // {
            //     transform.eulerAngles = new Vector3(0,0,0);
            // }
        } else 
        {
            enemyRigidBody.velocity = new Vector2(0,moveSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Enemy"){
            walk = true;
            walkSpeed = Random.Range(1f,2f);
            if(transform.position.x < 0) {
                walkSpeed *= -1;
            }
        
        }
        if(other.tag=="Respawn")
        {
            walk = false;
            transform.position= new Vector2(Random.Range(-8.0f,8.0f),Random.Range(3.5f,4.5f));
        }
    } 
}
