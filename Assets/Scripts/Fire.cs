using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{   
    public float firespeed;
    public GameObject PJ1;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * firespeed * Time.deltaTime, Space.Self);
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.transform.name);
        if(collision.gameObject != PJ1 && collision.transform.name != "Walls"){
            Debug.Log(collision.transform.name);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        } else{
            Destroy(gameObject);
        }
        
    }
}
