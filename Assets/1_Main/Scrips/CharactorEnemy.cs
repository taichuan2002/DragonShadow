using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorEnemy : MonoBehaviour
{
    [SerializeField] protected HealingEnemy healbar;
    [SerializeField] DataEneMy Enemy;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] audioCollider;
    public GameObject hitVFXDead;
    public bool isCheckAudio = false;

    public float hp;
    public float maxhp;
    public float dame1;
    public float dame2;
    public float dame3;
    public float dame4;
    public bool isDead => hp <= 0f;

    private int a;
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
            AudioCollider();
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

    public void AudioCollider()
    {
        a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audio.Stop();
            audio.PlayOneShot(audioCollider[0]);
        }
    }
    public void AudioSkill()
    {
        a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audio.Stop();
            audio.PlayOneShot(audioCollider[1]);
        }
    }

}
