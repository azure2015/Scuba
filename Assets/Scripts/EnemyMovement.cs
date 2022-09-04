using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.velocity = new Vector2(moveSpeed,0);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Background")
        {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)),1f);
        }
    }
}
