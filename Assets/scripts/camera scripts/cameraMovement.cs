using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraMovement : MonoBehaviour
{
    Vector2 clickOrigin;
    int holdTime;
    public GameObject clicked = null;
    public bool inMenu = false;
    float zoom = 1;
    [SerializeField] float maxZoom;
    [SerializeField] float minZoom;
    public GameObject curMenu;
    public GameObject selectedObject;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0)) { clicked = Clicking(); holdTime = 0; clickOrigin = Input.mousePosition; }
            holdTime++;
            if (clicked != null && holdTime <50) { return; }
            if (!inMenu)
            {
                gameObject.transform.position += new Vector3(clickOrigin.x - Input.mousePosition.x + (clickOrigin.y - Input.mousePosition.y), 0, clickOrigin.y - Input.mousePosition.y - (clickOrigin.x - Input.mousePosition.x)) * (zoom+1)  / 400;
                clickOrigin = Input.mousePosition;
            }
        }
        else if(holdTime < 100 && holdTime > 0 && clicked != null) 
        {
            holdTime = 0;
            clicked.gameObject.GetComponent<MonoBehaviour>().enabled = true; 
            if (!inMenu) { selectedObject = clicked; }
        }
        if (!inMenu)
        {
            zoom = Mathf.Clamp(zoom -= Input.GetAxisRaw("Mouse ScrollWheel"), maxZoom, minZoom);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, zoom * 3, gameObject.transform.position.z);
        }
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
