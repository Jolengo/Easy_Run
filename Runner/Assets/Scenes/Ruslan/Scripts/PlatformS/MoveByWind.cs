using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class MoveByWind : MonoBehaviour
{

    public string PlayerTag = "Player";
    public float WindSpeed = 1f;  

    private bool _isPlayerOnTrigger = false;
    private CharacterController _cc;

    private void FixedUpdate()
    {
        if (_isPlayerOnTrigger)
            WindForce();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            _isPlayerOnTrigger = true;
            _cc = other.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _isPlayerOnTrigger = false;
    }

    void WindForce()
    {
        _cc.Move(Vector3.back * WindSpeed * Time.fixedDeltaTime);
    }
}
