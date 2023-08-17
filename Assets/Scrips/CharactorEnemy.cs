using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorEnemy : MonoBehaviour
{
    [SerializeField] protected HealingEnemy healbar;
    [SerializeField] DataEneMy Enemy;
    public GameObject hitVFXDead;

    public float hp;
    public float maxhp;
    public float dame1;
    public float dame2;
    public float dame3;
    public float dame4;
    public bool isDead => hp <= 0f;

    private void Start()
    {
        OnInit();
    }
    public void FixedUpdate()
    {
        OnDestroy();
    }



    public void OnInit()
    {
        maxhp = Enemy.maxHp;
        hp = maxhp;
        dame1 = Enemy.Dame1;
        dame2 = Enemy.Dame2;
        dame3 = Enemy.Dame3;
        healbar.OnInit(maxhp);
    }


    public void OnHit(float dame)
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
    public void SetDame(float Dame1, float Dame2, float Dame3)
    {
        dame1 = Dame1;
        dame2 = Dame2;
        dame3 = Dame3;
        healbar.SetNewDame(dame1, dame2, dame3);
    }



    public void OnDestroy()
    {
        if (hp == 0)
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



}
