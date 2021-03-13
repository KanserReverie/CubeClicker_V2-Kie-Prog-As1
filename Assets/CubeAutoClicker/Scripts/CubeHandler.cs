using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private int RowMax = 3;
    private int ColMax = 4;
    private float cubeDistanceBetweenCubes = 2;
    private Cube[,] cubeGrid = new Cube[3,4];//[Row] [Col]
    private int baseMoneyForBreakingCube = 8;
    private int baseHealthOfCubes = 8;
    public Color[][] CubeGridColors = new Color[3][4];// -- NEEDED
    public Money MoneyCount;
    public Cube CubePrefab;
    public Vector3 StartPointCubeGrid;

}