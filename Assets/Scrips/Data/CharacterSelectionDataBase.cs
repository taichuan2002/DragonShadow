using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionDataBase : MonoBehaviour
{
    [SerializeField] GameObject healingEnemy;
    [SerializeField] GameObject healingPlayer;
    [SerializeField] protected HealingEnemy healbarEnemy;
    [SerializeField] protected Healing healbarPlayer;
    public GameObject[] characters;
    public GameObject[] arrEnemys;
    public Transform StartPoint;
    public Transform StartPointEnemy;
    public GameObject ObjHealingbar;
    public GameObject DeadGame;
    public GameObject WinGame;
    private GameObject prefabs;
    private GameObject enemy1, enemy2, enemy3, enemy4;

    private int level, numberCharacter;
    private bool spownEnemy1 = false;
    private bool spownEnemy2 = false;
    private bool spownEnemy3 = false;
    private bool spownEnemy4 = false;
    private bool isCheck = false;
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        LevelEnemy();
        IsCheckDeadPlayer();
    }

    public void OnInitLevelMap()
    {
        PlayerPrefs.SetInt("levelMap", level);
        PlayerPrefs.Save();
    }

    public void LevelEnemy()
    {
        level = PlayerPrefs.GetInt("levelMap");
        if (!isCheck)
        {
            switch (level)
            {
                case 0:

                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();
                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
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
                    if (!spownEnemy2)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 1);
                        PlayerPrefs.Save();

                        enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy2 = true;
                    }
                    if (enemy2 == null)
                    {
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
                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();

                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
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
                    if (!spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 3);
                        PlayerPrefs.Save();

                        enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy4 = true;
                    }
                    if (enemy4 == null)
                    {
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
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();

                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
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
                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();

                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
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
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();

                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }

                    if (enemy1 == null)
                    {
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
                    if (!spownEnemy1)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();

                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                    }
                    if (enemy1 == null)
                    {
                        if (!spownEnemy2)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 2);
                            PlayerPrefs.Save();

                            enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                            enemy2.transform.SetParent(healingEnemy.transform);
                            spownEnemy2 = true;
                        }
                        if (enemy2 == null)
                        {
                            if (!spownEnemy3)
                            {
                                PlayerPrefs.SetInt("IdEnemy", 3);
                                PlayerPrefs.Save();

                                enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                                enemy3.transform.SetParent(healingEnemy.transform);
                                spownEnemy3 = true;
                            }
                            if (enemy3 == null)
                            {
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
                    if (!spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();

                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                    }
                    if (enemy3 == null)
                    {
                        if (!spownEnemy1)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 0);
                            PlayerPrefs.Save();

                            enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                            enemy1.transform.SetParent(healingEnemy.transform);
                            spownEnemy1 = true;
                        }
                        if (enemy1 == null)
                        {
                            if (!spownEnemy4)
                            {
                                PlayerPrefs.SetInt("IdEnemy", 3);
                                PlayerPrefs.Save();

                                enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                                enemy4.transform.SetParent(healingEnemy.transform);
                                spownEnemy3 = true;
                            }
                            if (enemy4 == null)
                            {
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
                    if (!spownEnemy2)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 1);
                        PlayerPrefs.Save();

                        enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy2 = true;
                    }
                    if (enemy2 == null)
                    {
                        if (!spownEnemy1)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 0);
                            PlayerPrefs.Save();

                            enemy1 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                            enemy1.transform.SetParent(healingEnemy.transform);
                            spownEnemy1 = true;
                        }
                        if (enemy1 == null)
                        {
                            if (!spownEnemy4)
                            {
                                PlayerPrefs.SetInt("IdEnemy", 3);
                                PlayerPrefs.Save();

                                enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                                enemy4.transform.SetParent(healingEnemy.transform);
                                spownEnemy3 = true;
                            }
                            if (enemy4 == null)
                            {
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
                    if (!spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 3);
                        PlayerPrefs.Save();

                        enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy4 = true;
                    }
                    if (enemy4 == null)
                    {
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
                    if (!spownEnemy1 && !spownEnemy2)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 0);
                        PlayerPrefs.Save();
                        enemy1 = Instantiate(arrEnemys[0], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy1 = true;
                        if (enemy1 != null)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 1);
                            PlayerPrefs.Save();
                            enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                            spownEnemy2 = true;
                        }
                    }
                    if (enemy1 == null & enemy2 == null)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 12;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 12:
                    if (!spownEnemy2 && !spownEnemy3)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 1);
                        PlayerPrefs.Save();
                        enemy2 = Instantiate(arrEnemys[1], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy2 = true;
                        if (enemy2 != null)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 2);
                            PlayerPrefs.Save();
                            enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                            spownEnemy3 = true;
                        }
                    }
                    if (enemy2 == null & enemy3 == null)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 13;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 13:
                    if (!spownEnemy3 && !spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();
                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                        if (enemy3 != null)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 3);
                            PlayerPrefs.Save();
                            enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                            spownEnemy4 = true;
                        }
                    }
                    if (enemy3 == null & enemy4 == null)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 14;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
                case 14:
                    if (!spownEnemy3 && !spownEnemy4)
                    {
                        PlayerPrefs.SetInt("IdEnemy", 2);
                        PlayerPrefs.Save();
                        enemy3 = Instantiate(arrEnemys[2], StartPointEnemy.position, Quaternion.identity);
                        spownEnemy3 = true;
                        if (enemy3 != null)
                        {
                            PlayerPrefs.SetInt("IdEnemy", 3);
                            PlayerPrefs.Save();
                            enemy4 = Instantiate(arrEnemys[3], StartPointEnemy.position, Quaternion.identity);
                            spownEnemy4 = true;
                        }
                    }
                    if (enemy3 == null & enemy4 == null)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin");
                        Coin += 60;
                        PlayerPrefs.SetInt("Coin", Coin);
                        PlayerPrefs.Save();
                        level = 0;
                        OnInitLevelMap();
                        IsCheckDeadEnemy();
                    }
                    break;
            }
        }
    }
    public void OnInit()
    {
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


