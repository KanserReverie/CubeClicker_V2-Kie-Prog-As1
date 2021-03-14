using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cube : MonoBehaviour
{
    private int cubeRow;
    private int cubeColumn;
    private Color cubeUntouchedColor;
    private Color cubeFinalColor;
    private int moneyDropped;
    private int cubeHealth;
    private bool cubeBroke;
    private int MaxHealthOfCube;
    private Color CubeColorIncrease;
    public TextMeshPro MoneyTextDesplay;
    public GameObject MoneyText;
    // Gets Rigidbody
    private Rigidbody rb;

    private Material cubeMaterial;
    Renderer rend;

    public void CubeSetup(int _Row, int _Col, Color _FinalColor, int _Health, Color _UntouchColor, Material _CubeMaterial)
    {
        cubeRow = _Row;
        cubeColumn = _Col;
        cubeFinalColor = _FinalColor;
        MaxHealthOfCube = _Health;
        cubeUntouchedColor = _UntouchColor;
        cubeHealth = MaxHealthOfCube; ;
        CubeColorIncrease = (cubeFinalColor - cubeUntouchedColor) / (cubeHealth - 1);

        // Getting rigidbody
        rb = GetComponent<Rigidbody>();

        // Getting materials
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = _CubeMaterial;

        rend.material.color = cubeUntouchedColor;

    }

    // Might add particle system.
    private void Update()
    {
        MoneyTextDesplay.text = cubeHealth + "/" + MaxHealthOfCube;
    }

    public bool Click()
    {
        cubeHealth--;
        if (cubeHealth <= 0)
        {
            return true;
        }
        else
        {
            CubeHit();
            return false;
        }
    }

    public void Break(int _MoneyDrop)
    {
        GameObject newMoneyText = new GameObject();

        newMoneyText = Instantiate(MoneyText, transform.position+new Vector3(0,0.3f,0), Quaternion.identity, transform);
        newMoneyText.GetComponent<TextMesh>().text = ("+$$" + _MoneyDrop); ;
        // Will print the 3d $$ once broken.
        // Vector3 force = cubeRow * cubeColumn;
        // TextDisplay = ("$$ " + IntToString(_MoneyDrop));

        rend.material.color = cubeUntouchedColor;
        cubeHealth = MaxHealthOfCube;
    }

    private void CubeHit()
    {
        rend.material.color += CubeColorIncrease;
    }
}