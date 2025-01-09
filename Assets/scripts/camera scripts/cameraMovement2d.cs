using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement2d : MonoBehaviour
{
    Vector3 clickOrigin;
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Clicking() != null)
            {
               
            }
            else
            {
                gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x+(clickOrigin.x-Input.mousePosition.x) / 400,GameObject.Find("playerBase").transform.position.x+2, GameObject.Find("enemyBase").transform.position.x-2), 0, -2.709f);
            }
        }
        clickOrigin = Input.mousePosition;
    }
    private GameObject Clicking()
    {
        RaycastHit clicked;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out clicked) && clicked.collider.gameObject.tag == "Clickable")
        {
            return clicked.collider.gameObject;
        }
        else return null;
    }
}
