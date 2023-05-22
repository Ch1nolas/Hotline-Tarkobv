using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{  
   public void Jugar() {
        SceneManager.LoadScene("Principal");
    }

    public void Salir() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
