using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyScript : MonoBehaviour
{
    public int gold;
    public int gems;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        
    }
    public bool transaction(float curMoney, float cost)
    {
        if (cost <= curMoney) return true;
            return false;
    }
}
