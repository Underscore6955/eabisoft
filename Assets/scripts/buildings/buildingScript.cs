using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingScript : MonoBehaviour
{
    [SerializeField] GameObject buildingMenu;
    [SerializeField] GameObject cameraObject;
    void OnEnable()
    {
        cameraObject.GetComponent<cameraMovement>().inMenu = true;
        cameraObject.GetComponent<cameraMovement>().curMenu = Instantiate(buildingMenu, cameraObject.transform.position + new Vector3(0.55f, -1.3f, 0.55f), Quaternion.Euler(-30, 45, 0));
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
