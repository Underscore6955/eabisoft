using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeTHig : MonoBehaviour
{
    void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
    }
}
