using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ButtonClickHandler : MonoBehaviour
{
    public Button yourButton; // Assign your button in the Inspector
    public DatabaseAccess databaseAccess; // Reference to the DatabaseAccess script
    public Text outputText; // UI Text component to display the output

    void Start()
    {
        // Add a listener to the button click event
        yourButton.onClick.AddListener(HandleButtonClick);
    }

    async void HandleButtonClick()
    {
        // Assuming the button's name is used as the keyName parameter
        string keyName = yourButton.name;
        List<Available> items = await databaseAccess.GetDataFromDataBase(keyName);

        

     
        // Display the output in the UI Text component
        string output = "";
        foreach (var item in items)
        {
            output += $"Item Name: {item.itemName}, Quantity: {item.quantity}\n";
        }
        outputText.text = output;
    }
}