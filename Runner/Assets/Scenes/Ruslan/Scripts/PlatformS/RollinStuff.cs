using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollinStuff : MonoBehaviour
{
    
    public float RotationSpeed = 1f;
    public List<GameObject> RollinObjects = new List<GameObject>();

    private float _angle = 0f;

    void Update()
    {
        for(int i = 0; i < RollinObjects.Count; i++)
        {
            _angle += RotationSpeed * Time.deltaTime;
            float radius = Mathf.Sqrt(Mathf.Pow(transform.position.x - RollinObjects[i].transform.position.x, 2) + Mathf.Pow(transform.position.y - RollinObjects[i].transform.position.y, 2));

            float Xpos = transform.position.x + Mathf.Cos(_angle + i * 2 * Mathf.PI / RollinObjects.Count) * radius;
            float Ypos = transform.position.y + Mathf.Sin(_angle + i * 2 * Mathf.PI / RollinObjects.Count) * radius;
            RollinObjects[i].transform.position = new Vector3(Xpos, Ypos, RollinObjects[i].transform.position.z);
        }
    }
}
