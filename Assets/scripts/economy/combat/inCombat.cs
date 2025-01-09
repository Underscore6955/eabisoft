using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inCombat : MonoBehaviour
{
    public int morale;
    [SerializeField] TMP_Text moraleText;
    void FixedUpdate()
    {
        morale+=10;
        morale = Mathf.Clamp(morale, -10, 2000);
    }
    void Update()
    {
        moraleText.text = (int)morale / 10 + "/200";
        checkForClick();
    }
    void checkForClick()
    {
        RaycastHit clicked;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out clicked) && clicked.collider.gameObject.tag == "Clickable" && Input.GetMouseButtonDown(0))
        {
            clicked.collider.GetComponent<SummonButton>().enabled = true;
        }
    }
}
