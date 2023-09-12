using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Vector2[] point;
    [SerializeField] GameObject Skill2Prefab;
    [SerializeField] AnimationCurve curve;
    [SerializeField] Vector2 lerpOffset;

    public float lerpTime = 3;
    float _timer = 0;
    void Start()
    {

    }

    void Update()
    {
        /*_timer += Time.deltaTime;

        if (_timer > lerpTime)
        {
            _timer = lerpTime;
        }

        float lerpRatio = _timer / lerpTime;

        Vector2 positionOffset = curve.Evaluate(lerpRatio) * lerpOffset;

        Skill2Prefab.transform.position = Vector2.Lerp(point[0], point[1], 2 * lerpRatio) + positionOffset;*/
    }

    public void Test()
    {
        Instantiate(Skill2Prefab);
    }
}
