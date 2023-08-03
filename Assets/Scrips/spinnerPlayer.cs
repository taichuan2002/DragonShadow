using AirFishLab.ScrollingList.Demo;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinnerPlayer : MonoBehaviour
{
    public Transform[] obj;
    bool isCheck = true;
    private int currentIndex = 0;
    private int center = 0;

    public DataPlayer[] player;
    public Text txtName;
    public Text txtLevel;
    public Image _imgPlayer;
    public Image _imgPlayer2;
    public Sprite[] _spritePlayerLoad;

    private Vector3[] initialPositions;
    private Vector3 scrollViewCenterPosition;
    public static DataPlayer currentPlayerData;
    private void Start()
    {
        OnInit();
        if (obj.Length > 0)
        {
            scrollViewCenterPosition = obj[0].parent.position;
        }
    }

    public void OnInit()
    {
        initialPositions = new Vector3[obj.Length];
        for (int i = 0; i < obj.Length; i++)
        {
            initialPositions[i] = obj[i].position;
        }
    }

    private void Update()
    {
        int playerIndex = center;
        currentPlayerData = player[playerIndex];
        DisplayCurrentPlayerData();
        _imgPlayer.sprite = _spritePlayerLoad[center];
        _imgPlayer2.sprite = _spritePlayerLoad[center];
    }

    public void nextPlayer()
    {
        if (isCheck)
        {
            isCheck = false;
            obj[0].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[0].position, 1).OnComplete(() =>
            {
                UpdateTransformOrder();
                center = (center + 1) % obj.Length;
                DisplayCurrentPlayerData();
                isCheck = true;
            });
        }

    }

    public void backPlayer()
    {
        if (isCheck)
        {
            isCheck = false;
            obj[0].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[0].position, 1).OnComplete(() =>
            {
                UpdateTransformOrder();
                center = (center + obj.Length - 1) % obj.Length;
                DisplayCurrentPlayerData();
                isCheck = true;
            });
        }
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

    private void DisplayCurrentPlayerData()
    {

        txtName.text = currentPlayerData.name;
    }
}
