using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorDeEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    private void Start() {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void CrearEnemigo(){
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
        enemigos[numeroEnemigo].GetComponent<EnemyAudioController>().EnableAudio();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.tag== "Player") {
        int random = Random.Range(3, 7);
        for (int i = 0; i < random; i++)
        {
            CrearEnemigo();
        }
        Destroy(gameObject);
    }
    }
}
