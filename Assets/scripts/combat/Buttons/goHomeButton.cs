using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goHomeButton : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject cameraObject = FindObjectOfType<Camera>().gameObject;
        SceneManager.LoadScene("homeBase");
        gameObject.GetComponent<MonoBehaviour>().enabled = false;
    }
}
