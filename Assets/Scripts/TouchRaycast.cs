using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRaycast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Vector3 targetPos;

    public Toggle toggle;
    public AudioRandomizer audioRandomizer;


    // Задаёт значение множителю денег
    [SerializeField]
    private int indexOne;
    [SerializeField]
    private int indexTwo;
    [SerializeField]
    private int indexThree;
    [SerializeField]
    private int indexFour;
    [SerializeField]
    private int indexFive;

    public ResetGameProgress resetGameProgress;
    public OblectSwapSystem oblectSwapSystem;

    public CoutParametrs cp;


    void Update()
    {
        ClickObject();
    }

    private void PurplePopActivate()
    {
        PopClick gg = hit.collider.GetComponent<PopClick>();
        gg.PopInClick();

    }


    private void ClickObject()
    {

        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0);
                ray = Camera.main.ScreenPointToRay(touch.position);

                Debug.DrawRay(ray.origin, ray.direction * 20);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.isTrigger)
                    {

                        if (hit.collider.tag == "PurplePop")
                        {

                            PurplePopActivate();
                            audioRandomizer.RandomizeAudio();

                            if (oblectSwapSystem.indexButton == 0)
                            {
                                cp.coutChange += indexOne * resetGameProgress.resetMultiplier;
                            }
                            else
                            {
                                if (oblectSwapSystem.indexButton == 1)
                                {
                                    cp.coutChange += indexTwo * resetGameProgress.resetMultiplier;
                                }
                                else
                                {
                                    if (oblectSwapSystem.indexButton == 2)
                                    {
                                        cp.coutChange += indexThree * resetGameProgress.resetMultiplier;
                                    }
                                    else
                                    {
                                        if (oblectSwapSystem.indexButton == 3)
                                        {
                                            cp.coutChange += indexFour * resetGameProgress.resetMultiplier;
                                        }
                                        else
                                        {
                                            if (oblectSwapSystem.indexButton == 4)
                                            {
                                                cp.coutChange += indexFive * resetGameProgress.resetMultiplier;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
