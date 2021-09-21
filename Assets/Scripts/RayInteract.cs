using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteract : MonoBehaviour
{
    public float fireRate = 0.25f;
    public float range = 50;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.7f);

    
    private float nextFire;
    

    void Start()
    {
        
        fpsCam = GetComponentInParent<Camera>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)); //луч из центра

            RaycastHit hit;



            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
            {
                if (hit.collider.isTrigger )
                {
                    hit.collider.isTrigger = true;
                    nextFire = Time.time + fireRate;  // задаётся КД нажатий
                    StartCoroutine(ShotEffect());
                    Debug.Log("Активация триггера");

                }
            }
        
        }


    }

    private IEnumerator ShotEffect ()
    {

        yield return shotDuration;

    }
}
