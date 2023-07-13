using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    [SerializeField] private Image imgFillhp;
    [SerializeField] private Image imgFillmana;

    public float hp;
    public float mana;
    private float maxHp;
    private float maxMana;

    private void Start()
    {
        this.maxHp = 100;
        this.maxMana = 100;
        this.hp = 100;
        this.mana = 100;
    }

    private void Update()
    {
        imgFillhp.fillAmount = Mathf.Lerp(imgFillhp.fillAmount, hp / maxHp, Time.deltaTime * 3);
        imgFillmana.fillAmount = Mathf.Lerp(imgFillmana.fillAmount, mana / maxMana,Time.deltaTime *3);
        healingMana();
    }
    public void OnInit(float maxhp, float maxmana)
    {
        this.maxHp= maxhp;
        this.maxMana= maxmana;
        hp = maxhp;
        mana = maxmana;
        imgFillhp.fillAmount = 1;
        imgFillmana.fillAmount = 1;
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;
    }
    public void SetNewMana(float mana)
    {
        this.mana = mana;
    }
    private void healingMana()
    {
        if (mana < maxMana)
        {
            mana += 30f * Time.deltaTime;
            if (mana > maxMana)
            {
                mana = 100;
            }
        }
    }

    public void onHp(float dame)
    {
        hp -= dame;
    }
    public void onMana(float manax)
    {
        mana -= manax;
    }
}
