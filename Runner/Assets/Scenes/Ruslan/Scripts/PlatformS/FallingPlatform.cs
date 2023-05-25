using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class FallingPlatform : MonoBehaviour
{

    public string PlayerTag = "Player";
    public float Speed; // Скорость движения объекта 

    private bool _isPlayerOnPlatform = false;
    private float _startPositionY; // Начальная позиция объекта по оси Y

    private void Start()
    {
        _startPositionY = transform.position.y; // Запоминаем начальную позицию объекта
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
