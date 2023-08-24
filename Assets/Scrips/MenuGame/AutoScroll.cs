using DanielLochner.Assets.SimpleScrollSnap;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    [SerializeField] SimpleScrollSnap[] slots;
    int slotIndex;
    private void Start()
    {
        slotIndex = PlayerPrefs.GetInt("levelMap");
        Scrolllevel();
    }
    private void Awake()
    {
        Scrolllevel();
    }
    public void Scrolllevel()
    {

        foreach (SimpleScrollSnap slot in slots)
        {
            slot.GoToPanel(0);
        }
    }

    public void ScrollNextlevel()
    {
        foreach (SimpleScrollSnap slot in slots)
        {
            slot.GoToPanel(slotIndex);
        }
    }
    public void ScrollDefault()
    {
        foreach (SimpleScrollSnap slot in slots)
        {
            slot.GoToPanel(slotIndex - 1);
        }
    }

    private void OnEnable()
    {
        Scrolllevel();
    }
}
