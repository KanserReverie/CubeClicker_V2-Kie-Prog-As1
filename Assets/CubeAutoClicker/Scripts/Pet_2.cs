using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet_2 : MonoBehaviour
{
    // cost and level and current money
    private int Level = 0;
    private int cost;
    private int CurrentMoney;
    private int MaxLevel=20;

    // all necasery inputs
    public TMP_Text LevelOutput;
    public TMP_Text CostOutput;
    public Button BuyPet;

    // Money variable gets in start
    public Money money;
    public CubeHandler cubeHandler;

    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<Money>();
        cubeHandler = FindObjectOfType<CubeHandler>();
        //money.MoneyValue

        cost = (Mathf.RoundToInt(100 * (Mathf.Pow(1.6f, Level))));

        BuyPet.interactable = false;

        LevelOutput.text = ("Level: " + Level);
        CostOutput.text = ("$$" + cost.ToString("N0"));
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoney = money.MoneyValue;

        if (CurrentMoney >= cost && Level<MaxLevel)
        {
            BuyPet.interactable = true;
        }
        else if (CurrentMoney < cost && Level<MaxLevel)
        {
            BuyPet.interactable = false;
        }
        else if (Level>=MaxLevel)
        {
            BuyPet.interactable = false;
            CostOutput.text = ("MAX!!");
        }
    }
    public void PurchasePet()
    {
        if (CurrentMoney >= cost)
        {
            if(Level == 0)
            {
                StartCoroutine(FarmingClicks());
            }
            money.MoneyLost(cost);
            Level++;
            cost = (Mathf.RoundToInt(100 * (Mathf.Pow(1.6f, Level))));
            LevelOutput.text = ("Level: " + Level);
            CostOutput.text = ("$$" + cost.ToString("N0"));
        }
    }

    private IEnumerator FarmingClicks()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.1f - Level*0.2f);
            cubeHandler.Click();
        }
    }
}
