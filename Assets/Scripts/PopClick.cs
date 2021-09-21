using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PopClick : MonoBehaviour
{

    [SerializeField]
    private GameObject PopIn;
    [SerializeField]
    private GameObject PopUp;
    

    public void PopInClick ()
    {


        if (PopIn.activeSelf == true)
        {
            //Debug.Log("PopUp on || PipIn off");
            PopIn.gameObject.SetActive(false);
            PopUp.gameObject.SetActive(true);


        }
        else
        {
            //Debug.Log("PopUp off || PipIn on");

            PopUp.gameObject.SetActive(false);
            PopIn.gameObject.SetActive(true);

            
        }

    }
}
