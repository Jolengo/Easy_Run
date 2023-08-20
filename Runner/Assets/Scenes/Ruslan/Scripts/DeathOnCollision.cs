using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollision : MonoBehaviour
{

    public DeathEvent DeathEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Camera>())
            DeathEvent.DeathScreenEvent();
    }

}
