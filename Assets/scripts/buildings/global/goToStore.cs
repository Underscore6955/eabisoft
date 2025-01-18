using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToStore : MonoBehaviour
{
    [SerializeField] GameObject shopMenu;
    void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        Destroy(GameObject.FindGameObjectWithTag("Menu"));
        GameObject.Find("globalManager").GetComponent<globalManager>().openMenu(shopMenu);
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
