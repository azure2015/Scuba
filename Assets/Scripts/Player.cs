using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float steerSpeed = 110f;
    [SerializeField] float moveSpeed = 15.0f;

    Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = moveInput.x *steerSpeed * Time.deltaTime;
        float moveAmount = moveInput.y * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate( moveAmount,0, 0);
    }


    void OnMove(InputValue movementValue)
    {
        moveInput = movementValue.Get<Vector2>();
    }
}
