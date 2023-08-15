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
    [SerializeField] GameObject _panelBuycoin;
    [SerializeField] DataPlayer[] player;
    [SerializeField] DataEneMy Enemy;
    [SerializeField] GameObject _victoryGame;
    [SerializeField] GameObject _deadGame;



    public string sceneName = "MapBot";
    public Animator animator;
    private int Coin, pl;
    private bool isCheckScene = false;
    private bool isCheck = false;

    void Start()
    {
        pl = PlayerPrefs.GetInt("idPlayer");
        int coin = PlayerPrefs.GetInt("tongCoin");
        _txtPointCoins[4].text = coin.ToString();
        if (player[pl].isDead != true)
        {
            if (Enemy.isDead == true)
            {
                GameOver();
                OnInitCoin();
                _victoryGame.SetActive(true);
                Enemy.isDead = false;
                coin += 60;
                _txtPointCoins[5].text = "60";
                _txtPointCoins[6].text = coin.ToString();
            }
            else
            {
                OnInit();
                OnInitCoin();
            }
        }
        else if (player[pl].isDead == true)
        {
            GameOver();
            OnInitCoin();
            _deadGame.SetActive(true);
            player[pl].isDead = false;
            _txtPointCoins[6].text = coin.ToString();
        }

    }
    void Update()
    {
    }
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
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
        PlayerPrefs.Save();
        _txtPointCoins[0].text = Coin.ToString();
        _txtPointCoins[1].text = Coin.ToString();
        _txtPointCoins[2].text = Coin.ToString();
        _txtPointCoins[3].text = Coin.ToString();
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        FindObjectOfType<spinnerPlayer>().UpdateCoin(Coin);
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
        FindObjectOfType<spinnerPlayer>().UpdateCoin(Coin);
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
        FindObjectOfType<spinnerPlayer>().UpdateCoin(Coin);
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
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
    }

    public IEnumerator nextMap()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("nextScene");
        Camera.main.orthographic = true;
        yield return new WaitForSeconds(1.5f);
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

    /*public void SetPointCoin(int point)
    {
        int coin = point;
         = coin.ToString();
        if (player[pl] == false)
        {
            _txtPointCoins[6].text = coin.ToString();
        }
    }*/
    public void UpdateCoin(int newCoinValue)
    {
        Coin = newCoinValue;
        OnInitCoin();
    }

}