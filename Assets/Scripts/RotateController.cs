using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public Transform cube;
    private Ray ray;
    private RaycastHit hit;
    public float rotateSpeedModify = 0.5f;


    void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);
                ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.isTrigger)
                    {

                        if (hit.collider.tag == "RotateZone")
                        {
                            cube.transform.Rotate(0f, touch0.deltaPosition.x * rotateSpeedModify, 0f);
                        }
                    }
                }

            }

        }
    }
}
