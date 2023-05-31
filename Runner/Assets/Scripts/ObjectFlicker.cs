using UnityEngine;

public class ObjectFlicker : MonoBehaviour
{
    public float minIntensity = 0.2f; // Минимальная интенсивность свечения
    public float maxIntensity = 1f; // Максимальная интенсивность свечения
    public float flickerSpeed = 5f; // Скорость мерцания

    private Light objectLight; // Компонент света объекта
    private float targetIntensity; // Целевая интенсивность свечения

    private void Start()
    {
        objectLight = GetComponent<Light>(); // Получаем компонент света объекта
        targetIntensity = objectLight.intensity; // Задаем начальную целевую интенсивность
    }

    private void Update()
    {
        // Вычисляем новую интенсивность свечения с плавным переходом между минимальным и максимальным значениями
        float newIntensity = Mathf.Lerp(objectLight.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

        // Проверяем, достигла ли интенсивность свечения целевого значения
        if (Mathf.Abs(newIntensity - targetIntensity) < 0.01f)
        {
            // Если достигла, меняем целевую интенсивность на противоположную
            targetIntensity = (targetIntensity == minIntensity) ? maxIntensity : minIntensity;
        }

        // Применяем новую интенсивность свечения
        objectLight.intensity = newIntensity;
    }
}

