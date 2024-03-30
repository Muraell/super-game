using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript : MonoBehaviour
{
    public GameObject GameCompleteScreen;
    public GameObject gameplayUI;
    public Transform transform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameplayUI.SetActive(false);
            GameCompleteScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireBallCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
        }


    }
}

