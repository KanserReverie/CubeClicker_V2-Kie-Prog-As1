using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public TextMesh MoneyTextDesplay;

    // Gets Rigidbody
    private Rigidbody rb;

    [SerializeField] private Material cubeMaterial;
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
        rend.material.color = cubeUntouchedColor;
        cubeHealth = MaxHealthOfCube;
        // Will print the 3d $$ once broken.
        // Vector3 force = cubeRow * cubeColumn;
        // TextDisplay = ("$$ " + IntToString(_MoneyDrop));
    }

    private void CubeHit()
    {
        rend.material.color += CubeColorIncrease;
    }
}