using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;


public class AdGoogleReward : MonoBehaviour
{

    public bool multiplierCorutineEnabled = false;
    public ResetGameProgress resetGameProgress;
    public Button x2MultiplierBtn;
    public TMPro.TextMeshProUGUI errorMassage;

    private RewardedAd rewardedAd;
    private void Start()
    {
        RequestAndLoadRewardedAd();
    }
    public void RequestAndLoadRewardedAd()
    {
        string adUnitId = "ca-app-pub-9695662490382425/7023181809";

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        // Когда реклама готова
        if (multiplierCorutineEnabled == false)
        {
            x2MultiplierBtn.interactable = true;
        }
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        x2MultiplierBtn.interactable = false;
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        x2MultiplierBtn.interactable = false;
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        resetGameProgress.resetMultiplier *= 2;
        StartCoroutine(RewardedTimer());

        multiplierCorutineEnabled = true;
        x2MultiplierBtn.interactable = false;
    }

    public void ShowRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            errorMassage.text = "Active";

        }
        else
        {
            errorMassage.text = "NO ADS";
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
        errorMassage.text = " ";
    }
}