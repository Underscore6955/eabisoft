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
            GameObject.Find("globalManager").GetComponent<globalManager>().inMenu = false;
            Destroy(GameObject.FindGameObjectWithTag("Menu"));
            gameObject.GetComponent<MonoBehaviour>().enabled = false;
        }
    }
}
