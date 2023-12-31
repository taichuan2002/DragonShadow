﻿using AirFishLab.ScrollingList.ContentManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBank : BaseListBank
    {
        [SerializeField]
        private int _numOfContents = 10;
        private readonly List<int> _contents = new List<int>();
        private readonly IntListContent _contentWrapper = new IntListContent();


        private void Awake()
        {
            _contents.Add(0);
            for (var i = 0; i < _numOfContents; ++i)
                _contents.Add(i + 1);
        }

        public override IListContent GetListContent(int index)
        {
            _contentWrapper.Value = _contents[index];
            return _contentWrapper;
        }

        public override int GetContentCount()
        {
            return _contents.Count;
        }
    }
}
