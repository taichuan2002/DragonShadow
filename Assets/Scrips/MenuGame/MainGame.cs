using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{

    [SerializeField] private Transform maingame;
    [SerializeField] private Transform Freegame;
    [SerializeField] private Transform Coingame;
    [SerializeField] private Transform Herogame;
    [SerializeField] private Transform Playgame;


    public float delaySecond = 2;
    public string sceneName = "MapBot";
    public SpriteRenderer transitionRenderer;
    public Color startColor = Color.black;
    public Color endColor = Color.clear;
    private bool isCheck = false;

    private int Coin;

    void Start()
    {
        maingame.gameObject.SetActive(true);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OnInit();
        isCheck = true;
    }
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
    }
    public void OnInit()
    {
        UIManager.Instance.SetCoin(Coin);
    }
    public void clickPlay()
    {
        maingame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(true);
        Invoke(nameof(NextMap), 3f);
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
    public void NextMap()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}