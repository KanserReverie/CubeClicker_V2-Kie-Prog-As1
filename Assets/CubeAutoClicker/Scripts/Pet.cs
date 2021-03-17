using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet : MonoBehaviour
{
    // All 
    public string PetName;
    public int PetLevel;
    public string PetDescription;
    public Sprite PetCurrentSprite;
    public bool IsActive = false;
    public bool canBuy;
    public int currentCost;
    public int BaseCost;
    public Money money;
    private int CurrentMoney;


    // All the panel.
    public GameObject PetPanel;
    public TMP_Text NameOutput;
    public TMP_Text DescriptionOutput;
    public TMP_Text LevelOutput;
    public Button BuyPet;
    public Image PetImageOutput;

    private void Start()
    {
        money = FindObjectOfType<Money>();
        //money.MoneyValue
    }


    // Update is called once per frame
    void Update()
    {
        CurrentMoney = money.GetMoney();
        
    }
}
