using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraMovement2d : MonoBehaviour
{
    Vector3 clickOrigin;
    int timeSinceClick=10;
    [SerializeField] Transform playerBase;
    [SerializeField] Transform enemyBase;
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Clicking() == null)
        {
            if (timeSinceClick < 10)
            {
                if (transform.position.x - playerBase.position.x < 0.5f * playerBase.position.x - enemyBase.position.x)
                {
                    if (Mathf.Abs(transform.position.x - playerBase.position.x) < 6) { gameObject.transform.position = new Vector3(enemyBase.position.x + 2, transform.position.y, transform.position.z); }
                    else gameObject.transform.position = new Vector3(playerBase.position.x - 2, transform.position.y, transform.position.z);
                }
                else
                {
                    if (Mathf.Abs(transform.position.x - enemyBase.position.x) < 6) { gameObject.transform.position = new Vector3(playerBase.position.x - 2, transform.position.y, transform.position.z); }
                    else gameObject.transform.position = new Vector3(enemyBase.position.x + 2, transform.position.y, transform.position.z);
                }
            }
            timeSinceClick = 0;
        }
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
    private void FixedUpdate()
    {
        timeSinceClick++;
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
