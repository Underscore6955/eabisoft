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
    string attacked;
    int reward;
    public bool combatNow = false;
    public List<string> destroyedBuildings;
    public List<string> removedTrees;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject lossMenu;
    public bool inMenu;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public bool transaction(float curMoney, float cost)
    {
        if (cost <= curMoney) return true;
            return false;
    }
    public void startCombat(string curAttacked, float curDifficulty, int curReward)
    {
        difficulty = curDifficulty;
        attacked = curAttacked;
        reward = curReward;
        combatNow = true;
        SceneManager.LoadScene("inFight");
    }
    public void win()
    {
        gold += reward;
        destroyedBuildings.Add(attacked);
        combatNow = false;
        openMenu(winMenu);
    }
    public void loss()
    {
        combatNow = false;
        openMenu(lossMenu);
    }
    public void openMenu(GameObject Menu)
    {
        inMenu = true;
        Instantiate(Menu, FindObjectOfType<Camera>().gameObject.transform.position + FindObjectOfType<Camera>().gameObject.transform.forward, FindObjectOfType<Camera>().gameObject.transform.rotation * Quaternion.Euler(0, 0, 0));
    }
    void Update()
    {
        foreach (GameObject curObj in GameObject.FindGameObjectsWithTag("Clickable")) { if (removedTrees.Contains(curObj.transform.parent.gameObject.name) || destroyedBuildings.Contains(curObj.transform.parent.gameObject.name)) { Destroy(curObj.transform.parent.gameObject); }}
    }
}
