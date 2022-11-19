using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] float steerSpeed = 110f;
    [SerializeField] float moveSpeed = 6.0f;
    [SerializeField] float rotateSpeed = 90f;
    [SerializeField] GameTimer timerObject;
    [SerializeField] List<GameObject> breakingPlayer;
    [SerializeField] TextMeshProUGUI textInfo;
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

    private float keyInputBoost = 2.0f;     // when using keyboard move player faster

    float endDelay = 2f;

    float touchTimer = 0f;
//    float delayTimer = 1f;
//    int countTap;

    // Variables for pause 
    float touchStart = 0f;
    bool pauseGame = false;
 //   bool enabledTimer = false;

    bool touchIsTrue = false;

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

        if(Touchscreen.current.primaryTouch.press.isPressed && !touchIsTrue)
        {
             touchStart = GetYPosition();
            touchIsTrue = true;
        }

        if(!Touchscreen.current.primaryTouch.press.isPressed && touchIsTrue)
        {
            var delta = GetYPosition();
            delta = Mathf.Abs(delta- touchStart); 
            if(delta > 5)
            {
                pauseGame = !pauseGame;
                if(pauseGame) SetPause(0,"Paused"); 
                if(!pauseGame) SetPause(1,"");
                delta = 0;
                touchStart = 0;
                touchIsTrue = false;
            }
        }

        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            touchStart = 0;
            touchIsTrue = false;
        }
    }

    float GetXPosition()
    {
        Vector2 touchPosition =Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        return (Mathf.Floor(worldPosition.x - transform.position.x));
    }

    float GetYPosition()
    {
        Vector2 touchPosition =Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        return (Mathf.Floor(worldPosition.y - transform.position.y));
    }
    void SetPause(int timeScale, string pauseText) 
    {
        Time.timeScale = timeScale;
         textInfo.text = pauseText;
    }

    void MovePlayer()
    {

        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            touchTimer += Time.deltaTime;
            if(touchTimer > 8.0)
            {
                transform.Rotate(Vector3.forward,-180);
                touchTimer = 0;
            }
        }
        else {
            touchTimer = 0;
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
            else 
            {
                movementDirection = Vector3.zero;
            }
            
        } else 
        {
            movePlayer = false;
        }

        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            
            float steerAmount = moveInput.x *steerSpeed * keyInputBoost * Time.deltaTime;
            float moveAmount = moveInput.y * moveSpeed * keyInputBoost * 2 * Time.deltaTime;
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

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag=="Bubble")
        {
            timerObject.TimerControl(false);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        timerObject.TimerControl(true);
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
