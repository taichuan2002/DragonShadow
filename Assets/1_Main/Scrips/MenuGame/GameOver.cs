using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _victoryGame;
    [SerializeField] GameObject _deadGame;
    [SerializeField] DataPlayer[] player;
    [SerializeField] DataEneMy[] Enemy;
    [SerializeField] TextMeshProUGUI[] _txtPointCoins;
    [SerializeField] Image _ImgPlayer;
    int Number;
    int pl, Coin;
    void Start()
    {
        PlayerPrefs.SetInt("btn", 0);
        pl = PlayerPrefs.GetInt("idPlayer");
        PlayerPrefs.Save();
        _ImgPlayer.transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
        int tongCoin = PlayerPrefs.GetInt("tongCoin");
        Coin = PlayerPrefs.GetInt("Coin");
        _txtPointCoins[0].text = Coin.ToString();
        _txtPointCoins[1].text = tongCoin.ToString();
        Number = PlayerPrefs.GetInt("SSJ");
        _ImgPlayer.sprite = PlayerController.playerData.listSprite[Number];
        if (PlayerController.playerData.isDead)
        {
            _deadGame.SetActive(true);
            _victoryGame.SetActive(false);
            player[pl].isDead = false;
            Enemy[0].isDead = false;
            Enemy[1].isDead = false;
            Enemy[2].isDead = false;
            Enemy[3].isDead = false;
            _txtPointCoins[3].text = tongCoin.ToString();
        }
        if (Enemy[0].isDead || Enemy[1].isDead || Enemy[2].isDead || Enemy[3].isDead)
        {
            _deadGame.SetActive(false);
            _victoryGame.SetActive(true);
            player[pl].isDead = false;
            Enemy[0].isDead = false;
            Enemy[1].isDead = false;
            Enemy[2].isDead = false;
            Enemy[3].isDead = false;
            tongCoin += 60;
            _txtPointCoins[2].text = "60";
            _txtPointCoins[3].text = tongCoin.ToString();
        }
    }

    public void BtnHome()
    {
        PlayerPrefs.SetInt("btn", 1);
        PlayerPrefs.SetInt("SSJ", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
    public void BtnHero()
    {
        PlayerPrefs.SetInt("btn", 2);
        PlayerPrefs.SetInt("SSJ", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
    public void BtnPlay()
    {
        PlayerPrefs.SetInt("btn", 3);
        PlayerPrefs.SetInt("SSJ", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
