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

    void Start()
    {
        player = GameObject.Find("PJ1").transform;
        recargandoText.gameObject.SetActive(false);

        Invoke("StopMoving", Random.Range(3f, 5f));

    }

    void Update()
    {
        if(isMoving){
            MoveUpDown();
        } else if(isMoving == false){
            LookAtPlayer();
            ShootToPlayer();
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
                
            }
            recargandoText.gameObject.SetActive(true);
            if(recargandoText.gameObject.activeSelf){
                Invoke("HideRecargandoText", 5f);
            }
            
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
            RotateCharacter();
        }
        else if (transform.position.y <= lowerLimit)
        {
            transform.position = new Vector3(transform.position.x, lowerLimit, transform.position.z);
            RotateCharacter();
        }
    }
    void RotateCharacter()
    {
        transform.Rotate(Vector3.forward, 180f);
    }

    void StopMoving()
    {
        isMoving = false;
        
    }
    void HideRecargandoText()
    {
        recargandoText.gameObject.SetActive(false);
        
        isMoving = true;
        Invoke("StopMoving", Random.Range(3f, 5f));
    }
    void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}