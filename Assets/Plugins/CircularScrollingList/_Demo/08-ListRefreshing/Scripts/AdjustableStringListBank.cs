﻿using AirFishLab.ScrollingList.ContentManagement;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AirFishLab.ScrollingList.Demo
{
    public class AdjustableStringListBank : BaseListBank
    {
        [SerializeField]
        private InputField _contentInputField;
        [SerializeField]
        private string[] _contents = { "1", "2", "3", "4", "5" };
        [SerializeField]
        private CircularScrollingList _circularList;
        [SerializeField]
        private CircularScrollingList _linearList;

        private readonly DataWrapper _dataWrapper = new DataWrapper();

        /// <summary>
        /// Extract the contents from the input field and refresh the list
        /// </summary>
        public void ChangeContents()
        {
            _contents =
                _contentInputField.text.Split(
                    new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            _circularList.Refresh();
            _linearList.Refresh();
        }

        public override IListContent GetListContent(int index)
        {
            _dataWrapper.Data = _contents[index];
            return _dataWrapper;
        }

        public override int GetContentCount()
        {
            return _contents.Length;
        }

        /// <summary>
        /// Used for carrying the data
        /// </summary>
        public class DataWrapper : IListContent
        {
            public string Data;
        }
    }
}
