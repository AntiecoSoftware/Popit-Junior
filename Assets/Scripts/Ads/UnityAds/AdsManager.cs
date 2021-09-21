using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;
    private string _gameId = "4288259";

    public bool multiplierCorutineEnabled = false;
    public ResetGameProgress resetGameProgress;
    public Button x2MultiplierBtn;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }
    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Объявление не готово");
        }
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        // Когда реклама готова
        if(multiplierCorutineEnabled == false)
        {
            x2MultiplierBtn.interactable = true;
        }
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        // Ошибка рекламы
        Debug.LogError("Ads Error: " + message);
        x2MultiplierBtn.interactable = false;
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        // Старт рекламы
        x2MultiplierBtn.interactable = false;
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            resetGameProgress.resetMultiplier *= 2;
            StartCoroutine(RewardedTimer());
            Debug.Log("x2 enabled");

            multiplierCorutineEnabled = true;
            x2MultiplierBtn.interactable = false;
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Skipped");
            x2MultiplierBtn.interactable = true;
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("failed");
            x2MultiplierBtn.interactable = false;
        }
    }

    IEnumerator RewardedTimer()
    {
        //Debug.Log("Corutine enabled");
        yield return new WaitForSeconds(60);
        //Debug.Log("Corutine disabled");

        multiplierCorutineEnabled = false;
        x2MultiplierBtn.interactable = true;
        resetGameProgress.resetMultiplier /= 2;
    }
}


