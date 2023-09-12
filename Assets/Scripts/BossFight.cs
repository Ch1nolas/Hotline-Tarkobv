using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{
    public Transform player;
    private float rotateSpeed = 0.525f;
    public Transform shooter;
    public GameObject bala;
    private float tiempo;
    private int disparosRealizados;
    public Data dataKill;
    public ParticleSystem muzzleFlash;
    public Text recargandoText;
    public float moveSpeed = 5f;
    public float upperLimit = 62f;
    public float lowerLimit = 43f;
    public bool isMoving = true;
    public bool hasRotated = false;
    public GameObject balaPJ1;
    int VidasJefe = 5;
    bool canBeShoot = false;
    bool hasExecuted = false;
    bool hasExecuted2 = true;

    void Start()
    {
        player = GameObject.Find("PJ1").transform;
        recargandoText.gameObject.SetActive(false);

        Invoke("StopMoving", Random.Range(3f, 5f));

    }

    void Update()
    {
        if(isMoving){
            if(!hasExecuted){
                ResetRotation();
                hasExecuted = true;
            }
            MoveUpDown();
        } else if(isMoving == false){
            LookAtPlayer();
            ShootToPlayer();
        }
        if(!hasExecuted2){
            isMoving = true;
            Invoke("StopMoving", Random.Range(3f, 5f));
            hasExecuted2 = true;
        }
        
        
        
    }

    void ShootToPlayer(){
        tiempo += Time.deltaTime;
        if (disparosRealizados < 5)
        {
            if (tiempo >= 0.5f && dataKill.isCutscene == false)
            {
                GameObject ob = Instantiate(bala, shooter.position, shooter.rotation);
                muzzleFlash.Play();
                tiempo = 0;
                disparosRealizados++;
            }
        }
        else
        {
            if (tiempo >= 5)
            {
                disparosRealizados = 0;
                tiempo = 0;
                hasExecuted2=false;
            }
            recargandoText.gameObject.SetActive(true);
            if(recargandoText.gameObject.activeSelf){
                Debug.Log("Ahora le podes pegar");
                canBeShoot = true;
                Invoke("HideRecargandoText", 5f);
            }
            hasExecuted=false;
            
            
        }
    }

    void LookAtPlayer(){
        Vector2 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    void MoveUpDown()
{
    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

    if (transform.position.y >= upperLimit)
    {
        transform.position = new Vector3(transform.position.x, upperLimit, transform.position.z);
        if (!hasRotated)
        {
            transform.Rotate(Vector3.forward, 180f);
            hasRotated = true;
        }
    }
    else if (transform.position.y <= lowerLimit)
    {
        transform.position = new Vector3(transform.position.x, lowerLimit, transform.position.z);
        if (!hasRotated)
        {
            transform.Rotate(Vector3.forward, -180f);
            hasRotated = true;
        }
    }
    else
    {
        hasRotated = false; // Reinicia la variable hasRotated si no está en una esquina
    }
}

    void StopMoving()
    {
        isMoving = false;
        Debug.Log("SE PAROOO");
        
    }
    void HideRecargandoText()
    {
        if(recargandoText.gameObject.activeSelf){
            Debug.Log("Ya no le podes pegar");
            canBeShoot = false;
            recargandoText.gameObject.SetActive(false);
        }
        
        
    }
    void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.transform.name == "Bullet(Clone)" && canBeShoot){
            VidasJefe--;
            Destroy(collision.gameObject);
            Debug.Log("le pegaste una");
            Debug.Log(VidasJefe);
        }
    }
}