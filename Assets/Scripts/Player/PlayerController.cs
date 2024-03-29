using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb ;

    public void FixedUpdate()
    {
        Vector2 direction = new Vector2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical);
        rb.velocity = direction.normalized * speed ;
    }
}
