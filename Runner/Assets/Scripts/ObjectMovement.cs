using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2f; // �������� �������� �������
    public float distance = 5f; // ����������, �� ������� ������ ����� ���������

    private float startPositionX; // ��������� ������� ������� �� ��� X

    private void Start()
    {
        startPositionX = transform.position.x; // ���������� ��������� ������� �������
    }

    private void Update()
    {
        // ��������� ����� ������� �������
        float newPositionX = startPositionX + Mathf.Sin(Time.time * speed) * distance;

        // ��������� ����� �������
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
