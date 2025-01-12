
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    float spawnCooldownC;
    int spawnCooldown;
    [SerializeField] GameObject spawnpoint;
    [SerializeField] List<GameObject> enemies;
    private void Start()
    {
        startSpawn(GameObject.Find("globalManager").GetComponent<globalManager>().difficulty);
    }
    public void startSpawn(float difficulty)
    {
        gameObject.GetComponent<healthAttack>().health = 200 + (difficulty - 1) * 100;
        spawnCooldownC = 1000 / (0.5f * (difficulty-1)+1);
    }

    void FixedUpdate()
    {
        if (!GameObject.Find("globalManager").GetComponent<globalManager>().combatNow) return;
        if (spawnCooldown > spawnCooldownC) { Instantiate(enemies[Random.Range(0, enemies.Count)], spawnpoint.transform.position, Quaternion.Euler(270, 0, 0)); spawnCooldown = 0; }
        spawnCooldown++;
    }
}
