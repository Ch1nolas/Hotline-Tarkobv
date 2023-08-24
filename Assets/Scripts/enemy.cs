using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private AudioSource au;
    [SerializeField] float tiempoDeSonido;

    public Transform target;  // Referencia al transform del jugador
    private float movementSpeed = 1.5f;  // Velocidad de movimiento del enemigo
    private float rotateSpeed = 0.525f;
    private Rigidbody2D rb;
    private float tiempo;
    private NavMeshAgent agente;
    // Start is called before the first frame update

    private void Start()
    {
        rb  =   GetComponent<Rigidbody2D>();
        au  =   GetComponent<AudioSource>();
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }
    private void Sonido(){
        au.Play();
        
    }

    private void Update(){
        
        //GetTarget();
        //RotateTowardsTarget();
        agente.SetDestination(target.position);
        tiempo+=Time.deltaTime;
        if (tiempo >= tiempoDeSonido){
            Sonido();
            tiempo=0;
        
        }
    }

    // Update is called once per frame
    private void FixedUpdate(){
        rb.velocity = transform.up * movementSpeed;
    }

    private void RotateTowardsTarget(){
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q =  Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        // Debug.Log(q);
    }

    private void GetTarget(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log(other.gameObject);
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            target = null;
            Debug.Log("GAME OVER PETON");
            SceneManager.LoadScene("GameOver");

        }
    }
}
