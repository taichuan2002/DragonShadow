using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnActiveCharacter : MonoBehaviour
{
    public DataPlayer player;
    public Text level;
    public Button[] btnActive;
    void Start()
    {
        btnActive = GetComponent<Button[]>();
    }
    void Update()
    {
        string text = level.text;
        int levelValue = int.Parse(player.playerProperties.level);
        int levelData = int.Parse(text);
        if (levelData <= levelValue)
        {
            btnActive[0].interactable = true;
            btnActive[1].interactable = false;
        }
        else
        {
            btnActive[0].interactable = false;
            btnActive[1].interactable = true;
        }
    }
}
