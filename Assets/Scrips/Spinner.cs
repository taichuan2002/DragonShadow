using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinner : MonoBehaviour
{
    [SerializeField] private Button btnSpiner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        btnSpiner.transform.rotation *= Quaternion.Euler(0f, 0f, 120f * Time.deltaTime);
    }
}
