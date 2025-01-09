using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moraleBar : MonoBehaviour
{
    void Update()
    {
        float progress = (float)FindObjectOfType<Camera>().gameObject.GetComponent<inCombat>().morale / 2000;
        transform.localScale = new Vector3(progress * 0.323f, transform.localScale.y, transform.localScale.z);
        transform.localPosition = new Vector3(-1.622f+1.622f*progress, transform.localPosition.y, transform.localPosition.z);
    }
}
