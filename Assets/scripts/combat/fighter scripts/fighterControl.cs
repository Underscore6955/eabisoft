using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class fighterControl : MonoBehaviour
{
    [SerializeField] public int dir;
    [SerializeField] float speed;
    [SerializeField] int range;
    float walkrange = 0.5f;
    [SerializeField] AnimationClip walking;
    [SerializeField] AnimationClip standing;
    public AnimationClip attacking;
    [SerializeField] GameObject sprite;
    public Animator anim;
    private void Start()
    {
        anim = sprite.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (!GameObject.Find("globalManager").GetComponent<globalManager>().combatNow || gameObject.tag == "Base") return;
        if (tag == "Fighter" && !Physics.Raycast(transform.position, new Vector3(dir, 0, 0), walkrange) && checkForEnemy() == null)
        {
            gameObject.transform.position += new Vector3(dir * speed * 0.001f, 0, 0);
            anim.SetBool("walking", true);
        }
        else anim.SetBool("walking", false);
    }
    public GameObject checkForEnemy()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, new Vector3(dir, 0, 0), range * 0.5f);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.transform.parent.tag == "Base" || hit.collider.GetComponentInParent<fighterControl>().dir == -dir) { return hit.collider.transform.parent.gameObject; }
        }
        return null;
    }
}
