using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charactor : MonoBehaviour
{
    [SerializeField] protected Healing healbar;
    [SerializeField] DataPlayer Player;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip audioCollider;
    public GameObject hitVFXDead;
    public string level;
    public float hp;
    public float maxhp;
    public float mana;
    public float maxmana;
    public float Damage1;
    public float Damage2;
    public float Damage3;
    public float Damage4;
    public float Damage5;
    public bool isDead => hp <= 0f;
    private void Start()
    {
        OnInit();
    }
    public void FixedUpdate()
    {
        HealingMana();
        OnDestroy();
    }
    public void OnInit()
    {

        hp = maxhp;
        mana = maxmana;
        Damage1 = Player.DamageAttack1;
        Damage2 = Player.DamageAttack2;
        Damage3 = Player.DamageAttack3;
        Damage4 = Player.DamageAttack4;
        Damage5 = Player.DamageAttack5;
        healbar.OnInit(maxhp, maxmana);
    }

    public void OnHit(float dame)
    {
        if (!isDead)
        {
            int a = PlayerPrefs.GetInt("audioClick");
            if (a == 0)
            {
                audio.Stop();
                audio.PlayOneShot(audioCollider);
            }
            hp -= dame;
            if (isDead)
            {
                hp = 0f;
            }
            healbar.SetNewHp(hp);
        }
    }
    public void OnSkill(float manax)
    {
        mana -= manax;
        healbar.SetNewMana(mana);
    }

    public void OnDestroy()
    {
        if (hp == 0)
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



    public void HealingMana()
    {
        if (mana < maxmana)
        {
            mana += 2f * Time.deltaTime;
            if (mana > maxmana)
            {
                mana = maxmana;
            }
            healbar.SetNewMana(mana);
        }
    }
    public void SetDame(float dame1, float dame2, float dame3, float dame4, float dame5)
    {
        Damage1 = dame1;
        Damage2 = dame2;
        Damage3 = dame3;
        Damage4 = dame4;
        Damage5 = dame5;
        healbar.SetNewDame(Damage1, Damage2, Damage3, Damage4, Damage5);
    }

}
