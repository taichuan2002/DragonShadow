using AirFishLab.ScrollingList.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    public DataPlayer player;
    public Text level;
    public GameObject _obj;

    private void Update()
    {
        string text = level.text;
        int levelValue = int.Parse(player.level);
        int levelData = int.Parse(text);
        if (levelData <= levelValue)
        {
            _obj.SetActive(false);
        }
        else
        {
            _obj.SetActive(true);
        }
    }
}
