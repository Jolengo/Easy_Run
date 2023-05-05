using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shards : MonoBehaviour
{
    public GameObject shardPrefab; // префаб осколка
    public int numShards = 10; // количество осколков
    public float radius = 2f; // радиус орбиты
    public float speed = 2f; // скорость орбиты
    public Transform target; // цель орбиты

    private List<GameObject> shards = new List<GameObject>(); // список осколков

    void Start()
    {
        // создание осколков
        for (int i = 0; i < numShards; i++)
        {
            GameObject shard = Instantiate(shardPrefab, transform.position, Quaternion.identity);
            shards.Add(shard);
        }
    }

    void Update()
    {
        // перемещение осколков по орбите
        for (int i = 0; i < numShards; i++)
        {
            float angle = i * Mathf.PI * 2f / numShards; // угол между осколками
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius); // позиция осколка на орбите
            pos = transform.TransformPoint(pos); // преобразование позиции в глобальные координаты
            shards[i].transform.position = Vector3.Lerp(shards[i].transform.position, pos, Time.deltaTime * speed); // перемещение осколка
            shards[i].transform.LookAt(target); // поворот осколка к цели
        }
    }
}

