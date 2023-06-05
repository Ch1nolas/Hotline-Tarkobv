using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMovementJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    private int xActual;
    private int yActual;
    public MovementJoystick movementJoystick;
    public Rigidbody2D rb;
    float moveSpeed = 250f;
    public GameObject Bullet;

    float timer;
    Vector2 vectorNew ;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xActual = (int) transform.position.x;
        yActual = (int) transform.position.y;
    }

    void Update(){
        float hAxis = movementJoystick.joystickVec.x;
        float vAxis = movementJoystick.joystickVec.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
    }
    void FixedUpdate()
    {
        vectorNew = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed); 
        rb.AddForce(vectorNew); 
    }
    
    
}
