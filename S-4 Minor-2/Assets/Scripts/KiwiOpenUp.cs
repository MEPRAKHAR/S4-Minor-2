using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiOpenUp : MonoBehaviour
{
    public GameObject Panel;

    public void openPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
}
