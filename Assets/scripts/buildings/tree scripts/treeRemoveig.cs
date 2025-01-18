using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class treeRemoveig : MonoBehaviour
{
    float price = 100;
    void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        if (GameObject.Find("globalManager").GetComponent<globalManager>().transaction(GameObject.Find("globalManager").GetComponent<globalManager>().gold, price)) { 
            GameObject.Find("globalManager").GetComponent<globalManager>().removedTrees.Add(cameraObject.GetComponent<cameraMovement>().selectedObject.transform.parent.gameObject.name); 
            GameObject.Find("globalManager").GetComponent<globalManager>().gold -= 100;
            GameObject.Find("globalManager").GetComponent<globalManager>().inMenu = false;
            Destroy(GameObject.FindGameObjectWithTag("Menu"));
        }
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
