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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PJ1").transform;
        recargandoText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        
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

    void HideRecargandoText()
    {
        recargandoText.gameObject.SetActive(false);
    }
}