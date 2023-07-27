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
    public string name;
    public string level;
    public string currentLevel;
    public int prime;
    public float maxHp;
    public float maxMana;
    public float Damage1;
    public bool active = false;
}
