using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private int RowMax = 3;
    private int ColMax = 4;
    private float cubeDistanceBetweenCubes = 2;
    private GameObject[,] cubeGrid = new GameObject[3, 4]; // [Row] [Col]
    private int baseMoneyForBreakingCube = 8;
    private int baseHealthOfCubes = 8;
    public Color[] CubeGridColors = new Color[12];// -- NEEDED
    public Money MoneyCount;
    public GameObject CubePrefab;
    public Vector3 StartPointCubeGrid;
    public Color CubeUntouchedColor;
    public Material cubeMaterial;

    /*
     private void Start()
     {
         GameObject newCube = new GameObject();
         Vector3 extraDistance = new Vector3(0, 0, 0);

         for (int y = 0; y < RowMax; y++)
         {
             for (int x = 0; x < ColMax; x++)
             {
                 extraDistance = new Vector3(x * cubeDistanceBetweenCubes, y * cubeDistanceBetweenCubes, 0);
                 newCube = Instantiate(CubePrefab, transform.position + extraDistance, Quaternion.identity, transform);
                 newCube.Setup(y, x, CubeGridColors[(y*ColMax + (x+1))], baseHealthOfCubes,CubeUntouchedColor,cubeMaterial);
                 cubeGrid[y, x] = newCube;
             }
         }
     }

     public void Click()
     {
         bool CubeDone = false;
         int CurRow = 0;
         int CurCol = 0;
         int moneyMade = 0;

         do
         {
             CubeDone = cubeGrid[CurRow, CurCol].Click();

             if (CubeDone == true)
             {
                 moneyMade = CubeBreakMoney(CurRow, CurCol);
                 cubeGrid[CurRow, CurCol].Break(moneyMade);
                 CurCol++;

                 if (CurCol > ColMax)
                 {
                     CurCol = 0;
                     CurRow++;
                 }
             }
         } while (CubeDone == true);
     }

     private int CubeBreakMoney(int _CubeRow, int _CubeCol)
     {
         int MoneyGained = ((((_CubeRow) * ColMax) + (_CubeCol + 1)) * baseMoneyForBreakingCube);
         MoneyCount.MoneyGained(MoneyGained);
         return MoneyGained;
     }
     */
}