using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet_3 : MonoBehaviour
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
    public CubeHandler cubeHandler;
    public GameObject Locked1;

    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<Money>();
        cubeHandler = FindObjectOfType<CubeHandler>();
        //money.MoneyValue

        cost = (Mathf.RoundToInt(1000 * (Mathf.Pow(2f, Level))));

        BuyPet.interactable = false;

        LevelOutput.text = ("Level: " + Level);
        CostOutput.text = ("$$" + cost.ToString("N0"));
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoney = money.MoneyValue;
        if (CurrentMoney > 1000)
        {
            Locked1.SetActive(false);
        }

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
        if (CurrentMoney >= cost)
        {

            money.MoneyLost(cost);
            Level++;
            cost = (Mathf.RoundToInt(1000 * (Mathf.Pow(2f, Level))));
            LevelOutput.text = ("Level: " + Level);
            CostOutput.text = ("$$" + cost.ToString("N0"));
            cubeHandler.IncreaseCubeMoney();
        }
    }
}
