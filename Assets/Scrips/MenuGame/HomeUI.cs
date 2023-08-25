using DanielLochner.Assets.SimpleScrollSnap;
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
    [SerializeField] GameObject _panelCanel;
    [SerializeField] GameObject _panelBuycoin;
    [SerializeField] AutoScroll autoScroll;
    [SerializeField] TextMeshProUGUI[] _txtPointCoins;

    public string sceneName = "MapBot";
    public Animator animator;
    private int Coin, pl, levelMap, btn;
    private bool isCheckScene = false;
    private bool isCheck = false;

    void Start()
    {
        pl = PlayerPrefs.GetInt("idPlayer");
        btn = PlayerPrefs.GetInt("btn");
        if (btn == 0)
        {
            OnInit();
            OnInitCoin();
        }
        if (btn == 1)
        {
            clickBack();
            OnInitCoin();
        }
        if (btn == 2)
        {
            clickHero();
            OnInitCoin();
        }
        if (btn == 3)
        {
            clickLevelGame();
            OnInitCoin();
        }
    }


    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        levelMap = PlayerPrefs.GetInt("levelMap", 0);
        PlayerPrefs.SetInt("idPlayer", 0);
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        StartCoroutine(loading());
    }

    public void OnInitCoin()
    {
        UIManager.Instance.SetCoin(Coin);
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.SetInt("levelMap", levelMap);
        PlayerPrefs.SetInt("btn", 0);
        PlayerPrefs.Save();
        _txtPointCoins[0].text = Coin.ToString();
        _txtPointCoins[1].text = Coin.ToString();
        _txtPointCoins[2].text = Coin.ToString();
    }

    public void StartGame()
    {
        isCheckScene = true;
        isCheck = true;
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);

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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        StartCoroutine(DelayScrollLevel());
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);
        OnInitCoin();


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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);
        OnInitCoin();

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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);
        OnInitCoin();

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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
    }

    public void ClickFreeCoins()
    {
        Coin += 100000;
        OnInitCoin();
    }

    IEnumerator DelayLevel()
    {

        FindObjectOfType<AutoScroll>().ItemCenter();
        yield return new WaitForSeconds(4);
        Playgame.gameObject.SetActive(true);
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        LoadingMain.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
    }

    IEnumerator DelayScrollLevel()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(DelayLevel());
    }

    public IEnumerator nextMap()
    {
        animator.SetTrigger("nextScene");
        yield return new WaitForSeconds(1);
        Camera.main.orthographic = true;
        SceneManager.LoadScene(sceneName);
    }
    public void GameOver()
    {
        Application.targetFrameRate = 90;
        Camera.main.orthographic = true;
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
    }

    public void UpdateCoin(int newCoinValue)
    {
        Coin = newCoinValue;
        OnInitCoin();
    }

}