using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float totalTime = 100.0f;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        print("Timer : " + (int)totalTime);

    }

    public int GetTimer()
    {
        return (int)totalTime;
    }
}
