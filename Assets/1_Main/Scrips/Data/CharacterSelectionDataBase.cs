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
    public Image[] Backgrounds;
    public Sprite[] sprites;

    private GameObject prefabs;
    private GameObject enemy1, enemy2, enemy3, enemy4;
    private int level, numberCharacter, EnemyDead, bean, random;
    private bool spownEnemy1 = false;
    private bool spownEnemy2 = false;
    private bool spownEnemy3 = false;
    private bool spownEnemy4 = false;
    private bool isCheck = false;
    private bool isSSJ = false;
    private void Start()
    {
        OnInit();
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
        _imgBtn[0].sprite = _spriteBtn[0];
        Time.timeScale = 0;
        _panelSetting.SetActive(true);
    }

    public void BtnStart()
    {
        Time.timeScale = 1;
        _imgBtn[0].sprite = _spriteBtn[1];
        _panelSetting.SetActive(false);
    }

    public void BtnHome()
    {
        PlayerPrefs.SetInt("btn", 1);
        PlayerPrefs.SetInt("SSJ", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void BtnMussic()
    {

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
        random = Random.Range(0, 4);
        switch (random)
        {
            /*case 0:
                Backgrounds[0].sprite = sprites[0];
                Backgrounds[1].sprite = sprites[1];
                break;
            case 1:
                Backgrounds[0].sprite = sprites[2];
                Backgrounds[1].sprite = sprites[3];
                break;
            case 2:
                Backgrounds[0].sprite = sprites[4];
                Backgrounds[1].sprite = sprites[5];
                break;
            case 3:
                Backgrounds[0].sprite = sprites[6];
                Backgrounds[1].sprite = sprites[7];
                break;*/

        }
        _txtBtnSkill[0].interactable = false;
        _txtBtnSkill[1].interactable = false;
        numberCharacter = PlayerPrefs.GetInt("idPlayer");
        prefabs = characters[numberCharacter];
        Instantiate(prefabs, StartPoint.position, Quaternion.identity);
    }
    public void IsCheckDeadPlayer()
    {
        if (PlayerController.playerData.isDead == true)
        {
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
            PlayerController.playerData.isDead = false;
            StartCoroutine(DelayNextScene());
        }
    }
    public void IsCheckDeadEnemy()
    {
        if (enemy1 == null || enemy2 == null || enemy3 == null || enemy4 == null)
        {
            DeadGame.SetActive(false);
            WinGame.SetActive(true);
            Bot.dataEneMy.isDead = true;
            StartCoroutine(DelayNextScene());
        }
    }

    IEnumerator DelayNextScene()
    {
        isCheck = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

}


