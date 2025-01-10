using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToFullMap : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        SceneManager.LoadScene("fullMap");
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
