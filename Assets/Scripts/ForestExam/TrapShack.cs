using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShack : MonoBehaviour
{

    private bool playerInRange;
    public List<string> dialogues;

    public GameObject enemyPrefab; // Das Prefab des Gegners, das du spawnen möchtest
    public int numberOfEnemies; // Die Anzahl der zu spawnenden Gegner
    public float spawnRadius; // Der maximale Radius um das Objekt, in dem die Gegner spawnen sollen



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInRange)
        {
            if (DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.EndDialog();
            }
            else
            {
                DialogManager.instance.StartDialog(dialogues);
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
            DialogManager.instance.EndDialog();
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
