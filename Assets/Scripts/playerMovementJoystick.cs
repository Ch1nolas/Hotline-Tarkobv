using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementJoystick : MonoBehaviour
{
    // Start is called before the first frame update

    public MovementJoystick movementJoystick;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate(){
        if(movementJoystick.joystickVec.y != 0){
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed);
        } else {
            rb.velocity = Vector2.zero;
        }
    }
}
