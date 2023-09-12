﻿using AirFishLab.ScrollingList.ContentManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBox : ListBox
    {
        [SerializeField] private TextMeshProUGUI _contentText;

        public int Content { get; private set; }
        public Image ImgNV { get; private set; }



        protected override void UpdateDisplayContent(IListContent listContent)
        {
            Content = ((IntListContent)listContent).Value;
            _contentText.text = Content.ToString();

        }


    }


}
