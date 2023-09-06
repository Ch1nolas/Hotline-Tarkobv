using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{  
    public Data dataKill;

    public void Jugar() {
        SceneManager.LoadScene(dataKill.previousSceneName);
    }

    public void Salir() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
