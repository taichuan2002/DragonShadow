using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dame : MonoBehaviour
{
    public Healing hl;
    public float dame = 30;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.LogWarning(1);
        }
    }
}
