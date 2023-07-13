using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    [SerializeField] protected Healing healbar;


    public float hp;
    private float maxhp;
    public float mana;
    private float maxmana;
    public bool isDead => hp <= 0f;
    private void Start()
    {
        maxhp = 100f;
        maxmana = 100f;
        onInit();
    }
    public void Update()
    {
        healingMana();
    }

    public void onInit()
    {
        hp = 100f;
        mana = 100f;
        healbar.OnInit(maxhp, maxmana);
    }

    public void onHit(float dame)
    {
        if (!isDead)
        {
            hp -= dame;
            if (isDead)
            {
                hp = 0f;
            }
            healbar.SetNewHp(hp);
        }
    }
    public void onSkill(float manax)
    {
        mana -= manax;
        healbar.SetNewMana(mana);
    }
    public void healingMana()
    {
        if (mana < maxmana)
        {
            mana += 30f * Time.deltaTime;
            if (mana > maxmana)
            {
                mana = maxmana;
            }
            healbar.SetNewMana(mana);
        }
    }
}
