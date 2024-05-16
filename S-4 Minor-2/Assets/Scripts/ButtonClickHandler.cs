using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ButtonClickHandler : MonoBehaviour
{
    public Button yourButton; 
    public Button increaseButton; 
    public Button decreaseButton; 
    public DatabaseAccess databaseAccess; 
    public TMP_Text outputText; 

    private string currentItemName; 
    private int currentQuantity; 

    void Start()
    {
        
        yourButton.onClick.AddListener(HandleButtonClick);

        
        increaseButton.onClick.AddListener(IncreaseQuantity);
        decreaseButton.onClick.AddListener(DecreaseQuantity);
        
    }

    async void HandleButtonClick()
    {
       
        string keyName = yourButton.name;
        List<Available> items = await databaseAccess.GetDataFromDataBase(keyName);

        
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