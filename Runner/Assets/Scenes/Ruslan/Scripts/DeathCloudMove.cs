using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCloudMove : MonoBehaviour
{

    public float Speed = 1f;

    void Update()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }
}
