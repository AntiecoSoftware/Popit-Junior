using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartShadowAnim : MonoBehaviour
{
    public Animator animation;
    public RawImage image;
    public GameObject animObj;
    // Start is called before the first frame update
    void Start()
    {
        animation.Play("StartShadowAnim");
    }

    private void Update()
    {
        if(image.color.a == 0)
        {
            animObj.SetActive(false);
        }
    }
}
