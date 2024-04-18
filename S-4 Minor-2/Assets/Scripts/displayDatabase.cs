using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayDatabase : MonoBehaviour
{
    private DatabaseAccess databaseAccess;

    private TextMeshPro output;

    void Start()
    {

        databaseAccess = GameObject.FindGameObjectsWithTag("DatabaseAccess")[0].GetComponent<DatabaseAccess>();
        output= GetComponentInChildren<TextMeshPro>();
        Invoke("DisplayOutput", 2f);


    }


    private async void DisplayOutput()
    {
        var task = databaseAccess.GetDataFromDataBase();
        var result = await task;
        var D_output = "";
        foreach (var quantity in result)
        {
            D_output += quantity.itemName + "Quantity : " + quantity.quantity + "\n";
        }
        output.text = D_output;

    } 
}
