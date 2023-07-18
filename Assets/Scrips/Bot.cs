using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Charactor
{
    [SerializeField] private Vector2[] listPoint;
    [SerializeField] private GameObject[] Listskill;
    [SerializeField] private Transform attack;
    private float speed = 4f;
    private int random;

    [SerializeField] private AnimationReferenceAsset[] listEnim;
    SkeletonAnimation skeletonAnimation;



    public void Start()
    {
        maxhp = 100;
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[4], false);
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        StartCoroutine(RunPoint());
        StartCoroutine(spamSkill());
    }
    public void Update()
    {
    }
    IEnumerator RunPoint()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(listPoint[2], listPoint[1], t / 15);
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
                transform.position = Vector2.Lerp(transform.position, target, t / 15);
                yield return null;
            }
        }
    }
    IEnumerator DelayIdle()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, listEnim[4], false);
    }

    IEnumerator spamSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            skeletonAnimation.AnimationState.SetAnimation(1, listEnim[random], false);
            Instantiate(Listskill[random], attack.position, attack.rotation);
            StartCoroutine(DelayIdle());
        }
    }
}
