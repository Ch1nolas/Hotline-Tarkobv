using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireBoss : MonoBehaviour
{   
    public float firespeed;
    public GameObject Killa;
    public int death;
    public Data dataKill;


    public GameObject Blood;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject != Killa && collision.transform.name != "Walls" && collision.transform.name != "Walls3" && collision.transform.name != "Walls2"){
            dataKill.previousSceneName = SceneManager.GetActiveScene().name;
            Instantiate(Blood, transform.position, Quaternion.identity);
            
            Destroy(collision.gameObject);
            Debug.Log("GAME OVER PETON");
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
            
        }else{
            
            Destroy(gameObject);
        }
        

    }
}
