using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Here so the game runs on a small window.
public class Fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 568, false);
    }
}
