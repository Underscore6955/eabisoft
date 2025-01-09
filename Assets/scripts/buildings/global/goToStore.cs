using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToStore : MonoBehaviour
{
    [SerializeField] GameObject shopMenu;
    void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        Destroy(cameraObject.GetComponent<cameraMovement>().curMenu);
        cameraObject.GetComponent<cameraMovement>().curMenu = Instantiate(shopMenu, cameraObject.transform.position + new Vector3(0.55f, -1.3f, 0.55f), Quaternion.Euler(-30, 45, 0));
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
