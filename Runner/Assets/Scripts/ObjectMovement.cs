using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2f; // Скорость движения объекта
    public float distance = 5f; // Расстояние, на которое объект будет двигаться

    private float startPositionX; // Начальная позиция объекта по оси X

    private void Start()
    {
        startPositionX = transform.position.x; // Запоминаем начальную позицию объекта
    }

    private void Update()
    {
        // Вычисляем новую позицию объекта
        float newPositionX = startPositionX + Mathf.Sin(Time.time * speed) * distance;

        // Применяем новую позицию
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
