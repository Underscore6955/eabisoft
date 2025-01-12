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
        if (!GameObject.Find("globalManager").GetComponent<globalManager>().combatNow) return;
        var fightScript = gameObject.GetComponent<fighterControl>();
        if (health <= 0) destroyCur();
        attackTime--;
        if (fightScript.checkForEnemy() != null && attackTime <=0) attack(fightScript.checkForEnemy());
    }
    void attack(GameObject attacked)
    {
        gameObject.GetComponent<fighterControl>().anim.Play("attack");
        attackTime = attackSpeed;
        Debug.Log(gameObject + " attacked " + attacked);
        attacked.GetComponent<healthAttack>().health-=damage;
    }
    private void destroyCur()
    {
        if (gameObject.tag != "Base") { Destroy(gameObject); return; }
        if (gameObject.name == "enemyBase") { GameObject.Find("globalManager").GetComponent<globalManager>().win(); Debug.Log("funk"); } else GameObject.Find("globalManager").GetComponent<globalManager>().loss();
    }
}
