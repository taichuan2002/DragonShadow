using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    [SerializeField] protected Healing healbar;


    public float hp;
    public float maxhp;
    public float mana;
    public float maxmana;
    public bool isDead => hp <= 0f;
    private void Start()
    {
        maxhp = 100;
        maxmana = 100;
        onInit();
    }
    public void Update()
    {
        healingMana();
        Debug.Log(mana);
        OnDestroy();
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

    public void OnDestroy()
    {
        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }

    public void healingMana()
    {
        if (mana < 100)
        {
            mana += 5f * Time.deltaTime;
            if (mana > 100)
            {
                mana = 100;
            }
            healbar.SetNewMana(mana);
        }
    }
}
