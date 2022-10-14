using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] float resetNumber;

    public ScrollRect scrollRect;
    public int count;
    

   // [SerializeField]  ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }
    // Update is called once per frame
    void Update()
    {
   
       // scrollRect.velocity = new Vector2(0f,5f);
       scrollRect.transform.position += new Vector3(0f,scrollSpeed,0f);
        if(resetNumber> scrollRect.transform.position.y)
        {
            Reset();
        }
    }

    void Reset() 
    {
        print("Reset");    
        scrollRect.transform.position = new Vector3(0f,0f,0f);
        
    }
}
