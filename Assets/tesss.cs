using AirFishLab.ScrollingList;
using AirFishLab.ScrollingList.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AirFishLab.ScrollingList.ListBank;

public class tesss : MonoBehaviour
{
    [SerializeField]
    Image _autoUpdatedContentSprite;

    public void OnFocusingBoxChanged(
           ListBox prevFocusingBox, ListBox curFocusingBox)
    {
        int a = ((IntListBox)curFocusingBox).Content;
        //_autoUpdatedContentSprite.sprite = spinnerPlayer.currentPlayerData.listSprite[a];
    }
}
