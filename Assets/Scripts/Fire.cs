using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{   
    public float firespeed;
    public GameObject PJ1;
    public int death;
    public Data dataKill;
    public Text textBox;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject != PJ1 && collision.transform.name != "Walls" && collision.transform.name != "Walls3" && collision.transform.name != "Walls2"){
            dataKill.killCount += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            textBox.text = dataKill.killCount.ToString();
        }else{
            Destroy(gameObject);
        }
        

    }
}
