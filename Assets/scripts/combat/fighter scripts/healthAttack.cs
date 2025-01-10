using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class healthAttack : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] float damage;
    [SerializeField] int attackSpeed;
    int attackTime;
    void Start()
    {
       
    }
    void FixedUpdate()
    {
        var fightScript = gameObject.GetComponent<fighterControl>();
        if (health <= 0) Destroy(gameObject);
        attackTime--;
        if (fightScript.checkForEnemy() != null && attackTime <=0) attack(fightScript.checkForEnemy());
    }
    void attack(GameObject attacked)
    {
        attackTime = attackSpeed;
        Debug.Log(gameObject + " attacked " + attacked);
        attacked.GetComponent<healthAttack>().health-=damage;
    }
    private void OnDestroy()
    {
        if (gameObject.name == "enemyBase") { GameObject.Find("globalManager").GetComponent<globalManager>().win(); } else GameObject.Find("globalManager").GetComponent<globalManager>().loss();
    }
}
