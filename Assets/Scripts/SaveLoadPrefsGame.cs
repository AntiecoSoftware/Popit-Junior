using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadPrefsGame : MonoBehaviour
{
    public CoutParametrs cout;
    public AdGoogleReward adsManager;
    public ResetGameProgress resetGameProgress;
    public Toggle fullReset;
    public OblectSwapSystem oblectSwapSystem;
    public BtnBuyIndicator btnBuyIndicator;
    private void Start()
    {
        LoadGame();
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
            //Debug.Log("Save pause Done!");
            if(adsManager.multiplierCorutineEnabled == true)
            {
                resetGameProgress.resetMultiplier /= 2;
                SaveGame();
            }
            else
            {
                SaveGame();
            }
        }
    }
    private void OnApplicationQuit()
    {
        //Debug.Log("Save quit Done!");
        if (adsManager.multiplierCorutineEnabled == true)
        {
            resetGameProgress.resetMultiplier /= 2;
            SaveGame();
        }
        else
        {
            SaveGame();
        }
    }


    // Сохранение значений счетчика игрока и игровых покупок
    public void SaveGame()
    {

        PlayerPrefs.SetInt("Cout", cout.coutMain);
        PlayerPrefs.SetInt("Clicks", cout.clickMain);
        PlayerPrefs.SetInt("ResetMultiplier", resetGameProgress.resetMultiplier);
        PlayerPrefs.SetInt("ToysIndex", oblectSwapSystem.indexButton);

        SavePopitBuyed();

        PlayerPrefs.Save();
        //Debug.Log("Game data saved!");
    }
    // Загрузка счетчика игрока и игровых покупок
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Cout"))
        {
            cout.coutChange = PlayerPrefs.GetInt("Cout");
            cout.clickMain = PlayerPrefs.GetInt("Clicks");
            resetGameProgress.resetMultiplier = PlayerPrefs.GetInt("ResetMultiplier");
            oblectSwapSystem.indexButton = PlayerPrefs.GetInt("ToysIndex");

            LoadPopitBuyed();

            //Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");

    }
    // Сброс всех данных.
    public void ResetData()
    {

        PlayerPrefs.DeleteAll();
        // Сбрасывает значение множителя при активной галочке "Полное сбрасывание".
        if(fullReset.isOn == true)
        {
            resetGameProgress.resetMultiplier = 1;
        }
        oblectSwapSystem.FivePopitBuyed = false;
        oblectSwapSystem.NinePopitBuyed = false;
        oblectSwapSystem.ClassicPopitBuyed = false;
        oblectSwapSystem.AmongasPopitBuyed = false;
        btnBuyIndicator.AllCallBought();
        oblectSwapSystem.indexButton = 0;
        cout.coutChange = 0;
    
        //Debug.Log("Game data Reset!");
    }

    private void SavePopitBuyed()
    {
        
        // Сохранение покупок игрока
        PlayerPrefs.SetInt("FivePopitBued", oblectSwapSystem.FivePopitBuyed ? 1 : 0);
        PlayerPrefs.SetInt("NinePopitBued", oblectSwapSystem.NinePopitBuyed ? 1 : 0);
        PlayerPrefs.SetInt("ClassicPopitBued", oblectSwapSystem.ClassicPopitBuyed ? 1 : 0);
        PlayerPrefs.SetInt("AmongasPopitBued", oblectSwapSystem.AmongasPopitBuyed ? 1 : 0);
        
    }
    private void LoadPopitBuyed()
    {
        
        oblectSwapSystem.FivePopitBuyed = PlayerPrefs.GetInt("FivePopitBued") == 1 ? true : false;
        oblectSwapSystem.NinePopitBuyed = PlayerPrefs.GetInt("NinePopitBued") == 1 ? true : false;
        oblectSwapSystem.ClassicPopitBuyed = PlayerPrefs.GetInt("ClassicPopitBued") == 1 ? true : false;
        oblectSwapSystem.AmongasPopitBuyed = PlayerPrefs.GetInt("AmongasPopitBued") == 1 ? true : false;
    }
}
