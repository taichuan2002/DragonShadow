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
    int levelValue;
    private void Update()
    {

        int txt = int.Parse(txtLevel.text);
        if (txt >= 0 && txt < 21)
        {
            if (SpinnerPlayer.currentPlayerData != null)
            {
                _imgLevel.sprite = SpinnerPlayer.currentPlayerData.listSprite[txt];
            }
        }
        string text = txtLevel.text;
        if (SpinnerPlayer.currentPlayerData != null)
        {
            levelValue = int.Parse(SpinnerPlayer.currentPlayerData.currentLevel);

        }
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

