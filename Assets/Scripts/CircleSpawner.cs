using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject particle;
    public int count = 5;
    public float range = 3;

    void Start()
    {
        var angle = 360f / count;

        for (int i = 0; i < count; i++)
        {
            var rad = angle * i * Mathf.Deg2Rad;
            var x = Mathf.Cos(rad);
            var y = Mathf.Sin(rad);

            Instantiate(particle, new Vector3(x, y) * range, Quaternion.identity, transform);

        }
    }

    
}
