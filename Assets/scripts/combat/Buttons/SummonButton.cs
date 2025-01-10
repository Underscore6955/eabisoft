using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SummonButton : MonoBehaviour
{
    [SerializeField] GameObject summon;
    [SerializeField] int price;
    [SerializeField] GameObject spawnpoint;
    [SerializeField] TMP_Text priceText;
    bool started;
    private void Start()
    {
        priceText.text = ((int) price/10).ToString();
        gameObject.GetComponent<SummonButton>().enabled = false;
        started = true;
    }
    private void OnEnable()
    {
        if (!started) return;
        var inCombat = FindObjectOfType<Camera>().gameObject.GetComponent<inCombat>();
        var moneyScript = GameObject.Find("globalManager").GetComponent<globalManager>();
        if (moneyScript.transaction(inCombat.morale, price))
        {
            if (!Physics.CheckBox(spawnpoint.transform.position, new Vector3(0.4f, 0.01f, 0.01f)))
            {
                inCombat.morale -= price;
                GameObject.Instantiate(summon, spawnpoint.transform.position, Quaternion.Euler(270, 0, 0));
            }
        }
        gameObject.GetComponent<SummonButton>().enabled = false;
    }
}
