using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet_4 : MonoBehaviour
{
    // cost and level and current money
    private int Level = 0;
    private int cost;
    private int CurrentMoney;
    private int MaxLevel = 6;

    // all necasery inputs
    public TMP_Text LevelOutput;
    public TMP_Text CostOutput;
    public Button BuyPet;

    // Money variable gets in start
    public Money money;
    public CubeHandler cubeHandler;
    public GameObject Locked2;

    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<Money>();
        cubeHandler = FindObjectOfType<CubeHandler>();
        //money.MoneyValue

        cost = (Mathf.RoundToInt(5000 * (Mathf.Pow(1.5f, Level))));

        BuyPet.interactable = false;

        LevelOutput.text = ("Level: " + Level);
        CostOutput.text = ("$$" + cost.ToString("N0"));
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoney = money.MoneyValue;
        if (CurrentMoney > 5001)
        {
            Locked2.SetActive(false);
        }

        CurrentMoney = money.MoneyValue;
        if (CurrentMoney >= cost && Level < MaxLevel)
        {
            BuyPet.interactable = true;
        }
        else if(CurrentMoney < cost && Level < MaxLevel)
        {
            BuyPet.interactable = false;
        }
        else if (Level >= MaxLevel)
        {
            BuyPet.interactable = false;
            CostOutput.text = ("MAX!!");
        }
    }
    public void PurchasePet()
    {
        if (CurrentMoney >= cost)
        {
            money.MoneyLost(cost);
            Level++;
            cost = (Mathf.RoundToInt(5000 * (Mathf.Pow(1.5f, Level))));
            LevelOutput.text = ("Level: " + Level);
            CostOutput.text = ("$$" + cost.ToString("N0"));
            cubeHandler.DecreaseCubeHealth();
        }
    }
}
