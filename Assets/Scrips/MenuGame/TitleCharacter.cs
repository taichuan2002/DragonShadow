using AirFishLab.ScrollingList.Demo;
using AirFishLab.ScrollingList;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCharacter : MonoBehaviour
{
    [SerializeField]
    private CircularScrollingList _list;
    [SerializeField] private Text txt;
    public void OnFocusingBoxChanged(
            ListBox prevFocusingBox, ListBox curFocusingBox)
    {
        var focusedContent = ((IntListBox)curFocusingBox).Content;

        txt.text = focusedContent.ToString();

    }
}
