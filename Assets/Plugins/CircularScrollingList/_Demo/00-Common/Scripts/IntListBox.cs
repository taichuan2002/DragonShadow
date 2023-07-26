using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;
using UnityEngine.UI;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBox : ListBox
    {
        [SerializeField] private Text _contentText;
        [SerializeField] private Sprite[] _sprite;
        [SerializeField] private Image _img;

        public int Content { get; private set; }

        protected override void UpdateDisplayContent(IListContent listContent)
        {
            Content = ((IntListContent)listContent).Value;
            _contentText.text = Content.ToString();

            if(Content >= 0 && Content < _sprite.Length)
            {
                _img.sprite = _sprite[Content];
            }
        }
    }
}
