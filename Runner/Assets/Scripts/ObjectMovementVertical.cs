using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementVertical : MonoBehaviour
{
    public float speed = 2f; // Скорость движения объекта
    public float distance = 5f; // Расстояние, на которое объект будет двигаться

    private float startPositionY; // Начальная позиция объекта по оси Y
    private bool movingUp = true; // Флаг для определения направления движения

    private void Start()
    {
        startPositionY = transform.position.y; // Запоминаем начальную позицию объекта
    }

    private void Update()
    {
        // Вычисляем новую позицию объекта
        float newPositionY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;

        // Проверяем, достиг ли объект верхней или нижней границы движения
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

        // Применяем новую позицию
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
