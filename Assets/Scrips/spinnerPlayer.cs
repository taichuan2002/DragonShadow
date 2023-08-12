using AirFishLab.ScrollingList;
using AirFishLab.ScrollingList.Demo;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class spinnerPlayer : MonoBehaviour
{
    [SerializeField] GameObject _panelCanel;
    [SerializeField] GameObject _panelMoney;
    [SerializeField] ScrollRect scrollRect;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtLevel;
    public TextMeshProUGUI txtBuyLevel;
    public TextMeshProUGUI txtPointCoin;
    public TextMeshProUGUI txtPrice;
    public TextMeshProUGUI txtPower;
    public Image _imgPlayer;
    public Image _imgPlayer2;
    public GameObject _btnUnLock;
    public GameObject _btnActive;
    public static DataPlayer currentPlayerData;
    public Image[] _imgPlayerCircol;
    public Sprite[] _spritePlayerLoad;
    public Transform[] obj;
    public DataPlayer[] player;
    private int[] LevelSSJ = new int[5];

    private Vector2 ScrollPosition;
    bool isCheck = true;
    private int currentIndex = 0;
    private int center = 0;
    private Vector3[] initialPositions;
    private Vector3 scrollViewCenterPosition;
    int txt, Coin, levelValue;



    private void Start()
    {
        center = 0;
        OnInit();
        OnInitCoin();
        OnInitIdPlayer();
        if (obj.Length > 0)
        {
            scrollViewCenterPosition = obj[0].parent.position;
        }
    }
    private void Update()
    {
        int playerIndex = center;
        currentPlayerData = player[playerIndex];
        DisplayCurrentPlayerData();
        _imgPlayer.sprite = _spritePlayerLoad[center];
        _imgPlayer2.sprite = _spritePlayerLoad[center];
        isCheckActive();
    }
    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        center = PlayerPrefs.GetInt("idPlayer", 0);
        LevelSSJ[0] = PlayerPrefs.GetInt("LevelSSJ0", 0);
        LevelSSJ[1] = PlayerPrefs.GetInt("LevelSSJ1", 0);
        LevelSSJ[2] = PlayerPrefs.GetInt("LevelSSJ2", 0);
        LevelSSJ[3] = PlayerPrefs.GetInt("LevelSSJ3", 0);
        LevelSSJ[4] = PlayerPrefs.GetInt("LevelSSJ4", 0);
    }
    public void OnInit()
    {
        ScrollPosition = scrollRect.normalizedPosition;
        initialPositions = new Vector3[obj.Length];
        for (int i = 0; i < obj.Length; i++)
        {
            initialPositions[i] = obj[i].position;
        }
    }

    public void OnInitCoin()
    {
        UIManager.Instance.SetCoin(Coin);
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.SetInt("LevelSSJ0", LevelSSJ[0]);
        PlayerPrefs.SetInt("LevelSSJ1", LevelSSJ[1]);
        PlayerPrefs.SetInt("LevelSSJ2", LevelSSJ[2]);
        PlayerPrefs.SetInt("LevelSSJ3", LevelSSJ[3]);
        PlayerPrefs.SetInt("LevelSSJ4", LevelSSJ[4]);
        PlayerPrefs.Save();
        txtPointCoin.text = Coin.ToString();
    }

    public void OnInitIdPlayer()
    {
        PlayerPrefs.SetInt("idPlayer", center);
    }



    public void nextPlayer()
    {
        if (isCheck)
        {
            isCheck = false;
            center = (center + 1) % obj.Length;
            obj[0].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[0].position, 1).OnComplete(() =>
            {
                UpdateTransformOrder();
                DisplayCurrentPlayerData();
                isCheck = true;
                OnInitIdPlayer();
            });
        }

    }

    public void backPlayer()
    {
        if (isCheck)
        {
            isCheck = false;
            center = (center + obj.Length - 1) % obj.Length;
            obj[0].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[0].position, 1).OnComplete(() =>
            {
                UpdateTransformOrder();
                DisplayCurrentPlayerData();
                isCheck = true;
                OnInitIdPlayer();
            });
        }
    }

    public void isCheckActive()
    {
        txt = int.Parse(txtLevel.text);
        levelValue = LevelSSJ[center];
        spinnerPlayer.currentPlayerData.currentLevel = levelValue.ToString();
        string txtlevel = currentPlayerData.currentLevel;
        int intlevel = int.Parse(txtlevel.ToString());

        if (txt <= intlevel)
        {
            _btnActive.SetActive(true);
            _btnUnLock.SetActive(false);
            txtPrice.text = "FREE";
        }
        else
        {
            _btnUnLock.SetActive(true);
            _btnActive.SetActive(false);
        }
    }

    public void OnFocusingBoxChanged(
            ListBox prevFocusingBox, ListBox curFocusingBox)
    {
        var focusedContent = ((IntListBox)curFocusingBox).Content;
        txtLevel.text = focusedContent.ToString();
    }
    private void UpdateTransformOrder()
    {
        Transform temp = obj[0];
        for (int i = 0; i < obj.Length - 1; i++)
        {
            obj[i] = obj[i + 1];
        }
        obj[obj.Length - 1] = temp;

        currentIndex = (currentIndex + obj.Length - 1) % obj.Length;

        for (int i = 0; i < obj.Length; i++)
        {
            if (i == currentIndex)
            {
                obj[i].SetSiblingIndex(0);
            }
            else
            {
                obj[i].SetSiblingIndex(i);
            }
        }
    }
    public void UnLockPlayer()
    {
        string txtlevel = currentPlayerData.currentLevel;
        int intlevel = int.Parse(txtlevel.ToString());
        int price = int.Parse(currentPlayerData.arrPrice[txt].ToString());
        if (txt == intlevel + 1)
        {
            if (Coin >= price)
            {
                Coin -= price;
                levelValue += 1;
                SaveCharacterData(center, levelValue);
                LevelSSJ[center] = levelValue;
                OnInitCoin();
                FindObjectOfType<HomeUI>().UpdateCoin(Coin);
            }
            else
            {
                _panelMoney.SetActive(true);
            }
        }
        else
        {
            _panelCanel.SetActive(true);
            int a = txt - 1;
            txtBuyLevel.text = "Yêu Cầu Mở Khóa Level: " + a.ToString();
        }


    }

    public void Canel()
    {
        _panelCanel.SetActive(false);
    }

    private void DisplayCurrentPlayerData()
    {
        txtName.text = currentPlayerData.name;
        txt = int.Parse(txtLevel.text);
        txtPrice.text = currentPlayerData.arrPrice[txt].ToString();
        txtPower.text = currentPlayerData.arrPower[txt].ToString();
        _imgPlayerCircol[center].sprite = currentPlayerData.listSprite[txt];
    }

    void SaveCharacterData(int playerIndex, int playerData)
    {
        string key = "LevelSSJ" + playerIndex.ToString();
        PlayerPrefs.SetInt(key, playerData);
        PlayerPrefs.Save();
    }
    public void ChangeContents()
    {
        scrollRect.normalizedPosition = ScrollPosition;
    }
    public void UpdateCoin(int newCoinValue)
    {
        Coin = newCoinValue;
        OnInitCoin();
    }

}
