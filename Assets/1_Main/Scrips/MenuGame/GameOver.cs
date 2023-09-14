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
    [SerializeField] Image _ImgCamera;
    [SerializeField] Image _ImgX2;
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip[] _AudioClip;
    int Number;
    int pl, Coin, tongCoin;
    void Start()
    {
        PlayerPrefs.SetInt("btn", 0);
        pl = PlayerPrefs.GetInt("idPlayer");
        _ImgCamera.transform.DORotate(new Vector3(0, 0, -30), 3f).SetLoops(-1, LoopType.Yoyo);
        _ImgX2.transform.DOScale(new Vector3(1f, 1f, 1), 0.6f).SetLoops(-1, LoopType.Yoyo);
        PlayerPrefs.Save();
        _ImgPlayer.transform.DOLocalMove(new Vector2(0, 30), 3).SetLoops(-1, LoopType.Yoyo);
        tongCoin = PlayerPrefs.GetInt("tongCoin");
        Coin = PlayerPrefs.GetInt("Coin");
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
        }
        StartCoroutine(Title());
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
    IEnumerator Title()
    {
        yield return new WaitForSeconds(0.5f);
        if (Enemy[0].isDead || Enemy[1].isDead || Enemy[2].isDead || Enemy[3].isDead)
        {
            AudioCoin();
            _txtPointCoins[1].text = "60";
        }
        else
        {
            AudioCoin();
            _txtPointCoins[1].text = "0";
        }
        yield return new WaitForSeconds(0.5f);
        AudioCoin();
        _txtPointCoins[2].text = tongCoin.ToString();
        yield return new WaitForSeconds(0.5f);
        AudioCoin();
        _txtPointCoins[3].text = tongCoin.ToString();
        yield return new WaitForSeconds(0.5f);
        AudioTongCoin();
        _txtPointCoins[0].text = Coin.ToString();
    }
    public void AudioCoin()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            _AudioSource.PlayOneShot(_AudioClip[0]);
        }
    }
    public void AudioTongCoin()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            _AudioSource.PlayOneShot(_AudioClip[1]);
        }
    }
}
