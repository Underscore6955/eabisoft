using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fighterControl : MonoBehaviour
{
    [SerializeField] public int dir;
    [SerializeField] float speed;
    [SerializeField] int range;
    float walkrange = 0.5f;
    void FixedUpdate()
    {
        if (tag == "Fighter" && !Physics.Raycast(transform.position,new Vector3(dir,0,0),walkrange) && checkForEnemy() == null )
        {
            gameObject.transform.position += new Vector3(dir * speed * 0.001f, 0, 0);
        }
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
