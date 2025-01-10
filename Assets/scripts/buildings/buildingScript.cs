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
        if (cameraObject.GetComponent<cameraMovement>().inMenu) return;
        cameraObject.GetComponent<cameraMovement>().inMenu = true;
        cameraObject.GetComponent<cameraMovement>().curMenu = Instantiate(buildingMenu, cameraObject.transform.position + cameraObject.transform.forward*1.5f, Quaternion.Euler(cameraObject.transform.eulerAngles.x - 90, 45, 0));
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
