using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCombatButton : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        GameObject.Find("globalManager").GetComponent<globalManager>().startCombat(cameraObject.GetComponent<cameraMovement>().selectedObject, cameraObject.GetComponent<cameraMovement>().selectedObject.GetComponent<enemyBuildingData>().difficulty, cameraObject.GetComponent<cameraMovement>().selectedObject.GetComponent<enemyBuildingData>().reward);
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
