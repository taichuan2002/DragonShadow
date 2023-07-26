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
    [SerializeField] private Transform Levelgame;
    [SerializeField] private Transform LoadingMain;
    [SerializeField] private Transform gameOver;


    public string sceneName = "MapBot";
    private bool isCheck = false;
    public Animator animator;

    private int Coin;

    void Start()
    {
        OnInit();
        if (PlayerPrefs.HasKey("openPanel"))
        {
            gameOver.gameObject.SetActive(true);
            PlayerPrefs.DeleteKey("openPanel");
        }
    }
    void Update()
    {
        UIManager.Instance.SetCoin(Coin);
        isCheck = true;
    }
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
    }
    public void OnInit()
    {
        Application.targetFrameRate = 60;
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