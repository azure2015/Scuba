using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] float steerSpeed = 110f;
    [SerializeField] float moveSpeed = 6.0f;
    [SerializeField] float rotateSpeed = 90f;
    [SerializeField] GameTimer timerObject;
    //[SerializeField] UIDisplay uiDisplay;
    [SerializeField] List<GameObject> breakingPlayer;
    [SerializeField] CinemachineBrain followCam;

    private Camera mainCamera;
    private Rigidbody2D rb;

    private Vector3 movementDirection;

 //   private SpriteRenderer sprite;

    private float valuePosition;

    private bool movePlayer = false;
    private bool isAlive = true;
    private bool isCreated = true;

    private Vector2 moveInput;

    float endDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            var time = timerObject.GetTimer();
            if(time <= 0)
            {
                PlayerDeath();
            }
            MovePlayer();
        }
        
        if(!isAlive)
        {
            endDelay -= Time.deltaTime;
            if(endDelay< 0)
            {
                 FindObjectOfType<GameSession>().PlayerDeath();
            }
        }
    }

    void MovePlayer()
    {
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
            FindObjectOfType<UIDisplay>().ItemCollected();
        }
        
    }

    public void PlayerDeath()
    {
        StartCoroutine(FindObjectOfType<GameSession>().PlayerDeath());
        GetComponent<SpriteRenderer>().enabled = false;
        isAlive = false;
        rb.isKinematic = false;
        followCam.enabled = false;
        if(isCreated)
        {
            foreach(GameObject part in breakingPlayer)
            {
                    Instantiate(part,transform.position,transform.rotation);
            }
        isCreated = false;
        }

    }
}
