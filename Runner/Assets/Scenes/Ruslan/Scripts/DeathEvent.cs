using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathEvent : MonoBehaviour
{
    public Image DeathScreen;
    public GameObject Player;
    public Camera PlayerCamera;

    public void DeathScreenEvent()
    {
        DeathScreen.gameObject.SetActive(true);
        PlayerCamera.gameObject.transform.parent = null;
        Player.gameObject.SetActive(false);  
    }
}
