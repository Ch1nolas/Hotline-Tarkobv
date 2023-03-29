using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    Transform t;
    Movement m;

    private void Awake() {
        t = GetComponent<Transform>();
        m = GetComponent<Movement>();
    }

    public void Up(){
        m.Move(t, new Vector3(t.position.x, t.position.y + m._step));
    }
    public void Down(){
        m.Move(t, new Vector3(t.position.x, t.position.y - m._step));
    }
    public void Left(){
        m.Move(t, new Vector3(t.position.x - m._step, t.position.y));
    }
    public void Right(){
        m.Move(t, new Vector3(t.position.x + m._step, t.position.y));
    }
    public void Fire(){

    }
}
