using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buildingScript : MonoBehaviour
{
    [SerializeField] GameObject buildingMenu;
    [SerializeField] GameObject cameraObject;
    void OnEnable()
    {
        if (GameObject.Find("globalManager").GetComponent<globalManager>().inMenu) return;
        GameObject.Find("globalManager").GetComponent<globalManager>().openMenu(buildingMenu);
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
