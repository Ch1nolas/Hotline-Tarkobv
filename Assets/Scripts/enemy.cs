using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;  // Referencia al transform del jugador
    public float movementSpeed = 5f;  // Velocidad de movimiento del enemigo


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si el jugador está disponible
        if (target != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Mover el enemigo hacia el jugador
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }
}
