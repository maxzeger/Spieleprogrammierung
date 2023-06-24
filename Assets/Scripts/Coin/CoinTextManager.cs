using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI coinDisplay;

    private void Start()
    {
        UpdateCoinCount();
    }

    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + inventory.coins;
    }
}