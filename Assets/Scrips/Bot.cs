using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : CharactorEnemy
{
    [SerializeField] private Vector2[] listPoint;
    [SerializeField] private GameObject[] Listskill;
    [SerializeField] private Transform attack;
    [SerializeField] private AnimationReferenceAsset[] listEnim;
    [SerializeField] private Transform gameOver;
    [SerializeField] private Vector2[] pointStart;
    [SerializeField] DataEneMy Enemy;
    public string sceneName = "Menu";
    public static DataEneMy dataEneMy;

    private int random, randomSkill;
    SkeletonAnimation skeletonAnimation;

    public void Start()
    {
        maxhp = Enemy.maxHp;
        hp = maxhp;
        dame1 = Enemy.Dame1;
        dame2 = Enemy.Dame2;
        dame3 = Enemy.Dame3;
        dame4 = Enemy.Dame4;
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        StartCoroutine(RunPoint());
        StartCoroutine(spamSkill());
    }
    public void Update()
    {
        IsCheckDead();
    }
    IEnumerator RunPoint()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            random = Random.Range(0, 2);
            Vector2 target = pointStart[random];
            transform.position = Vector2.Lerp(target, listPoint[1], t / 10);
            yield return null;
        }
        while (true)
        {
            random = Random.Range(0, 4);
            Vector2 target = listPoint[random];
            t = 0;
            while (Vector2.Distance(transform.position, target) > 0.001f)
            {
                t += Time.deltaTime;
                transform.position = Vector2.Lerp(transform.position, target, t / 10);
                yield return null;
            }
        }
    }

    public void IsCheckDead()
    {
        dataEneMy = Enemy;
        if (hp == 0)
        {
            Enemy.isDead = true;
            int Coin = PlayerPrefs.GetInt("Coin");
            Coin += 60;
            PlayerPrefs.SetInt("Coin", Coin);
            PlayerPrefs.Save();
            //StartCoroutine(nextScene());
        }

    }

    IEnumerator DelayIdle()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    IEnumerator spamSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            skeletonAnimation.AnimationState.SetAnimation(1, listEnim[randomSkill], false);
            yield return new WaitForSeconds(1);
            Instantiate(Listskill[random], attack.position, attack.rotation);
            StartCoroutine(DelayIdle());
        }
    }
}
