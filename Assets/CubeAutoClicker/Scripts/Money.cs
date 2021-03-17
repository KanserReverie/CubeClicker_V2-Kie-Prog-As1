using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int MoneyValue { get { return money; } }

    private int money;
    public Text moneyDisplay;
    private string pricingText = "$$";

    private void Start()
    {
        money = 0;
    }
    private void Update()
    {
        moneyDisplay.text = pricingText + money.ToString("N0");
    }

    public void MoneyGained(int _q1)
    {
        money += _q1;
    }

    public void MoneyLost(int _q2)
    {
        money -= _q2;
    }

    public int GetMoney()
    {
        return money;
    }
}
