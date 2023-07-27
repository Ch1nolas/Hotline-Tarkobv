using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{  
   public void SiguienteLevel() {
        SceneManager.LoadScene("Principal");
    }

    public void Menu() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
