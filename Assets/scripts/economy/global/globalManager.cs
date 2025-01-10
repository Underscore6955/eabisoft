using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalManager : MonoBehaviour
{
    public int gold;
    public int gems;
    public float difficulty;
    GameObject attacked;
    int reward;
    public List<string> destroyedBuildings;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public bool transaction(float curMoney, float cost)
    {
        if (cost <= curMoney) return true;
            return false;
    }
    public void startCombat(GameObject curAttacked, float curDifficulty, int curReward)
    {
        difficulty = curDifficulty;
        attacked = curAttacked;
        reward = curReward;
        SceneManager.LoadScene("inFight");
    }
    public void win()
    {
        gold += reward;
        destroyedBuildings.Add(attacked.name);
    }
    public void loss()
    {

    }
}
