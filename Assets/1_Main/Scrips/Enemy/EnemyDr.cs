using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDr : Bot
{
    public void Start()
    {
        GameObject img = GameObject.FindGameObjectWithTag("ImgEnemy");
        imgEnemy = img.GetComponent<Image>();
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
        imgEnemy.sprite = dataEneMy.ImgEnemy;
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

    IEnumerator SpamSkill()
    {
        yield return new WaitForSeconds(3);
        while (isAttack)
        {
            if (!isCheckSkill)
            {
                int rd = Random.Range(0, 3);
                switch (rd)
                {
                    case 0:
                        isCheckSkill = true;
                        AnimSkill[0].SetActive(true);
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[0], false);
                        yield return new WaitForSeconds(1f);
                        skill1 = Instantiate(Listskill[0], attack.position, attack.rotation).GetComponent<SkillBot>();
                        AudioSkill();
                        AnimSkill[0].SetActive(false);
                        skill1.SetDame1(dame1);
                        skill1.OnInit();
                        yield return new WaitForSeconds(0.5f);
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
                        yield return new WaitForSeconds(3);
                        break;
                    case 1:
                        isCheckSkill = true;
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[1], false);
                        yield return new WaitForSeconds(0.6f);
                        skill2 = Instantiate(Listskill[1], attack.position, attack.rotation).GetComponent<SkillBot2>();
                        AudioSkill();
                        skill2.SetDame2(dame2);
                        skill2.OnInit();
                        yield return new WaitForSeconds(0.5f);
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
                        yield return new WaitForSeconds(3);
                        break;
                    case 2:
                        isCheckSkill = true;
                        AnimSkill[0].SetActive(true);
                        AnimSkill[1].SetActive(true);
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[4], false);
                        yield return new WaitForSeconds(0.5f);
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[2], false);
                        yield return new WaitForSeconds(0.5f);
                        AnimSkill[0].SetActive(false);
                        AnimSkill[1].SetActive(false);
                        skill3 = Instantiate(Listskill[2], attack.position, attack.rotation).GetComponent<SkillBot3>();
                        AudioSkill();
                        skill3.SetDame3(dame3);
                        skill3.OnInit();
                        yield return new WaitForSeconds(0.3f);
                        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[3], false);
                        yield return new WaitForSeconds(3);
                        break;
                }
            }
        }
    }
    public void LevelMap()
    {
        int level = PlayerPrefs.GetInt("levelMap");
        if (level > 1)
        {
            float hpNew = maxhp * (level * 2);
            hp = hpNew;
            healbar.OnInit(hpNew);
            float dame1New = dame1 + (level * (dame1 * 0.5f));
            float dame2New = dame2 + (level * (dame2 * 0.5f));
            float dame3New = dame3 + (level * (dame3 * 0.5f));
            dame2 = dame2New;
            dame3 = dame3New;
            SetDame(dame1New, dame2New, dame3New);
        }
    }
}
