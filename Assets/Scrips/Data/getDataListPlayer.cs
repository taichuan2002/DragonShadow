using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class getDataListPlayer : MonoBehaviour
{
    public Image _imgLevel;
    public TextMeshProUGUI txtLevel;
    public GameObject _imgActive;



    void Update()
    {
        int txt = int.Parse(txtLevel.text);
        if (txt >= 0 && txt < spinnerPlayer.currentPlayerData.listSprite.Length)
        {
            _imgLevel.sprite = spinnerPlayer.currentPlayerData.listSprite[txt];
        }
        string text = txtLevel.text;
        int levelValue = int.Parse(spinnerPlayer.currentPlayerData.currentLevel);
        int levelData = int.Parse(text);
        if (levelData <= levelValue)
        {
            _imgActive.SetActive(false);
        }
        else
        {
            _imgActive.SetActive(true);
        }
    }
}
