using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStump : MonoBehaviour
{
    public Transform teleportPosition;

    private bool playerInRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        if (teleportPosition != null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            DialogManager.instance.EndDialog();
        }
    }
}
