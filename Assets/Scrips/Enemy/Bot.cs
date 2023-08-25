using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : CharactorEnemy
{
    [SerializeField] private Transform attack;
    public string sceneName = "Menu";
    public static DataEneMy dataEneMy;
    [SerializeField] DataEneMy[] data;

    [SerializeField] private Vector2[] listPoint;
    [SerializeField] private GameObject[] Listskill;
    [SerializeField] private AnimationReferenceAsset[] listEnim;
    [SerializeField] private Vector2[] pointStart;
    [SerializeField] SkillBot skill1;
    [SerializeField] SkillBot2 skill2;
    [SerializeField] SkillBot3 skill3;
    private int random, randomPoint, randomSkill, center;
    SkeletonAnimation skeletonAnimation;

    bool isCheck = false;
    bool isCheckSkill = false;
    bool isAttack = true;
    public void Start()
    {
        center = PlayerPrefs.GetInt("IdEnemy");
        dataEneMy = data[center];
        maxhp = dataEneMy.maxHp;
        hp = maxhp;
        dame1 = dataEneMy.Dame1;
        dame2 = dataEneMy.Dame2;
        dame3 = dataEneMy.Dame3;
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        StartCoroutine(RunPoint());
        StartCoroutine(SpamSkill());
    }
    public void Update()
    {
        if (PlayerController.playerData)
        {
            if (PlayerController.playerData.isDead == true)
            {
                isAttack = false;
            }
        }
        GameObject heal = GameObject.FindGameObjectWithTag("HealingEnemy");
        if (!isCheck)
        {
            if (heal != null)
            {
                healbar = heal.GetComponent<HealingEnemy>();
                Debug.Log("healbar Enemy" + healbar);
                LevelMap();
                isCheck = true;
            }
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
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
        while (isAttack)
        {
            randomPoint = Random.Range(0, 4);
            isCheckSkill = false;
            Vector2 target = listPoint[randomPoint];
            t = 0;
            while (Vector2.Distance(transform.position, target) > 0.001f)
            {
                t += Time.deltaTime;
                transform.position = Vector2.Lerp(transform.position, target, t / 10);
                yield return null;
            }
        }
    }


    IEnumerator DelayIdle()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
    }

    IEnumerator SpamSkill()
    {
        while (isAttack)
        {
            yield return new WaitForSeconds(2f);
            skeletonAnimation.AnimationState.SetAnimation(1, listEnim[random], false);
            yield return new WaitForSeconds(1);
            if (!isCheckSkill)
            {
                int rd = Random.Range(0, 3);
                switch (rd)
                {
                    case 0:
                        skill1 = Instantiate(Listskill[0], attack.position, attack.rotation).GetComponent<SkillBot>();
                        skill1.SetDame1(dame1);
                        skill1.OnInit();
                        isCheckSkill = true;
                        break;
                    case 1:
                        skill2 = Instantiate(Listskill[1], attack.position, attack.rotation).GetComponent<SkillBot2>();
                        skill2.SetDame2(dame2);
                        skill2.OnInit();
                        isCheckSkill = true;
                        break;
                    case 2:
                        skill3 = Instantiate(Listskill[2], attack.position, attack.rotation).GetComponent<SkillBot3>();
                        skill3.SetDame3(dame3);
                        skill3.OnInit();
                        isCheckSkill = true;
                        break;
                }
            }


            StartCoroutine(DelayIdle());
        }
    }
    public void LevelMap()
    {
        int level = PlayerPrefs.GetInt("levelMap");
        float hpNew = maxhp + ((dataEneMy.arrPowerEnemy[level] * 0.005f) * (0.1f * level));
        float dame1New = dame1 + ((dataEneMy.arrPowerEnemy[level] * 0.001f) * 0.45f);
        float dame2New = dame2 + ((dataEneMy.arrPowerEnemy[level] * 0.001f) * 0.25f);
        float dame3New = dame3 + ((dataEneMy.arrPowerEnemy[level] * 0.001f) * 0.65f);
        dame1 = dame1New;
        dame2 = dame2New;
        dame3 = dame3New;
        SetDame(dame1New, dame2New, dame3New);
        hp = hpNew;
        healbar.OnInit(hpNew);
    }


}
