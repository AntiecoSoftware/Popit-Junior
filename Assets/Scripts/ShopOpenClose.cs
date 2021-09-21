using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpenClose : MonoBehaviour
{
    [SerializeField]
    private GameObject shopInterface;
    public void ShopOpen()
    {
        shopInterface.SetActive(true);
    }
    public void ShopClose()
    {
        shopInterface.SetActive(false);
    }
}
