using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{

    [SerializeField] Transform maingame;
    [SerializeField] Transform Freegame;
    [SerializeField] Transform Coingame;
    [SerializeField] Transform Herogame;
    [SerializeField] Transform Playgame;
    [SerializeField] Transform Levelgame;
    [SerializeField] Transform LoadingMain;
    [SerializeField] GameObject _panelCanel;
    [SerializeField] GameObject _panelBuycoin;
    [SerializeField] AutoScroll autoScroll;
    [SerializeField] TextMeshProUGUI[] _txtPointCoins;
    [SerializeField] Button[] _btnBuyCoin;
    [SerializeField] Button[] _btnFreeCoin;

    public string sceneName = "MapBot";
    public Animator animator;
    private int Coin, pl, levelMap, btn, bean;
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

        for (int i = 0; i < _btnBuyCoin.Length; i++)
        {
            int buttonIndex = i;
            _btnBuyCoin[i].onClick.AddListener(() => ClickBuyCoins(buttonIndex));
        }
        for (int i = 0; i < _btnFreeCoin.Length; i++)
        {
            int buttonIndex = i;
            _btnFreeCoin[i].onClick.AddListener(() => ClickFreeCoins(buttonIndex));
        }
    }


    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        bean = PlayerPrefs.GetInt("Bean", 0);
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        StartCoroutine(loading());
    }

    public void OnInitCoin()
    {
        UIManager.Instance.SetCoin(Coin);
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.SetInt("Bean", bean);
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        if (FindObjectOfType<SpinnerPlayer>() != null)
        {
            FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);

        }
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        if (FindObjectOfType<SpinnerPlayer>() != null)
        {
            FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);

        }
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        if (FindObjectOfType<SpinnerPlayer>() != null)
        {
            FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);

        }
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
    }

    public void ClickFreeCoins(int Index)
    {
        switch (Index)
        {
            case 0:
                break;
            case 1:
                Coin += 500;
                break;
            case 2:
                Coin += 200;
                break;
            case 3:
                break;
        }
        OnInitCoin();
    }
    public void ClickBuyCoins(int Index)
    {
        switch (Index)
        {
            case 0:
                Coin += 2000;
                bean += 20;
                OnInitCoin();
                break;
            case 1:
                Coin += 2500;
                bean += 65;
                OnInitCoin();
                break;
            case 2:
                Coin += 10000;

                break;
            case 3:
                Coin += 50000;

                break;
            case 4:
                Coin += 100000;

                break;
            case 5:
                Coin += 300000;

                break;
            case 6:
                Coin += 900000;

                break;
            case 7:
                Coin += 2700000;

                break;
            case 8:
                Coin += 6500000;

                break;
            case 9:
                Coin += 9000000;

                break;
            case 10:
                Coin += 3000;
                bean += 110;
                OnInitCoin();
                break;
            case 11:
                Coin += 4000;
                bean += 220;
                OnInitCoin();

                break;
            case 12:
                Coin += 5000;
                bean += 350;
                OnInitCoin();

                break;
            case 13:
                Coin += 6000;
                bean += 500;
                OnInitCoin();

                break;
        }
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