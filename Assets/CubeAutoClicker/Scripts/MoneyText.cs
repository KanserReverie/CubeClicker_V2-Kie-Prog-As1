using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    // Will move up and then disapear after 2 seconds.
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 4, 0);
        Object.Destroy(gameObject, 1);
    }
}
