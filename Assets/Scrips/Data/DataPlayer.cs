using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataPlayer", menuName = "DataPlayer/PlayerMovement")]

public class DataPlayer : MonoBehaviour
{
    public SkeletonAnimation player;
    public Sprite[] listSprite;
    public Image imgPlayer;
    public string name;
    public string level;
    public string currentLevel;
    public int prime;
    public float maxHp;
    public float maxMana;
    public float DamageAttack1;
    public float DamageAttack2;
    public float DamageAttack3;
    public float DamageAttack4;
    public bool active = false;
}

public class Title
{
    public int level;
    public float price;
    public float power;
}
