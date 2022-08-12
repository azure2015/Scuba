using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float steerSpeed = 110f;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float rotateSpeed = 90f;
    [SerializeField] GameTimer timerObject;
    [SerializeField] UIDisplay uiDisplay;

    private Camera mainCamera;
    private Rigidbody2D rb;

    private Vector3 movementDirection;

    private float valuePosition;

    private bool movePlayer = false;

    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var time = timerObject.GetTimer();
        if(time <= 0)
        {
            Destroy(gameObject);
        }

        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            movePlayer = true;
            Vector2 touchPosition =Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            valuePosition = Mathf.Floor(worldPosition.x - transform.position.x);
            if(valuePosition > 0)
            {
                transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);
            } else if (valuePosition < 0)
            {
                transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
            }

            else {
                movementDirection = Vector3.zero;
            }
            
         //   rb.AddForce(transform.forward* 2);
           // Vector3.ClampMagnitude(rb.velocity, 4.0f);
        } else 
        {
            movePlayer = false;
            

        }

        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            float steerAmount = moveInput.x *steerSpeed * Time.deltaTime;
            float moveAmount = moveInput.y * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate( moveAmount,0, 0);
        }
    }

    void FixedUpdate() 
    {
        if(movePlayer)
        {
            rb.AddForce(transform.right* 2);
            Vector3.ClampMagnitude(rb.velocity, 4.0f);
        }
    }

    void OnMove(InputValue movementValue)
    {
        moveInput = movementValue.Get<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bubble")
        {
            timerObject.resetTimer();
        }
        if(other.gameObject.tag=="Collectable")
        {
            uiDisplay.ItemCollected();
            Destroy(other.gameObject);
        }
        
    }
}
