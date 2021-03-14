using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    /// <summary>
    /// Just initialising these private variables kinda self explanatory.
    /// </summary>
        /// Just found out initialising means "set to the value or put in the condition appropriate to the start of an operation".
        /// Thus it would be "initialising" -> "creating and initialising".

        // Max ammount of rows in Cube grid.
            // Called in Start() Instantiate.
            private int RowMax = 3;      
        // Max ammount of Cubes in each row.
            // Called in Start() Instantiate.
            private int ColMax = 4;
        // Distace between each Cube.
            // Called in Start() Instantiate.
            private float cubeDistanceBetweenCubes = 2;
        // The base (e.g we are base 4) for breaking new cube.
            private int moneyBaseIncreaseForBreakingCube = 4;
    // Base health of cubes.
    // Everything is pretty based, on 8.
    // Will be changed in pets.
    private int baseHealthOfCubes = 8;
        // This is an array of Cube. Remember these are still GameObjects.
            // To call Cube on each one you need:
                // cubeGrid[x,y].GetComponent<Cube>().ScriptWantToCall;
            // A jagged array [x][y] is an array of arrays and a multidimensional array [x,y] is just a normal 2d array.
            // I don't get jagged arrays yet and how to initalise or call thus this works.
           private GameObject[,] cubeGrid = new GameObject[3, 4]; // [Row] [Col]

    /// <summary>
    /// All the public variables choosen in the client.
    /// </summary>
    /// Need to fix at some point either by putting in functions or by privating and hard coding in.

        // This is just a 1d array of colors choosen in inspector and looped through in Instansiating. FIX + ASK IF TIME
            // When this was a 2d array but wasn't showing in inspector.
            // There is a way to make this a 2d array showing the grid of colors.
                // It looks like it uses strusts and "[System.Serializable]" at the front and at the top of the class
                // https://www.youtube.com/watch?v=uoHc-Lz9Lsc
            // Might manually input all and "private" in start if it starts reseting too often.
            public Color[] CubeGridColors = new Color[12];// -- NEEDED
        // Just connects to the money manager.
            public Money MoneyCount;
        // Links to the Cube GameObject Prefab.
            public GameObject CubePrefab;
        // Vector3 of where to start placing cubes.
            //-6.05 0.55 -14.15
            public Vector3 StartPointCubeGrid;
        // The original cube color.
            // Again might turn private and hard code the colors in start().
            public Color CubeUntouchedColor;    
        //The Material of each cube.
            // Each cube needs a material to change color of it.
            public Material cubeMaterial;
    private int ss = 1;


    private void Start()
    {
        GameObject newCube = new GameObject();
        Vector3 extraDistance = new Vector3(0, 0, 0);

        // This will make a fill cubeGrid array
        for (int y = 0; y < RowMax; y++)
        {
            for (int x = 0; x < ColMax; x++)
            {
                print("here" + ss + CubeGridColors[(y * ColMax + (x + 1)) - 1]);
                ss++;
                extraDistance = new Vector3(x * cubeDistanceBetweenCubes, 0, y * cubeDistanceBetweenCubes);
                newCube = Instantiate(CubePrefab, transform.position + extraDistance, Quaternion.identity, transform) as GameObject;
                // This will get the script 'Cube' on the gameObject newCube.
                // Thus we can still keep an array of Cube.
                newCube.GetComponent<Cube>()
                    .CubeSetup(y, x, CubeGridColors[(y * ColMax + (x + 1))-1], baseHealthOfCubes, CubeUntouchedColor, cubeMaterial);
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
             CubeDone = cubeGrid[CurRow, CurCol].GetComponent<Cube>().Click();

             if (CubeDone == true)
             {
                 moneyMade = CubeBreakMoney(CurRow, CurCol);
                 cubeGrid[CurRow, CurCol].GetComponent<Cube>().Break(moneyMade);
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
        int MoneyGained =                            // Used to be some confusing thing but basically:
            (Mathf.RoundToInt                        //     Makes following int
            (Mathf.Pow                               //         Puts following to power
            (moneyBaseIncreaseForBreakingCube,       //             Base amount for killing cube in begining - e.g. 4
            ((_CubeRow) * ColMax) + (_CubeCol)       //             Where the cube is in the array starting at 0
            )));                                     //     Because computers start arrays at 0 anything > 0 to power of 0 = 1

        MoneyCount.MoneyGained(MoneyGained);
        return MoneyGained;
     }
}