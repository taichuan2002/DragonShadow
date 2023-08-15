using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataEnemy", menuName = "DataEnemy/EnemyMovement")]
public class DataEneMy : ScriptableObject
{
    public SkeletonAnimation bot;
    public string botName;
    public int level;
    public float maxHp;
    public float Dame1;
    public float Dame2;
    public float Dame3;
    public float Dame4;
    public bool isDead;

}
