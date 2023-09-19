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
    [SerializeField] Transform Setting;
    [SerializeField] GameObject _panelCanel;
    [SerializeField] GameObject _panelBuycoin;
    [SerializeField] AutoScroll autoScroll;
    [SerializeField] TextMeshProUGUI[] _txtPointCoins;
    [SerializeField] Image[] _imgBtnSetting;
    [SerializeField] Button[] _btnBuyCoin;
    [SerializeField] Button[] _btnFreeCoin;
    [SerializeField] Image[] _imgPlayer;
    [SerializeField] AudioSource audioMain;
    [SerializeField] AudioSource audioClick;
    [SerializeField] AudioClip[] _audios;
    public Sprite[] _spritePlayerLoad;


    public string sceneName = "MapBot";
    public Animator animator;
    public Animator animBtnSetting;
    private int Coin, pl, levelMap, btn, bean, ado, audiobtn;
    private bool isCheckScene = false;
    private bool isCheck = false;
    private bool isNextPanel = false;
    private bool isMusic = false;
    private bool isAudio = false;
    private bool isMoreGame = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        btn = PlayerPrefs.GetInt("btn");
        if (btn == 0)
        {
            OnInit();
            OnInitCoin();

        }
        if (btn == 1)
        {
            GameOverPanelBack();
            OnInitCoin();
            OnAudio();
        }
        if (btn == 2)
        {
            GameOverPanelHero();
            OnInitCoin();
            OnAudio();
        }
        if (btn == 3)
        {
            GameOverPanelLevel();
            OnInitCoin();
            OnAudio();
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
        ado = PlayerPrefs.GetInt("mussic", 0);
        audiobtn = PlayerPrefs.GetInt("audioClick", 0);
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
        StartCoroutine(Loading());
    }

    public void OnAudio()
    {
        ado = PlayerPrefs.GetInt("mussic");
        audiobtn = PlayerPrefs.GetInt("audioClick");
        if (ado == 0)
        {
            Color currentColor = _imgBtnSetting[0].color;
            currentColor.a = 1;
            _imgBtnSetting[0].color = currentColor;
            isMusic = false;
        }
        else
        {
            Color currentColor = _imgBtnSetting[0].color;
            currentColor.a = 0.5f;
            _imgBtnSetting[0].color = currentColor;
            isMusic = true;

        }
        if (audiobtn == 0)
        {
            Color currentColor = _imgBtnSetting[1].color;
            currentColor.a = 1;
            _imgBtnSetting[1].color = currentColor;
            isAudio = false;
        }
        else
        {
            Color currentColor = _imgBtnSetting[1].color;
            currentColor.a = 0.5f;
            _imgBtnSetting[1].color = currentColor;
            isAudio = true;
        }
        AudioMain();
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

    public void ClickLevelGame()
    {
        AudioClick();
        if (!isNextPanel)
        {
            StartCoroutine(NextLevel());
            isNextPanel = true;
        }

    }
    public void ClickPlay()
    {
        AudioClick();
        Camera.main.orthographic = true;
        StartCoroutine(NextMap());
    }
    public void ClickSpinner()
    {
        AudioClick();
    }
    public void ClickFree()
    {
        AudioClick();
        if (!isNextPanel)
        {
            StartCoroutine(NextFreeCoin());
            isNextPanel = true;
        }
    }
    public void ClickHero()
    {
        AudioClick();
        if (!isNextPanel)
        {
            StartCoroutine(NextHero());
            isNextPanel = true;
        }
    }

    public void ClickCoin()
    {
        AudioClick();
        if (!isNextPanel)
        {
            StartCoroutine(NextCoin());
            isNextPanel = true;
        }
    }
    public void ClickBack()
    {
        AudioClick();
        if (!isNextPanel)
        {
            StartCoroutine(BackMenu());
            isNextPanel = true;
        }
    }
    public void ClickSetting()
    {
        AudioClick();
        Setting.gameObject.SetActive(true);
        animBtnSetting.SetTrigger("btnSetting");
    }
    public void ClickCloseSetting()
    {
        Setting.gameObject.SetActive(false);
    }
    public void ClickMusic()
    {
        AudioClick();
        Color currentColor = _imgBtnSetting[0].color;
        if (!isMusic)
        {
            audioMain.Stop();
            currentColor.a = 0.5f;
            _imgBtnSetting[0].color = currentColor;
            PlayerPrefs.SetInt("mussic", 1);
            PlayerPrefs.Save();
            isMusic = true;
        }
        else
        {
            audioMain.Play();
            currentColor.a = 1;
            _imgBtnSetting[0].color = currentColor;
            PlayerPrefs.SetInt("mussic", 0);
            PlayerPrefs.Save();
            isMusic = false;
        }
    }
    public void ClickAudio()
    {
        Color currentColor = _imgBtnSetting[1].color;
        AudioClick();
        if (!isAudio)
        {
            audioClick.Pause();
            currentColor.a = 0.5f;
            _imgBtnSetting[1].color = currentColor;
            PlayerPrefs.SetInt("audioClick", 1);
            PlayerPrefs.Save();
            isAudio = true;
        }
        else
        {
            audioClick.UnPause();
            currentColor.a = 1;
            _imgBtnSetting[1].color = currentColor;
            PlayerPrefs.SetInt("audioClick", 0);
            PlayerPrefs.Save();
            isAudio = false;
        }
    }
    public void ClickMoreGame()
    {
        AudioClick();
    }

    public void GameOverPanelHero()
    {
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(true);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        OnInitCoin();
    }
    public void GameOverPanelBack()
    {
        Camera.main.orthographic = true;
        maingame.gameObject.SetActive(true);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        Playgame.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        _panelCanel.gameObject.SetActive(false);
    }
    public void GameOverPanelLevel()
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
        if (FindObjectOfType<SpinnerPlayer>() != null)
        {
            FindObjectOfType<SpinnerPlayer>().UpdateCoin(Coin);

        }
        OnInitCoin();
        StartCoroutine(DelayScrollLevel());
    }

    public void ClickFreeCoins(int Index)
    {
        switch (Index)
        {
            case 0:
                AudioClick();
                break;
            case 1:
                AudioClick();
                Coin += 500;
                AudioCoin();

                break;
            case 2:
                AudioClick();
                Coin += 200;
                AudioCoin();

                break;
            case 3:
                AudioClick();
                break;
        }
        OnInitCoin();
    }
    public void ClickBuyCoins(int Index)
    {
        switch (Index)
        {
            case 0:
                AudioClick();
                Coin += 2000;
                bean += 20;
                OnInitCoin();
                AudioCoin();

                break;
            case 1:
                AudioClick();
                Coin += 2500;
                bean += 65;
                OnInitCoin();
                AudioCoin();

                break;
            case 2:
                Coin += 10000;
                AudioClick();
                AudioCoin();

                break;
            case 3:
                Coin += 50000;
                AudioClick();
                AudioCoin();
                break;
            case 4:
                Coin += 100000;
                AudioClick();
                AudioCoin();

                break;
            case 5:
                Coin += 300000;
                AudioClick();
                AudioCoin();

                break;
            case 6:
                Coin += 900000;
                AudioClick();
                AudioCoin();

                break;
            case 7:
                Coin += 2700000;
                AudioClick();
                AudioCoin();

                break;
            case 8:
                AudioClick();
                Coin += 6500000;
                AudioCoin();

                break;
            case 9:
                AudioClick();
                Coin += 9000000;
                AudioCoin();

                break;
            case 10:
                AudioClick();

                Coin += 3000;
                bean += 110;
                OnInitCoin();
                AudioCoin();

                break;
            case 11:
                AudioClick();
                Coin += 4000;
                bean += 220;
                OnInitCoin();
                AudioCoin();

                break;
            case 12:
                AudioClick();
                Coin += 5000;
                bean += 350;
                OnInitCoin();
                AudioCoin();

                break;
            case 13:
                AudioClick();
                Coin += 6000;
                bean += 500;
                OnInitCoin();
                AudioCoin();
                break;
        }
        OnInitCoin();
    }


    IEnumerator DelayScrollLevel()
    {
        FindObjectOfType<AutoScroll>().ItemCenter();
        yield return new WaitForSeconds(1.2f);
        AudioLevelEnemy();
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(DelayLevel());
    }
    IEnumerator DelayLevel()
    {
        yield return new WaitForSeconds(3);
        Playgame.gameObject.SetActive(true);
        maingame.gameObject.SetActive(false);
        Coingame.gameObject.SetActive(false);
        Freegame.gameObject.SetActive(false);
        Herogame.gameObject.SetActive(false);
        LoadingMain.gameObject.SetActive(false);
        Levelgame.gameObject.SetActive(false);
        _panelCanel.gameObject.SetActive(false);
        _panelBuycoin.gameObject.SetActive(false);
        AudioLevelEnemyVS();

    }

    public void ResetTitle()
    {
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("LevelSSJ0", 1);
        PlayerPrefs.SetInt("LevelSSJ1", 1);
        PlayerPrefs.SetInt("LevelSSJ2", 1);
        PlayerPrefs.SetInt("LevelSSJ3", 1);
        PlayerPrefs.SetInt("LevelSSJ4", 1);
        PlayerPrefs.SetInt("Bean", 0);
        PlayerPrefs.SetInt("levelMap", 0);
        PlayerPrefs.Save();
        Coin = PlayerPrefs.GetInt("Coin");
        bean = PlayerPrefs.GetInt("Bean");
        levelMap = PlayerPrefs.GetInt("levelMap");
        _txtPointCoins[0].text = Coin.ToString();
        _txtPointCoins[1].text = Coin.ToString();
        _txtPointCoins[2].text = Coin.ToString();
    }
    public IEnumerator NextMap()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        Camera.main.orthographic = true;
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator NextLevel()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("End");
        isNextPanel = false;
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
    IEnumerator NextHero()
    {

        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("End");
        isNextPanel = false;
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
    IEnumerator NextCoin()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("End");
        isNextPanel = false;
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
        OnInitCoin();
    }
    IEnumerator NextFreeCoin()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        isNextPanel = false;
        animator.SetTrigger("End");
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
        OnInitCoin();
    }
    IEnumerator BackMenu()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("End");
        isNextPanel = false;
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
    IEnumerator Loading()
    {
        LoadingMain.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        OnAudio();
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
    public void BtnCanel()
    {
        _panelBuycoin.SetActive(false);
        AudioClick();
    }

    public void UpdateCoin(int newCoinValue)
    {
        Coin = newCoinValue;
        OnInitCoin();
    }
    public void AudioMain()
    {
        if (!isMusic)
        {
            audioMain.Play();
        }
    }
    public void AudioClick()
    {
        if (!isAudio)
        {
            audioClick.PlayOneShot(_audios[1]);
        }
    }
    public void AudioCoin()
    {
        if (!isAudio)
        {
            audioClick.PlayOneShot(_audios[2]);
        }
    }
    public void AudioLevelEnemy()
    {
        if (!isAudio)
        {
            audioClick.PlayOneShot(_audios[3]);
        }
    }
    public void AudioLevelEnemyVS()
    {
        if (!isAudio)
        {
            audioClick.PlayOneShot(_audios[4]);
        }
    }
}