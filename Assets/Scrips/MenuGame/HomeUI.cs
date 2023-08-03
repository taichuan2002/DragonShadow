using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    public static HomeUI Instance { get; private set; }


    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject[] mainGame;



    public string sceneName = "MapBot";
    public Animator animator;
    bool isCheckMain = true;
    private int Coin;
    void Start()
    {
        OnInit();
        if (PlayerPrefs.HasKey("openPanel"))
        {
            mainGame[0].gameObject.SetActive(true);
            PlayerPrefs.DeleteKey("openPanel");
        }
    }
    void Update()
    {
        UIManager.Instance.SetCoin(Coin);
    }
    public void WinGame()
    {
        Debug.LogError(1);
        mainGame[0].gameObject.SetActive(!isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(isCheckMain);
    }
    public void OnInit()
    {
        Application.targetFrameRate = 60;
        Camera.main.orthographic = true;
        mainGame[0].gameObject.SetActive(isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);
        StartCoroutine(loading());
    }

    public void clickLevelGame()
    {
        Camera.main.orthographic = true;
        mainGame[0].gameObject.SetActive(isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);
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
        mainGame[0].gameObject.SetActive(false);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(isCheckMain);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);

    }
    public void clickHero()
    {
        Camera.main.orthographic = false;
        mainGame[0].gameObject.SetActive(!isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(isCheckMain);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);
    }
    public void clickCoin()
    {
        Camera.main.orthographic = true;
        mainGame[0].gameObject.SetActive(!isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(isCheckMain);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);
    }
    public void clickBack()
    {
        Camera.main.orthographic = true;
        mainGame[0].gameObject.SetActive(isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);
    }

    IEnumerator delayLevel()
    {
        yield return new WaitForSeconds(3);
        mainGame[0].gameObject.SetActive(isCheckMain);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
        mainGame[8].gameObject.SetActive(false);
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
        mainGame[6].gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        mainGame[0].gameObject.SetActive(true);
        mainGame[1].gameObject.SetActive(false);
        mainGame[2].gameObject.SetActive(false);
        mainGame[3].gameObject.SetActive(false);
        mainGame[4].gameObject.SetActive(false);
        mainGame[5].gameObject.SetActive(false);
        mainGame[6].gameObject.SetActive(false);
        mainGame[7].gameObject.SetActive(false);
    }
}
