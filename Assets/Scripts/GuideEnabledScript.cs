using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideEnabledScript : MonoBehaviour
{
    public Animator anim;
    public bool showGuide;
    public GameObject AnimatorEnabled;
    public GameObject textRestartGame;

    private void Start()
    {
        LoadShowedOrNo();
        if (showGuide == true)
        {
            anim.Play("GuideAnim");
            showGuide = false;
            AnimatorEnabled.SetActive(true);
            SaveShowedOrNo();
        }
        else
        {
            AnimatorEnabled.SetActive(false);
        }
    }
    public void ShowGuideAgain()
    {
        showGuide = true;
        textRestartGame.SetActive(true);
        SaveShowedOrNo();
    }

    public void SaveShowedOrNo()
    {
        PlayerPrefs.SetInt("ShowGuideOrNo", showGuide ? 1 : 0);
    }

    public void LoadShowedOrNo()
    {
        showGuide = PlayerPrefs.GetInt("ShowGuideOrNo") == 1 ? true : false;
    }
}
