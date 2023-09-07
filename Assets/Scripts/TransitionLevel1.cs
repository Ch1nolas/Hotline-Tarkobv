using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLevel1 : MonoBehaviour
{

    public Data dataKill;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag== "Player") {
            dataKill.vicoryPreviusScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
