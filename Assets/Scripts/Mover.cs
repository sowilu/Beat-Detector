using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float minRange = -2;
    public float maxRange = 2;

    Vector3 origin;

    void Start()
    {
        origin = transform.position;

        if(transform.parent != null)
            transform.LookAt(transform.parent.position);

        AudioAnalyzer.inst.onBeat.AddListener(Move);
    }

    
    void Move(float value)
    {
        var pos = Mathf.Lerp(minRange, maxRange, value);

        transform.localPosition = transform.forward * pos + origin;
    }
}
