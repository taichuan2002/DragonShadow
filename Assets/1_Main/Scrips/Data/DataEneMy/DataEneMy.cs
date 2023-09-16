using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataEnemy", menuName = "DataEnemy/EnemyMovement")]
public class DataEneMy : ScriptableObject
{
    public SkeletonAnimation bot;
    public Sprite ImgEnemy;
    public string botName;
    public float maxHp;
    public float Dame1;
    public float Dame2;
    public float Dame3;
    public bool isDead;
    public int[] arrPowerEnemy;

}
