using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    [SerializeField] private Transform maingame;
    [SerializeField] private Transform Freegame;
    [SerializeField] private Transform Coingame;
    [SerializeField] private Transform Herogame;
    

    private bool isCheck = false;
    void Start()
    {
        maingame.gameObject.SetActive(true);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickPlay()
    {
        
    }
    public void clickSetting()
    {

    }
    public void clickSpinner()
    {

    }
    public void clickFree()
    {
        maingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(true);
    }
    public void clickHero()
    {
        maingame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(true);
    }
    public void clickCoin()
    {
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(true);
    }
    public void clickBack()
    {
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        maingame.gameObject.SetActive(true);
    }
}