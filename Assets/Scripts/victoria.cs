using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoria : MonoBehaviour
{  
   public void Jugar() {
        SceneManager.LoadScene("Principal");
    }

    public void Salir() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
