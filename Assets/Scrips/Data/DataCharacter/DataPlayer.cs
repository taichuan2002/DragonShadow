using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataPlayer", menuName = "DataPlayer/PlayerMovement")]

public class DataPlayer : ScriptableObject
{
    public SkeletonAnimation player;
    public Healing healingBar;
    public Sprite Image;
    public string name;
    public string level;
    public string currentLevel;
    public float maxHp;
    public float maxMana;
    public float DamageAttack1;
    public float DamageAttack2;
    public float DamageAttack3;
    public float DamageAttack4;
    public bool isDead = false;
    public bool Immortal = false;
    public Sprite[] listSprite;
    public int[] arrPrice;
    public int[] arrPower;
}
