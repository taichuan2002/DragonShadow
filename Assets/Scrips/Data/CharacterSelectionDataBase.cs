using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionDataBase : MonoBehaviour
{
    public GameObject[] characters;
    public Transform StartPoint;
    public GameObject ObjHealingbar;
    public GameObject DeadGame;
    public GameObject WinGame;
    public Button[] _btn;

    private void Start()
    {
        OnInit();
    }

    public void AssignButton()
    {
        for (int i = 0; i < _btn.Length; i++)
        {
            int center = PlayerPrefs.GetInt("idPlayer");
            if (i == center)
            {
                _btn[i].interactable = true;
            }
            else
            {
                _btn[i].interactable = false;
            }
        }
    }

    private void Update()
    {
        IsCheckDead();
    }

    public void OnInit()
    {
        int numberCharacter = PlayerPrefs.GetInt("idPlayer");
        GameObject prefabs = characters[numberCharacter];
        Instantiate(prefabs, StartPoint.position, Quaternion.identity);
    }



    public void IsCheckDead()
    {
        if (PlayerController.playerData.isDead)
        {
            DeadGame.SetActive(true);
            WinGame.SetActive(false);
            StartCoroutine(DelayNextScene());
        }
        if (Bot.dataEneMy.isDead)
        {
            DeadGame.SetActive(false);
            WinGame.SetActive(true);
            StartCoroutine(DelayNextScene());
        }
    }

    IEnumerator DelayNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

}

