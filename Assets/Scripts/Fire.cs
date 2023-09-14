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

    public GameObject Blood;
    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.transform.name);
        if(collision.gameObject != PJ1 && collision.transform.name != "Walls" && collision.transform.name != "Walls3" && collision.transform.name != "Walls2" && collision.transform.name != "Killa" && collision.transform.name != "Barricada" && collision.transform.name != "PuertaDerechaP" && collision.transform.name != "PuertaIzquierdaP"){
            dataKill.killCount += 1;
            Destroy(collision.gameObject);
            Instantiate(Blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
            textBox.text = dataKill.killCount.ToString();
        }else if(collision.transform.name == "Killa"){
            Debug.Log("LE PEGASTE - CODIGO BALA");
        }else{
            Destroy(gameObject);
        }
        
        
        

    }
}
