using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{

    [SerializeField] Transform maingame;
    [SerializeField] Transform Freegame;
    [SerializeField] Transform Coingame;
    [SerializeField] Transform Herogame;
    [SerializeField] Transform Playgame;
    [SerializeField] Transform Levelgame;
    [SerializeField] Transform LoadingMain;
    [SerializeField] Transform gameOver;
    [SerializeField] TextMeshProUGUI[] _txtPointCoins;
    [SerializeField] GameObject _panelCanel;


    public string sceneName = "MapBot";
    private bool isCheck = false;
    public Animator animator;

    private int Coin;

    void Start()
    {
        OnInit();
        OnInitCoin();
    }
    void Update()
    {
    }
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
    }
    public void OnInit()
    {
        Application.targetFrameRate = 90;
        Camera.main.orthographic = true;
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        StartCoroutine(loading());
    }

    public void OnInitCoin()
    {
        UIManager.Instance.SetCoin(Coin);
        _txtPointCoins[0].text = Coin.ToString();
        _txtPointCoins[1].text = Coin.ToString();
        _txtPointCoins[2].text = Coin.ToString();
        _txtPointCoins[3].text = Coin.ToString();
    }

    public void clickLevelGame()
    {
        Camera.main.orthographic = true;
        Levelgame.gameObject.SetActive(true);
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        StartCoroutine(delayLevel());
    }
    public void clickPlay()
    {
        Camera.main.orthographic = true;
        StartCoroutine(nextMap());
    }
    public void clickSetting()
    {
        Camera.main.orthographic = true;
    }
    public void clickSpinner()
    {
        Camera.main.orthographic = true;
    }
    public void clickFree()
    {
        Camera.main.orthographic = true;
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(true);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);

    }
    public void clickHero()
    {
        Camera.main.orthographic = false;
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(true);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }
    public void clickCoin()
    {
        Camera.main.orthographic = true;
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(true);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }
    public void clickBack()
    {
        Camera.main.orthographic = true;
        maingame.gameObject.SetActive(true);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    IEnumerator delayLevel()
    {
        yield return new WaitForSeconds(3);
        Playgame.gameObject.SetActive(true);
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        LoadingMain.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    public IEnumerator nextMap()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("nextScene");
        Camera.main.orthographic = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator loading()
    {
        LoadingMain.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        maingame.gameObject.SetActive(true);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        LoadingMain.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
    }



}