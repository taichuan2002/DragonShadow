using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text txtCoin;
    
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void SetCoin(int coin)
    {
        txtCoin.text = coin.ToString();
    }
}
