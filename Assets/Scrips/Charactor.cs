using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    [SerializeField] protected Healing healbar;
    public GameObject hitVFXDead;

    public string level;
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
    public void FixedUpdate()
    {
        healingMana();
        OnDestroy();
    }

    public void onInit()
    {
        hp = maxhp;
        mana = maxmana;
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
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }

    public void healingMana()
    {
        if (mana < maxmana)
        {
            mana += 10f * Time.deltaTime;
            if (mana > maxmana)
            {
                mana = maxmana;
            }
            healbar.SetNewMana(mana);
        }
    }
}
