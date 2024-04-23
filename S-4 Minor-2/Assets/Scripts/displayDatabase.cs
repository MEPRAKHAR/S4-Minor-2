/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class displayDatabase : MonoBehaviour
{
    private DatabaseAccess databaseAccess;

    private TextMeshPro output;

    void Start()
    {

        Button[] buttons = FindObjectsOfType<Button>();

        // Attach the onClick listener to each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => DisplayOutput(button.name));
        }

        databaseAccess = GameObject.FindGameObjectsWithTag("DatabaseAccess")[0].GetComponent<DatabaseAccess>();
        output= GetComponentInChildren<TextMeshPro>();
        Invoke("DisplayOutput", 2f);




    }
    async private void OnClick(string buttonName)
    {
        var task = databaseAccess.GetDataFromDataBase(buttonName);
        var result = await task;

        // Print the fetched data
        Debug.Log("Data fetched for button " + buttonName + ":");

        foreach (var quantity in result)
        {
            Debug.Log(quantity.itemName + " Quantity : " + quantity.quantity);
        }
        var D_output = "";

        // Display the data in the UI
        foreach (var quantity in result)
        {
            D_output += quantity.itemName + "Quantity : " + quantity.quantity + "\n";
        }
        output.text = D_output;

    }

    private async void DisplayOutput(string buttonName)
    {

        var task = databaseAccess.GetDataFromDataBase(buttonName);
        var result = await task;

        // Print the fetched data
        Debug.Log("Data fetched for button " + buttonName + ":");

        foreach (var quantity in result)
        {
            Debug.Log(quantity.itemName + " Quantity : " + quantity.quantity);
        }
        var D_output = "";

        // Display the data in the UI
        foreach (var quantity in result)
        {
            D_output += quantity.itemName + "Quantity : " + quantity.quantity + "\n";
        }
        output.text = D_output;

    } 
}*/
