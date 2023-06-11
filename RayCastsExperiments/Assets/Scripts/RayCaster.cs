using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public Camera cam;
    public GameObject debugerO;
    public GameObject debugerT;
    public float raycastDistance;
    public LayerMask lejer;
    Vector3 forw = Vector3.forward;
    private void Update()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z += 10f;
        // debugerO.transform.position = cursorPos;
        // Vector3 target = cam.ScreenToWorldPoint(cursorPos);
        // debugerT.transform.position = target;
        // Ray ray = new Ray(cam.transform.position,target);
        // Debug.DrawRay(cam.transform.position,target);

        print(lejer.value);
        Ray ray = cam.ScreenPointToRay(cursorPos);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            
            if (((1<<hit.collider.gameObject.layer) & lejer) != 0)
            {
                Debug.Log("Trafiono obiekt: " + hit.collider.gameObject.name);
            }
        }
        //Debug.Log(hit.collider.gameObject.layer);
        Debug.DrawRay(ray.origin,ray.direction);
    }
}
