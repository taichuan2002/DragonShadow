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
    public string sceneName = "Menu";
    public DataEneMy dataEneMy;

    private float speed = 4f;
    private int random;
    SkeletonAnimation skeletonAnimation;

    public void Start()
    {
        maxhp = dataEneMy.maxHp;
        hp = maxhp;
        dame1 = dataEneMy.Dame1;
        dame2 = dataEneMy.Dame2;
        dame3 = dataEneMy.Dame3;
        dame4 = dataEneMy.Dame4;
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
            random = Random.Range(0, 3);
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
        if (hp == 0)
        {
            gameOver.gameObject.SetActive(true);
            //SceneManager.LoadScene(sceneName);
        }

    }

    IEnumerator DelayIdle()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
    }
    public void nextMap()
    {
        Debug.Log(1123);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator spamSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            skeletonAnimation.AnimationState.SetAnimation(1, listEnim[random], false);
            yield return new WaitForSeconds(1);
            Instantiate(Listskill[random], attack.position, attack.rotation);
            StartCoroutine(DelayIdle());
        }
    }
}
