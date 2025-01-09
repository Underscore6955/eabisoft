
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningenemy : MonoBehaviour
{
    float spawnCooldown;
    [SerializeField] List<GameObject> enemies;
    private void startSpawn(int difficulty)
    {
        gameObject.GetComponent<healthAttack>().health = 200 + (difficulty - 1) * 100;
        spawnCooldown = 1000 / (0.5f * (difficulty-1)+1);
    }

    void FixedUpdate()
    {
        
    }
}
