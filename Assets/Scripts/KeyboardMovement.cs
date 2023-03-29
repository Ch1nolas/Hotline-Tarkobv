using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] KeyCode _up;
    [SerializeField] KeyCode _down;
    [SerializeField] KeyCode _left;
    [SerializeField] KeyCode _right;

    [SerializeField] KeyCode _fire;

    

    Transform t;
    Vector3 p;
    Movement m;

    private void Awake() {
        t = GetComponent<Transform>();
        m = GetComponent<Movement>();
    }


    // Update is called once per frame
    void Update()
    {
        try{
            if(Input.GetKeyDown(_up)){
                p = new Vector3(t.position.x, t.position.y + m._step);
                m.Move(t, p);
            }
                if(Input.GetKeyDown(_down)){
                p = new Vector3(t.position.x, t.position.y - m._step);
                m.Move(t, p);
            }
            if(Input.GetKeyDown(_left)){
                p = new Vector3(t.position.x - m._step, t.position.y);
                m.Move(t, p);
            }
            if(Input.GetKeyDown(_right)){
                p = new Vector3(t.position.x + m._step, t.position.y);
                m.Move(t, p);
            }
            if(Input.GetKeyDown(_fire)){
                Debug.Log("PIU PIU");
            }
        }
        catch (Exception e){
            Debug.LogError(e);
        }

        
    }
}
