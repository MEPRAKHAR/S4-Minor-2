using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ButtonClickHandler : MonoBehaviour
{
    public Button yourButton; // Button to fetch data
    public Button increaseButton; // Button to increase quantity
    public Button decreaseButton; // Button to decrease quantity
    public DatabaseAccess databaseAccess; // Reference to the DatabaseAccess script
    public TMP_Text outputText; // UI Text component to display the output

    private string currentItemName; // Store the name of the current item
    private int currentQuantity; // Store the current quantity

    void Start()
    {
        // Add a listener to the button click event
        yourButton.onClick.AddListener(HandleButtonClick);

        // Add listeners for the increase and decrease buttons
        increaseButton.onClick.AddListener(IncreaseQuantity);
        decreaseButton.onClick.AddListener(DecreaseQuantity);
    }

    async void HandleButtonClick()
    {
        // Assuming the button's name is used as the keyName parameter
        string keyName = yourButton.name;
        List<Available> items = await databaseAccess.GetDataFromDataBase(keyName);

        // Assuming you want to display the first item's details
        if (items.Count > 0)
        {
            currentItemName = items[0].itemName;
            currentQuantity = items[0].quantity;
            outputText.text = $"Item Name: {currentItemName}\nQuantity: {currentQuantity}";
        }
    }

    void IncreaseQuantity()
    {
        currentQuantity++;
        UpdateDatabaseAndDisplay();
    }

    void DecreaseQuantity()
    {
        if (currentQuantity > 0)
        {
            currentQuantity--;
            UpdateDatabaseAndDisplay();
        }
    }

    async void UpdateDatabaseAndDisplay()
    {
        // Update the database with the new quantity
        await databaseAccess.UpdateQuantityInDataBase(currentItemName, currentQuantity);

        // Update the display
        outputText.text = $"Item Name: {currentItemName}\nQuantity: {currentQuantity}";
    }
}