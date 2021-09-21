using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CoutParametrs : MonoBehaviour
{
    public int coutMain;
    public int coutChange;

    public int clickMain;

    [SerializeField]
    private TextMeshProUGUI tmProUpdateCout;

    [SerializeField]
    private TextMeshProUGUI tmProUpdateClick;

   
    // Update is called once per frame
    void Update()
    {
        // Обновляет счетчик очков
        if (coutMain != coutChange)
        {
            coutMain = coutChange;
            tmProUpdateCout.text = coutMain.ToString();

            clickMain += 1;
            tmProUpdateClick.text = clickMain.ToString();
        }
    }
}
