using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementJoystick : MonoBehaviour
{
    // Start is called before the first frame update

    public MovementJoystick movementJoystick;
    public Rigidbody2D rb;
    float moveSpeed = 250f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //Debug.Log($"{movementJoystick.joystickVec.x},{movementJoystick.joystickVec.y}");
        Vector2 vectorNew = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed); 
        rb.AddForce(vectorNew); 
    }
}
