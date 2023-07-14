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

    [SerializeField] private AnimationReferenceAsset[] enumSkill;
    SkeletonAnimation skeletonAnimation;



    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        StartCoroutine(RunPoint());
        StartCoroutine(spamSkill());
    }
    private void FixedUpdate()
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

    IEnumerator spamSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            skeletonAnimation.AnimationState.SetAnimation(1, enumSkill[random], false);
            Instantiate(Listskill[random], attack.position, attack.rotation);
        }
    }
}
