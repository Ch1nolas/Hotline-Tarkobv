using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{  
    public Data dataKill;
    public void SiguienteLevel() {
        SceneManager.LoadScene(dataKill.vicoryPreviusScene + 1);
    }

    public void Menu() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
