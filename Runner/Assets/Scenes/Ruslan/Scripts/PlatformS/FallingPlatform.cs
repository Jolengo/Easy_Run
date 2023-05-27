using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class FallingPlatform : MonoBehaviour
{

    public string PlayerTag = "Player";
    public float Speed; // �������� �������� ������� 

    private bool _isPlayerOnPlatform = false;
    private float _startPositionY; // ��������� ������� ������� �� ��� Y

    private void Start()
    {
        _startPositionY = transform.position.y; // ���������� ��������� ������� �������
    }

    private void Update()
    {
        if (_isPlayerOnPlatform)
            Falling();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _isPlayerOnPlatform = true;
        else
            _isPlayerOnPlatform = false;        
    }

    void Falling ()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime; 
    }
}
