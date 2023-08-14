using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    [SerializeField] Image imgFillhp;
    [SerializeField] Image imgFillmana;
    [SerializeField] DataPlayer[] Player;
    public float hp;
    public float mana;
    public float maxHp;
    public float maxMana;
    public float Damage1;
    public float Damage2;
    public float Damage3;
    public float Damage4;

    private void Start()
    {
        int id = PlayerPrefs.GetInt("idPlayer");
        this.maxHp = Player[id].maxHp;
        this.maxMana = Player[id].maxMana;
        this.hp = maxHp;
        this.mana = maxMana;
        this.Damage1 = Player[id].DamageAttack1;
        this.Damage2 = Player[id].DamageAttack2;
        this.Damage3 = Player[id].DamageAttack3;
        this.Damage4 = Player[id].DamageAttack4;

    }

    private void Update()
    {
        imgFillhp.fillAmount = Mathf.Lerp(imgFillhp.fillAmount, hp / maxHp, Time.deltaTime * 3);
        imgFillmana.fillAmount = Mathf.Lerp(imgFillmana.fillAmount, mana / maxMana, Time.deltaTime * 3);
        HealingMana();
    }
    public void OnInit(float maxhp, float maxmana)
    {
        this.maxHp = maxhp;
        this.maxMana = maxmana;
        hp = maxhp;
        mana = maxmana;
        imgFillhp.fillAmount = 1;
        imgFillmana.fillAmount = 1;
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;
    }
    public void SetNewMaxHp(float maxhp)
    {
        this.maxHp = maxhp;
    }
    public void SetNewMana(float mana)
    {
        this.mana = mana;
    }

    private void HealingMana()
    {
        if (mana < maxMana)
        {
            mana += 5f * Time.deltaTime;
            if (mana > maxMana)
            {
                mana = maxMana;
            }
            SetNewMana(mana);
        }
    }

    public void OnHp(float dame)
    {
        hp -= dame;
    }
    public void OnMana(float manax)
    {
        mana -= manax;
    }
    public void SetNewDame(float dame1, float dame2, float dame3, float dame4)
    {
        Damage1 = dame1;
        Damage2 = dame2;
        Damage3 = dame3;
        Damage4 = dame4;
    }
}
