using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject Bullet;
    public Transform start;
    private AudioSource SonidoDisparo; 
    Vector2 movement;
    public int death;
    public Data dataKill;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        SonidoDisparo = GetComponent<AudioSource>();
        dataKill.killCount = 0;
    }

    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void fireshoot(){
        SonidoDisparo.Play();
        GameObject ob = Instantiate(Bullet, start.position, start.rotation);
        
    }
}
