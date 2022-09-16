using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakForce : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;

    [SerializeField] Vector2 forceDirection;

    [SerializeField] float torque;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(forceDirection);
        rb2D.AddTorque(torque);
    }


}
