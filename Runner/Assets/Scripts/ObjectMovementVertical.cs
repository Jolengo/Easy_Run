using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementVertical : MonoBehaviour
{
    public float speed = 2f; // �������� �������� �������
    public float distance = 5f; // ����������, �� ������� ������ ����� ���������

    private float startPositionY; // ��������� ������� ������� �� ��� Y
    private bool movingUp = true; // ���� ��� ����������� ����������� ��������

    private void Start()
    {
        startPositionY = transform.position.y; // ���������� ��������� ������� �������
    }

    private void Update()
    {
        // ��������� ����� ������� �������
        float newPositionY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;

        // ���������, ������ �� ������ ������� ��� ������ ������� ��������
        if (newPositionY >= startPositionY + distance)
        {
            newPositionY = startPositionY + distance;
            movingUp = false;
        }
        else if (newPositionY <= startPositionY)
        {
            newPositionY = startPositionY;
            movingUp = true;
        }

        // ��������� ����� �������
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
