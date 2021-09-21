using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTapDownOblect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 tapScreen = Camera.main.ScreenToWorldPoint(touch.position);
                transform.position = tapScreen;

                Debug.Log("Tap cout");
            }
        }
    }
}
