using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{

    public Transform PlayerPosition;
    public Text Counter;
    public int CountMinimizer = 100;

    private float _playerPosZ;
    private int _count = 0;

    void Start()
    {
        _playerPosZ = PlayerPosition.position.z;
    }

    void Update()
    {
        if (PlayerPosition.position.z > _playerPosZ)
        {
            _count++;

            _playerPosZ = PlayerPosition.position.z;
        }

        Counter.text = (_count / CountMinimizer).ToString();
    }
}
