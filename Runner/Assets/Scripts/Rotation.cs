using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour

{
    public float angle;
    float angle1;
    public Vector3 v;
    Quaternion q;
    public GameObject cube;
    void Start()
    {
        angle1 = angle * (Mathf.PI / 180);
        v = v.normalized;
        q = new Quaternion(Mathf.Sin(angle1 / 2) * v.x, Mathf.Sin(angle1 / 2) * v.y, Mathf.Sin(angle1 / 2) * v.z, Mathf.Cos(angle1 / 2));
    }

    void Update()
    {
        angle1 = angle * (Mathf.PI / 180);
        v = v.normalized;
        q = new Quaternion(Mathf.Sin(angle1 / 2) * v.x, Mathf.Sin(angle1 / 2) * v.y, Mathf.Sin(angle1 / 2) * v.z, Mathf.Cos(angle1 / 2));
        cube.transform.rotation = cube.transform.rotation * q;
    }
}
