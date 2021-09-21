using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetGameProgress : MonoBehaviour
{
    public CoutParametrs cout;
    public string resetTextInUI;
    public TextMeshProUGUI resetText;
    public TextMeshProUGUI resetTextMainUi;

    public AdGoogleReward ads;

    public int resetMultiplier;
    public int resetMultiplierChange;
    public OblectSwapSystem oblect;
    public SaveLoadPrefsGame save;

    public GameObject resetUiMenu;

    private void Start()
    {
        ShowResetUiElement();
        NoResetUiMenu();
        resetTextMainUi.text = resetTextInUI + resetMultiplier;
    }

    private void Update()
    {
        if(resetMultiplierChange != resetMultiplier)
        {
            resetTextMainUi.text = resetTextInUI + resetMultiplier;
            resetMultiplierChange = resetMultiplier;
            Debug.Log("Reset update log");
        }
    }

    public void ShowResetUiElement()
    {
        resetUiMenu.SetActive(true);
        if (oblect.ClassicPopitBuyed == true)
        {
            resetMultiplier += 1;
        }
        if (oblect.AmongasPopitBuyed == true)
        {
            resetMultiplier += 1;
        }

        resetText.text = "Cost: 25.000.000. If you reset your progress, the multiplier will be: " + resetMultiplier;
    }
    public void YesResetUiMenu()
    {
        if(cout.coutMain >= 25000000)
        {
            if (ads.multiplierCorutineEnabled == false)
            {
                save.ResetData();
                save.fullReset.isOn = false;
                resetUiMenu.SetActive(false);
            }
            Debug.Log("Indicator ads Active: " + ads.multiplierCorutineEnabled.ToString());
            Debug.Log("Cout Main: " + cout.clickMain.ToString());

        }
        if (ads.multiplierCorutineEnabled == false)
        {
            if (save.fullReset.isOn == true)
            {
                save.ResetData();
                save.fullReset.isOn = false;
                resetUiMenu.SetActive(false);
            }
        }
            

    }
    public void NoResetUiMenu()
    {
        if (oblect.ClassicPopitBuyed == true)
        {
            resetMultiplier -= 1;
        }
        if (oblect.AmongasPopitBuyed == true)
        {
            resetMultiplier -= 1;
        }
        save.fullReset.isOn = false;
        resetUiMenu.SetActive(false);
    }
}
