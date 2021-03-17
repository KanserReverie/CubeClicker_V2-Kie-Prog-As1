using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet_1 : MonoBehaviour
{
    // cost and level and current money
    private int Level = 0;
    private int cost;
    private int CurrentMoney;

    // all necasery inputs
    public TMP_Text LevelOutput;
    public TMP_Text CostOutput;
    public Button BuyPet;

    // Money variable gets in start
    public Money money;

    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<Money>();
        //money.MoneyValue

        cost = (Mathf.RoundToInt(Mathf.Pow(5, Level)));

        BuyPet.interactable = false;

        LevelOutput.text=("Level: " + Level);
        CostOutput.text =("$$" + cost.ToString("N0"));
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoney = money.MoneyValue;
        if (CurrentMoney >= cost)
        {
            BuyPet.interactable = true;
        }
        else
        {
            BuyPet.interactable = false;
        }
    }
    public void PurchasePet()
    {
        if (CurrentMoney>=cost)
        {
            money.MoneyLost(cost);
            Level++;
            cost = (Mathf.RoundToInt(Mathf.Pow(5, Level)));
        }
    }
}
