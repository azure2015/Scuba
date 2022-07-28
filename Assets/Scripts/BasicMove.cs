using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float x_pos, y_pos,z_pos;

    public Vector3 myVector3;

    public Vector2 myVector2;

    public float speed =1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement wit individual components
       // transform.position = new Vector3(x_pos,y_pos,z_pos);    
       
       // movement with vector
       // transform.position = myVector3;

       // transform.position = transform.position + new Vector3(x_pos,y_pos,z_pos) * Time.deltaTime;
       
       //Add a speed to the xpos only with delta time
        //transform.position += new Vector3(speed * Time.deltaTime, 0f,0f);

     //   transform.position += transform.right * speed * Time.deltaTime;
    }
}
