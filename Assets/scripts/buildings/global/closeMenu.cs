using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeMenu : MonoBehaviour
{
    void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        if (cameraObject.GetComponent<cameraMovement>().clicked == gameObject) 
        { 
            cameraObject.GetComponent<cameraMovement>().inMenu = false;
            Destroy(cameraObject.GetComponent<cameraMovement>().curMenu);
            gameObject.GetComponent<MonoBehaviour>().enabled = false;
        }
    }
}
