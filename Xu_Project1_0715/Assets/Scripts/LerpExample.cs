using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpExample : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float TModifier = 0.1f;
    public float t;
    void Update()
    {
        t = Time.time;
        transform.position = Vector2.Lerp(startPoint.position, endPoint.position, Time.time * TModifier);
    }
}
