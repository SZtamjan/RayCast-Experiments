using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasterTwo : MonoBehaviour
{
    public LayerMask layer;
    public LayerMask ignoreLayer;
    public GameObject dbgr;
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (((1 << hit.collider.gameObject.layer) & ignoreLayer) != 0)
            {
                ray.origin = hit.point + ray.direction * 0.01f;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    MoveDbgr(hit);
                }
            }
            else
            {
                MoveDbgr(hit);
            }
        }
        Debug.DrawRay(ray.origin,ray.direction);
    }
    void MoveDbgr(RaycastHit hit)
    {
        if (((1 << hit.collider.gameObject.layer) & layer) != 0)
        {
            Debug.Log("Trafiono obiekt1: " + hit.collider.gameObject.name);
            dbgr.transform.position = hit.point;
        }
    }
}
