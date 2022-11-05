using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool pauseGame = false;
    float timeCounter;
    int tapCount;
  //  int clickCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Touchscreen.current.primaryTouch.press.isPressed )
        {
            timeCounter += Time.deltaTime;
            if(timeCounter> 10.0 && !pauseGame)
            {
                timeCounter = 0;
                pauseGame=true;
                Time.timeScale = 0;
            }

            if(timeCounter>2.0 && pauseGame)
            {
                timeCounter = 0;
                pauseGame=false;
                Time.timeScale = 1;
            }

            if(pauseGame && Touchscreen.current.primaryTouch.press.isPressed)
            {
                timeCounter += 0.1f;
                print(timeCounter);
            }
        //     clickCounter++;
        //     if(clickCounter > 20)
        //     {
        //         Time.timeScale = 0;
        //         clickCounter = 0;
        //         pauseGame = true;
        }

           if (Input.touchCount > 0 && Input.GetTouch(0).phase ==   UnityEngine.TouchPhase.Ended)
         {
             tapCount += 1;
             StartCoroutine(Countdown());    
              print("Unpause");
         }
       
         if (tapCount == 2)
         {    
             tapCount = 0;
             StopCoroutine(Countdown());
             print("Unpause");
           ///////// DO STUFF!!   
         }
 
   
        // }
        
     
        // if(Touchscreen.current.primaryTouch.press.isPressed && pauseGame)
        // {
        //     clickCounter++;
        //     if(clickCounter> 20)
        //     {
        //         pauseGame = false;
        //         Time.timeScale = 1;
        //         clickCounter = 0;
        //     }
        // }
    }

      
     private IEnumerator Countdown()
     { 
             yield return new WaitForSeconds(0.3f);
             tapCount = 0;  
     }
  

}
