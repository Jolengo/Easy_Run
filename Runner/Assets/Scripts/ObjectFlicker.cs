using UnityEngine;

public class ObjectFlicker : MonoBehaviour
{
    public float minIntensity = 0.2f; // ����������� ������������� ��������
    public float maxIntensity = 1f; // ������������ ������������� ��������
    public float flickerSpeed = 5f; // �������� ��������

    private Light objectLight; // ��������� ����� �������
    private float targetIntensity; // ������� ������������� ��������

    private void Start()
    {
        objectLight = GetComponent<Light>(); // �������� ��������� ����� �������
        targetIntensity = objectLight.intensity; // ������ ��������� ������� �������������
    }

    private void Update()
    {
        // ��������� ����� ������������� �������� � ������� ��������� ����� ����������� � ������������ ����������
        float newIntensity = Mathf.Lerp(objectLight.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

        // ���������, �������� �� ������������� �������� �������� ��������
        if (Mathf.Abs(newIntensity - targetIntensity) < 0.01f)
        {
            // ���� ��������, ������ ������� ������������� �� ���������������
            targetIntensity = (targetIntensity == minIntensity) ? maxIntensity : minIntensity;
        }

        // ��������� ����� ������������� ��������
        objectLight.intensity = newIntensity;
    }
}

