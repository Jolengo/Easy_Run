using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    [SerializeField] public float speed = 0; // скорость

    void Update()
    {
        transform.Rotate(0, 0, -speed * Time.deltaTime); // вращение планеты
    }
}
