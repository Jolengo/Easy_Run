using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{

    public GameObject Player;

    private void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, Player.transform.position.z);
    }
}
