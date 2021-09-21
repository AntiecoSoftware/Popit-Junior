using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlmitedMoney : MonoBehaviour
{
    public CoutParametrs CP;

    public void AddMoreCout()
    {
        CP.coutChange += 1000;
    }
}
