﻿using AirFishLab.ScrollingList;
using AirFishLab.ScrollingList.Demo;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpinnerPlayer : MonoBehaviour
{
    [SerializeField] GameObject _panelCanel;
    [SerializeField] GameObject _panelMoney;
    [SerializeField] GameObject _panelUnLockLevel;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] CircularScrollingList _list;
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
    public GameObject _btnCommingSoon;
    public GameObject title;
    public GameObject titleCommingSoon;
    public static DataPlayer currentPlayerData;
    public Image[] _imgPlayerCircol;
    public Sprite[] _spritePlayerLoad;
    public Transform[] obj;
    public DataPlayer[] player;
    public GameObject[] listEffect;

    private int[] LevelSSJ = new int[5];
    private Vector2 ScrollPosition;
    bool isCheck = true;
    bool isCheckAnim = true;
    private int currentIndex = 0;
    private int center = 0;
    private Vector3[] initialPositions;
    private Vector3 scrollViewCenterPosition;
    int txt, Coin, levelValue;


    private void Start()
    {

        _imgPlayerCircol[0].transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
        listEffect[0].SetActive(true);
        center = 0;
        _imgPlayerCircol[0].sprite = _spritePlayerLoad[0];
        _imgPlayerCircol[1].sprite = _spritePlayerLoad[1];
        _imgPlayerCircol[2].sprite = _spritePlayerLoad[2];
        _imgPlayerCircol[3].sprite = _spritePlayerLoad[3];
        _imgPlayerCircol[4].sprite = _spritePlayerLoad[4];
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

        if (!isCheck)
        {
            txtLevel.text = "0";
        }
        int playerIndex = center;
        int id = PlayerPrefs.GetInt("idPlayer");
        currentPlayerData = player[playerIndex];
        DisplayCurrentPlayerData();
        _imgPlayer.sprite = _spritePlayerLoad[id];
        _imgPlayer2.sprite = _spritePlayerLoad[id];
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
        if (currentPlayerData != null)
        {
            if (currentPlayerData.Active)
            {
                PlayerPrefs.SetInt("idPlayer", 0);
            }
            else
            {
                PlayerPrefs.SetInt("idPlayer", center);
            }
        }

    }


    public void AnimPlayer()
    {
        switch (center)
        {
            case 0:
                _imgPlayerCircol[0].transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
                _imgPlayerCircol[1].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[2].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[3].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[4].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[1].transform.DOKill();
                _imgPlayerCircol[2].transform.DOKill();
                _imgPlayerCircol[3].transform.DOKill();
                _imgPlayerCircol[4].transform.DOKill();
                listEffect[0].SetActive(true);
                listEffect[1].SetActive(false);
                listEffect[2].SetActive(false);
                listEffect[3].SetActive(false);
                listEffect[4].SetActive(false);
                break;
            case 1:
                _imgPlayerCircol[1].transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
                _imgPlayerCircol[0].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[2].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[3].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[4].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[0].transform.DOKill();
                _imgPlayerCircol[2].transform.DOKill();
                _imgPlayerCircol[3].transform.DOKill();
                _imgPlayerCircol[4].transform.DOKill();
                listEffect[0].SetActive(false);
                listEffect[1].SetActive(true);
                listEffect[2].SetActive(false);
                listEffect[3].SetActive(false);
                listEffect[4].SetActive(false);
                break;
            case 2:
                _imgPlayerCircol[2].transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
                _imgPlayerCircol[1].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[0].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[3].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[4].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[1].transform.DOKill();
                _imgPlayerCircol[0].transform.DOKill();
                _imgPlayerCircol[3].transform.DOKill();
                _imgPlayerCircol[4].transform.DOKill();
                listEffect[0].SetActive(false);
                listEffect[1].SetActive(false);
                listEffect[2].SetActive(true);
                listEffect[3].SetActive(false);
                listEffect[4].SetActive(false);
                break;
            case 3:
                _imgPlayerCircol[3].transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
                _imgPlayerCircol[1].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[2].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[0].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[4].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[1].transform.DOKill();
                _imgPlayerCircol[2].transform.DOKill();
                _imgPlayerCircol[0].transform.DOKill();
                _imgPlayerCircol[4].transform.DOKill();
                listEffect[0].SetActive(false);
                listEffect[1].SetActive(false);
                listEffect[2].SetActive(false);
                listEffect[3].SetActive(true);
                listEffect[4].SetActive(false);
                break;
            case 4:
                _imgPlayerCircol[4].transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
                _imgPlayerCircol[1].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[2].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[3].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[0].transform.localPosition = Vector2.zero;
                _imgPlayerCircol[0].transform.DOKill();
                _imgPlayerCircol[1].transform.DOKill();
                _imgPlayerCircol[2].transform.DOKill();
                _imgPlayerCircol[3].transform.DOKill();
                listEffect[0].SetActive(false);
                listEffect[1].SetActive(false);
                listEffect[2].SetActive(false);
                listEffect[3].SetActive(false);
                listEffect[4].SetActive(true);
                break;
        }
    }
    public void nextPlayer()
    {
        if (isCheck)
        {
            isCheckAnim = false;
            _imgPlayerCircol[center].sprite = currentPlayerData.listSprite[0];
            ResetListPlayer();
            isCheck = false;
            center = (center + 1) % obj.Length;
            obj[0].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[0].position, 1).OnComplete(() =>
            {
                AnimPlayer();
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
            isCheckAnim = false;
            _imgPlayerCircol[center].sprite = currentPlayerData.listSprite[0];
            isCheck = false;
            center = (center + obj.Length - 1) % obj.Length;
            obj[0].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[0].position, 1).OnComplete(() =>
            {
                AnimPlayer();
                ResetListPlayer();
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
        SpinnerPlayer.currentPlayerData.currentLevel = levelValue.ToString();
        string txtlevel = currentPlayerData.currentLevel;
        int intlevel = int.Parse(txtlevel.ToString());
        if (currentPlayerData.Active == true)
        {
            title.SetActive(false);
            titleCommingSoon.SetActive(true);
            _btnActive.SetActive(false);
            _btnUnLock.SetActive(false);
            _btnCommingSoon.SetActive(true);
        }
        else if (txt <= intlevel)
        {
            title.SetActive(true);
            titleCommingSoon.SetActive(false);
            _btnActive.SetActive(true);
            _btnUnLock.SetActive(false);
            _btnCommingSoon.SetActive(false);
            txtPrice.text = "FREE";
        }
        else
        {
            title.SetActive(true);
            titleCommingSoon.SetActive(false);
            _btnUnLock.SetActive(true);
            _btnActive.SetActive(false);
            _btnCommingSoon.SetActive(false);
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
                _panelUnLockLevel.SetActive(true);
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
        _panelUnLockLevel.SetActive(false);
    }

    public void ResetListPlayer()
    {
        _list.Refresh(0);
    }

    private void DisplayCurrentPlayerData()
    {
        txtName.text = currentPlayerData.name;
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
