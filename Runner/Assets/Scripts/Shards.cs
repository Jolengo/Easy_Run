using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shards : MonoBehaviour
{
    public GameObject shardPrefab; // ������ �������
    public int numShards = 10; // ���������� ��������
    public float radius = 2f; // ������ ������
    public float speed = 2f; // �������� ������
    public Transform target; // ���� ������

    private List<GameObject> shards = new List<GameObject>(); // ������ ��������

    void Start()
    {
        // �������� ��������
        for (int i = 0; i < numShards; i++)
        {
            GameObject shard = Instantiate(shardPrefab, transform.position, Quaternion.identity);
            shards.Add(shard);
        }
    }

    void Update()
    {
        // ����������� �������� �� ������
        for (int i = 0; i < numShards; i++)
        {
            float angle = i * Mathf.PI * 2f / numShards; // ���� ����� ���������
            Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius); // ������� ������� �� ������
            pos = transform.TransformPoint(pos); // �������������� ������� � ���������� ����������
            shards[i].transform.position = Vector3.Lerp(shards[i].transform.position, pos, Time.deltaTime * speed); // ����������� �������
            shards[i].transform.LookAt(target); // ������� ������� � ����
        }
    }
}

