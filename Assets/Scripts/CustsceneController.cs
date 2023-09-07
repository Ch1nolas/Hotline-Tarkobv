using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustsceneController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas canvas2;
    public static bool isCutscene;
    public Animator canAnim;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canAnim.SetBool("Cutscene1", false);
            canvas.enabled = false;
            canvas2.enabled = true;
            Invoke("DisableCanvas", 5f);
            
        }
    }

    private void DisableCanvas()
    {
        Debug.Log("¡Función ejecutada después del tiempo de espera!");
        canvas2.enabled = false;
        canvas.enabled = true;
        Destroy(gameObject);
    }
}
