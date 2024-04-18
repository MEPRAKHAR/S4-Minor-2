using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    private DatabaseAccess databaseAccess;
    private int keyCount;

    void Start()
    {
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
        databaseAccess = GameObject.FindGameObjectsWithTag("DatabaseAccess")[0].GetComponent<DatabaseAccess>();
        keyCount = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();
        if (key.text == "+")
        {
            keyCount++;
            playerTextOutput.text = keyCount.ToString();
            databaseAccess.SaveDataToDataBase("Fan", keyCount);
        }
    }
}