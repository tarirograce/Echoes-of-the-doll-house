// Written by Swornashabi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public GameObject ammoTextUI;
    public int pistolCount;
    void Update()
    {
        ammoTextUI.GetComponent<TextMeshProUGUI>().text = "AMMO: " + pistolCount;
        
    }
}
