using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShack : MonoBehaviour
{

    private bool playerInRange;
    public List<string> dialogues;
    private DialogManager dialogManager;

    public GameObject enemyPrefab; // Das Prefab des Gegners, das du spawnen möchtest
    public int numberOfEnemies; // Die Anzahl der zu spawnenden Gegner
    public float spawnRadius; // Der maximale Radius um das Objekt, in dem die Gegner spawnen sollen



    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            if (dialogManager.dialogBox.activeInHierarchy)
            {
                dialogManager.EndDialog();
            }
            else
            {
                dialogManager.StartDialog(dialogues);
                SpawnEnemies(); // Rufe die Methode zum Spawnen der Gegner auf
            }
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
            dialogManager.EndDialog();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }


}
