using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterEffect : MonoBehaviour
{
    public GameObject shatterPrefab;
    public int shatterCount = 10;
    public float rotationSpeed = 100f;
    public float shakeIntensity = 0.1f;

    private List<GameObject> shatters = new List<GameObject>();
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;

        // Создаем осколки вокруг объекта
        for (int i = 0; i < shatterCount; i++)
        {
            GameObject shatter = Instantiate(shatterPrefab, transform.position, Quaternion.identity);
            shatter.transform.SetParent(transform);
            shatters.Add(shatter);
        }
    }

    private void Update()
    {
        // Вращаем осколки вокруг объекта
        foreach (GameObject shatter in shatters)
        {
            shatter.transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            shatter.transform.rotation = Quaternion.Lerp(shatter.transform.rotation, initialRotation, 0.05f);
        }

        // Делаем осколки дрожать
        foreach (GameObject shatter in shatters)
        {
            Vector3 shakeAmount = Random.insideUnitSphere * shakeIntensity;
            shatter.transform.position += shakeAmount;
            shatter.transform.rotation *= Quaternion.Euler(shakeAmount);
        }
    }
}

