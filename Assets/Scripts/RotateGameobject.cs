using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGameobject : MonoBehaviour
{
    public float speed;

    public GameObject rotateObj;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateObj.transform.Rotate(new Vector3(0f, speed));
    }
}
