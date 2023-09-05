using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar() {
        SceneManager.LoadScene("Level0");
    }

    public void Salir() {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void CambiarVolumen(float volumen){

    }
}
