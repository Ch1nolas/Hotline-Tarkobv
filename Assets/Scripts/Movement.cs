using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Movement(){
        _step = 0.6f;
    }
    public float _step { get;}

    public void Move(Transform t, Vector3 p){
        t.position = p;
    }
}
