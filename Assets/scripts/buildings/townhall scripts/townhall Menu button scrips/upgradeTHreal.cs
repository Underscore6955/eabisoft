using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeTHreal : MonoBehaviour
{
    void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }

}
