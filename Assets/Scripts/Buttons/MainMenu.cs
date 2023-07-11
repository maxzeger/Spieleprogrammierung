using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Inventory inventory;
    public void PlayGame()
    {
        SetInventoryToDefault();
        SceneManager.LoadScene("Village");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetInventoryToDefault()
    {
        inventory.coins = 0;
        inventory.damage = 1;
        inventory.hearts = 3;
        inventory.EndExamKeys = 0;
        inventory.forestExamKeys = 0;
    }
}
