using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageSelector : MonoBehaviour
{
    public ResetGameProgress mainMenuMultiplier;

    public void LanguageEN()
    {
        mainMenuMultiplier.resetTextInUI = "Multiplier: x";
    }

    public void LanguageRU()
    {
        mainMenuMultiplier.resetTextInUI = "Множитель: x";

    }
}
