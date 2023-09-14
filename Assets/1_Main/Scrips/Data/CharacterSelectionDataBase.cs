using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionDataBase : MonoBehaviour
{
    [SerializeField] GameObject healingEnemy;
    [SerializeField] GameObject healingPlayer;
    [SerializeField] protected HealingEnemy healbarEnemy;
    [SerializeField] protected Healing healbarPlayer;
    [SerializeField] TextMeshProUGUI _txtEnemyDead;
    [SerializeField] TextMeshProUGUI _txtBean;
    [SerializeField] GameObject _panelSetting;
    public Transform StartPoint;
    public Transform StartPointEnemy;
    public GameObject ObjHealingbar;
    public GameObject DeadGame;
    public GameObject WinGame;
    public GameObject[] characters;
    public GameObject[] arrEnemys;
    [SerializeField] Button[] _txtBtnSkill;
    [SerializeField] Button[] _txtBtnSetting;
    [SerializeField] Image[] _imgBtn;
    [SerializeField] Sprite[] _spriteBtn;
    [SerializeField] Image[] Backgrounds;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioBtn;
    [SerializeField] AudioClip[] _audioClips;
    [SerializeField] GameObject panelGameController;
    [SerializeField] GameObject panelGameOver;
    private GameObject prefabs;
    private GameObject enemy1, enemy2, enemy3, enemy4;
    private int level, numberCharacter, EnemyDead, bean, random, mussic, audio;
    private bool spownEnemy1 = false;
    private bool spownEnemy2 = false;
    private bool spownEnemy3 = false;
    private bool spownEnemy4 = false;
    private bool isCheck = false;
    private bool isSSJ = false;
    private bool isMussic = false;
    private bool isAudio = false;
    private bool isDead = false;
    private void Start()
    {

        OnInit();
        OnAudio();
    }

    public void OnAudio()
    {
        mussic = PlayerPrefs.GetInt("mussic");
        audio = PlayerPrefs.GetInt("audioClick");
        Color currentColor = _imgBtn[0].color;
        if (mussic == 0)
        {
            currentColor.a = 1f;
            _imgBtn[1].color = currentColor;
            isMussic = false;
        }
        if (mussic == 1)
        {
            currentColor.a = 0.5f;
            _imgBtn[1].color = currentColor;
            isMussic = true;
        }
        if (audio == 0)
        {
            currentColor.a = 1f;
            _imgBtn[2].color = currentColor;
            isAudio = false;
        }
        if (audio == 1)
        {
            currentColor.a = 0.5f;
            _imgBtn[2].color = currentColor;
            isAudio = true;
        }
        Mussic();
    }
    private void Update()
    {
        GameObject LevelSSj = GameObject.FindGameObjectWithTag("EnemyDead");
        _txtEnemyDead = LevelSSj.GetComponent<TextMeshProUGUI>();
        _txtEnemyDead.text = EnemyDead.ToString();
        LevelEnemy();
        IsCheckDeadPlayer();
        bean = PlayerPrefs.GetInt("Bean");
        _txtBean.text = bean.ToString();
        if (!isSSJ)
        {
            UnlockSkill();
        }
    }

    public void OnInitLevelMap()
    {
        PlayerPrefs.SetInt("levelMap", level);
        PlayerPrefs.Save();
    }

    public void UnlockSkill()
    {
        int levelSSJ = PlayerPrefs.GetInt("SSJ");
        if (levelSSJ >= 3)
        {
            _txtBtnSkill[1].interactable = true;
        }
        if (levelSSJ >= 6)
        {
            _txtBtnSkill[0].interactable = true;
            isSSJ = true;
        }
    }

    public void BtnPouse()
    {
        BtnSetting();
        _imgBtn[0].sprite = _spriteBtn[0];
        Time.timeScale = 0;
        _panelSetting.SetActive(true);
    }

    public void BtnStart()
    {
        BtnSetting();
        Time.timeScale = 1;
        _imgBtn[0].sprite = _spriteBtn[1];
        _panelSetting.SetActive(false);
    }

    public void BtnHome()
    {
        BtnSetting();
        PlayerPrefs.SetInt("btn", 1);
        PlayerPrefs.SetInt("SSJ", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void BtnMussic()
    {
        BtnSetting();
        Color currentColor = _imgBtn[1].color;
        if (!isMussic)
        {
            audioSource.Stop();
            currentColor.a = 0.5f;
            _imgBtn[1].color = currentColor;
            PlayerPrefs.SetInt("mussic", 1);
            PlayerPrefs.Save();
            isMussic = true;
        }
        else
        {
            isMussic = false;
            audioSource.Play();
            currentColor.a = 1;
            _imgBtn[1].color = currentColor;
            PlayerPrefs.SetInt("mussic", 0);
            PlayerPrefs.Save();
            Debug.Log(isMussic);

        }
    }
    public void BtnAudio()
    {
        BtnSetting();
        Color currentColor = _imgBtn[0].color;
        if (!isAudio)
        {
            currentColor.a = 0.5f;
            _imgBtn[2].color = currentColor;
            PlayerPrefs.SetInt("audioClick", 1);
            PlayerPrefs.Save();
            isAudio = true;
        }
        else
        {
            currentColor.a = 1;
            _imgBtn[2].color = currentColor;
            PlayerPrefs.SetInt("audioClick", 0);
            PlayerPrefs.Save();
            isAudio = false;
        }
    }

    public void LevelEnemy()
    {
        level = PlayerPrefs.GetInt("levelMap");
        if (!isCheck)
        {
            switch (level)
            {
                case 0:
                    EnemyDead = 1;
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();
                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
                        EnemyDead = 0;
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 1;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 1:
                    EnemyDead = 1;
                    if (!spownEnemy2)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 1);
                        PlayerPrefs.Save();
                        enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy2 = true;
                    }
                    if (enemy2 == null)
                    {
                        EnemyDead = 0;
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 2;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 2:
                    EnemyDead = 1;
                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();

                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
                        EnemyDead = 0;
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 3;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 3:
                    EnemyDead = 1;
                    if (!spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 3);
                        PlayerPrefs.Save();
                        enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy4 = true;
                    }
                    if (enemy4 == null)
                    {
                        EnemyDead = 0;
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 4;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();

                    }
                    break;
                case 4:
                    EnemyDead = 2;
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();
                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
                        EnemyDead = 1;
                        if (!spownEnemy2)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 1);
                            PlayerPrefs.Save();
                            enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                            enemy2.transform.SetParent(healingEnemy.transform);
                            spownEnemy2 = true;
                        }
                        if (enemy2 == null)
                        {
                            EnemyDead = 0;
                            int Coin = PlayerPrefs.GetInt("Coin");
                            Coin += 60;
                            PlayerPrefs.SetInt("Coin", Coin);
                            PlayerPrefs.Save();
                            level = 5;
                            OnInitLevelMap();
                            IsCheckDeadEnemy();

                        }
                    }

                    break;
                case 5:
                    EnemyDead = 2;
                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();
                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
                        EnemyDead = 1;
                        if (!spownEnemy4)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 3);
                            PlayerPrefs.Save();
                            enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                            enemy4.transform.SetParent(healingEnemy.transform);
                            spownEnemy4 = true;
                        }
                        if (enemy4 == null)
                        {
                            EnemyDead = 0;
                            int Coin = PlayerPrefs.GetInt("Coin");
                            Coin += 60;
                            PlayerPrefs.SetInt("Coin", Coin);
                            PlayerPrefs.Save();
                            level = 6;
                            OnInitLevelMap();
                            IsCheckDeadEnemy();
                        }
                    }
                    break;
                case 6:
                    EnemyDead = 1;
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();

                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }

                    if (enemy1 == null)
                    {
                        EnemyDead = 0;
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 7;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 7:
                    EnemyDead = 3;
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();
                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
                        EnemyDead = 2;
                        if (!spownEnemy2)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 2);
                            PlayerPrefs.Save();
                            enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                            enemy2.transform.SetParent(healingEnemy.transform);
                            spownEnemy2 = true;
                        }
                        if (enemy2 == null && enemy1 == null)
                        {
                            EnemyDead = 1;
                            if (!spownEnemy3)
                            {
                                PlayerPrefs.SetInt("IdEnemy", 3);
                                PlayerPrefs.Save();
                                enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                                enemy3.transform.SetParent(healingEnemy.transform);
                                spownEnemy3 = true;
                            }
                            if (enemy3 == null && enemy2 == null && enemy1 == null)
                            {
                                EnemyDead = 0;
                                int Coin = PlayerPrefs.GetInt("Coin");
                                Coin += 60;
                                PlayerPrefs.SetInt("Coin", Coin);
                                PlayerPrefs.Save();
                                level = 8;
                                OnInitLevelMap();
                                IsCheckDeadEnemy();
                            }
                        }
                    }
                    break;
                case 8:
                    EnemyDead = 3;
                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();
                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
                        EnemyDead = 2;
                        if (!spownEnemy1)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 0);
                            PlayerPrefs.Save();
                            enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                            enemy1.transform.SetParent(healingEnemy.transform);
                            spownEnemy1 = true;
                        }
                        if (enemy3 == null && enemy1 == null)
                        {
                            EnemyDead = 1;
                            if (!spownEnemy4)
                            {
                                PlayerPrefs.SetInt("IdEnemy", 3);
                                PlayerPrefs.Save();
                                enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                                enemy4.transform.SetParent(healingEnemy.transform);
                                spownEnemy4 = true;
                            }
                            if (enemy3 == null && enemy4 == null && enemy1 == null)
                            {
                                EnemyDead = 0;
                                int Coin = PlayerPrefs.GetInt("Coin");
                                Coin += 60;
                                PlayerPrefs.SetInt("Coin", Coin);
                                PlayerPrefs.Save();
                                level = 9;
                                OnInitLevelMap();
                                IsCheckDeadEnemy();
                            }
                        }
                    }
                    break;
                case 9:
                    EnemyDead = 3;
                    if (!spownEnemy2)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 1);
                        PlayerPrefs.Save();
                        enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy2 = true;
                    }
                    if (enemy2 == null)
                    {
                        EnemyDead = 2;
                        if (!spownEnemy1)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 0);
                            PlayerPrefs.Save();
                            enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                            enemy1.transform.SetParent(healingEnemy.transform);
                            spownEnemy1 = true;
                        }
                        if (enemy3 == null && enemy1 == null)
                        {
                            EnemyDead = 1;
                            if (!spownEnemy4)
                            {
                                PlayerPrefs.SetInt("IdEnemy", 3);
                                PlayerPrefs.Save();
                                enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                                enemy4.transform.SetParent(healingEnemy.transform);
                                spownEnemy4 = true;
                            }
                            if (enemy3 == null && enemy4 == null && enemy1 == null)
                            {
                                EnemyDead = 0;
                                int Coin = PlayerPrefs.GetInt("Coin");
                                Coin += 60;
                                PlayerPrefs.SetInt("Coin", Coin);
                                PlayerPrefs.Save();
                                level = 10;
                                OnInitLevelMap();
                                IsCheckDeadEnemy();
                            }
                        }
                    }
                    break;
                case 10:
                    EnemyDead = 1;
                    if (!spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 3);
                        PlayerPrefs.Save();
                        enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy4 = true;
                    }
                    if (enemy4 == null)
                    {
                        EnemyDead = 0;
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 11;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 11:
                    EnemyDead = 2;
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();
                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
                        EnemyDead = 1;
                        if (!spownEnemy2)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 1);
                            PlayerPrefs.Save();
                            enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                            enemy2.transform.SetParent(healingEnemy.transform);
                            spownEnemy2 = true;
                        }
                        if (enemy2 == null)
                        {
                            EnemyDead = 0;
                            int Coin = PlayerPrefs.GetInt("Coin");
                            Coin += 60;
                            PlayerPrefs.SetInt("Coin", Coin);
                            PlayerPrefs.Save();
                            level = 12;
                            OnInitLevelMap();
                            IsCheckDeadEnemy();

                        }
                    }
                    break;
                case 12:
                    EnemyDead = 2;
                    if (!spownEnemy2)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 1);
                        PlayerPrefs.Save();
                        enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy2 = true;
                    }
                    if (enemy2 == null)
                    {
                        EnemyDead = 1;
                        if (!spownEnemy3)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 2);
                            PlayerPrefs.Save();
                            enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                            enemy3.transform.SetParent(healingEnemy.transform);
                            spownEnemy3 = true;
                        }
                        if (enemy3 == null)
                        {
                            EnemyDead = 0;
                            int Coin = PlayerPrefs.GetInt("Coin");
                            Coin += 60;
                            PlayerPrefs.SetInt("Coin", Coin);
                            PlayerPrefs.Save();
                            level = 13;
                            OnInitLevelMap();
                            IsCheckDeadEnemy();

                        }
                    }
                    break;
                case 13:
                    EnemyDead = 2;

                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();

                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
                        EnemyDead = 1;

                        if (!spownEnemy4)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 3);
                            PlayerPrefs.Save();

                            enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                            enemy4.transform.SetParent(healingEnemy.transform);
                            spownEnemy4 = true;
                        }
                        if (enemy4 == null)
                        {
                            if (!spownEnemy4)
                            {
                                EnemyDead = 0;

                                int Coin = PlayerPrefs.GetInt("Coin");
                                Coin += 60;
                                PlayerPrefs.SetInt("Coin", Coin);
                                PlayerPrefs.Save();
                                level = 14;
                                OnInitLevelMap();
                                IsCheckDeadEnemy();
                            }
                        }
                    }
                    break;
                case 14:
                    EnemyDead = 1;

                    if (!spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 3);
                        PlayerPrefs.Save();
                        enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy4 = true;
                        if (enemy4 != null)
                        {
                            EnemyDead = 0;

                            int Coin = PlayerPrefs.GetInt("Coin");
                            Coin += 60;
                            PlayerPrefs.SetInt("Coin", Coin);
                            PlayerPrefs.Save();
                            level = 15;
                            OnInitLevelMap();
                            IsCheckDeadEnemy();
                        }
                    }
                    break;
            }
        }
    }
    public void OnInit()
    {
        _txtBtnSkill[0].interactable = false;
        _txtBtnSkill[1].interactable = false;
        numberCharacter = PlayerPrefs.GetInt("idPlayer");
        prefabs = characters[numberCharacter];
        Instantiate(prefabs, StartPoint.position, Quaternion.identity);
    }
    public void IsCheckDeadPlayer()
    {
        if (!isDead)
        {
            if (PlayerController.playerData)
            {
                if (PlayerController.playerData.isDead == true)
                {
                    audioBtn.PlayOneShot(_audioClips[2]);
                    isCheck = true;
                    DeadGame.SetActive(true);
                    WinGame.SetActive(false);
                    level -= 2;
                    if (level <= 0)
                    {
                        level = 0;
                    }
                    PlayerPrefs.SetInt("levelMap", level);
                    PlayerPrefs.Save();
                    StartCoroutine(DelayNextScene());
                    isDead = true;
                }
            }
        }

    }
    public void IsCheckDeadEnemy()
    {
        if (enemy1 == null || enemy2 == null || enemy3 == null || enemy4 == null)
        {
            audioBtn.PlayOneShot(_audioClips[3]);
            DeadGame.SetActive(false);
            WinGame.SetActive(true);
            Bot.dataEneMy.isDead = true;
            StartCoroutine(DelayNextScene());
        }
    }

    IEnumerator DelayNextScene()
    {
        isCheck = true;
        yield return new WaitForSeconds(4);
        panelGameOver.SetActive(true);
        panelGameController.SetActive(false);
        //SceneManager.LoadScene(1);
    }

    public void Mussic()
    {
        if (!isMussic)
        {
            audioSource.Play();
        }
    }

    public void BtnSetting()
    {
        if (!isAudio)
        {
            audioBtn.PlayOneShot(_audioClips[1]);
        }
    }
}


