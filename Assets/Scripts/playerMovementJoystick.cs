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
    public FireJoystick fireJoystick; //
    public Rigidbody2D rb;
    float moveSpeed = 250f;
    public GameObject Bullet;
    public Animator animator;

    float timer;
    Vector2 vectorNew ;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        xActual = (int) transform.position.x;
        yActual = (int) transform.position.y;
    }

    void Update(){
        float hAxis = movementJoystick.joystickVec.x;
        float vAxis = movementJoystick.joystickVec.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        float FirehAxis = fireJoystick.joystickVec.x;
        float FirevAxis = fireJoystick.joystickVec.y;
        float FirezAxis = Mathf.Atan2(FirehAxis, FirevAxis) * Mathf.Rad2Deg;
        if (hAxis != 0 && vAxis != 0) {
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
            animator.SetBool("Moviendo", true);
        }else if(FirehAxis != 0 && FirevAxis != 0){
            transform.eulerAngles = new Vector3(0f, 0f, -FirezAxis);
            animator.SetBool("Moviendo", false);
        } else {
            animator.SetBool("Moviendo", false);
        }
        
    }
    void FixedUpdate()
    {

        vectorNew = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed); 
        rb.AddForce(vectorNew); 
    }
    
    
}
