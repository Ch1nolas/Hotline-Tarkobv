using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    private int xActual;
    private int yActual;
    public Animator anim;
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
            // if(xActual == transform.position.x){
            //     anim.SetTrigger("Idle");
            // }
            if(xActual < (int)transform.position.x)
            {
                anim.SetTrigger("Derecha");
            } 
            
            if(xActual > (int)transform.position.x){
                anim.SetTrigger("Izquierda");
            } 
            if(yActual < (int)transform.position.y)
            {
                anim.SetTrigger("Arriba");
            } 
            
            if(yActual > (int)transform.position.y){
                anim.SetTrigger("Abajo");
            } 
            xActual = (int) transform.position.x;
            yActual = (int) transform.position.y;
            Debug.Log(xActual);
    }
    void FixedUpdate()
    {
        vectorNew = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed); 
        rb.AddForce(vectorNew); 
    }
}
