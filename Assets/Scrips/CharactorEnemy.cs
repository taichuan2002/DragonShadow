using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorEnemy : MonoBehaviour
{
    [SerializeField] protected HealingEnemy healbar;
    public GameObject hitVFXDead;

    public string level;
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
        hp = maxhp;
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

    public void OnDestroy()
    {
        if (hp == 0)
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }




}
