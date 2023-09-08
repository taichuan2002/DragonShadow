using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Bot : CharactorEnemy
{
    public Transform attack;
    public string sceneName = "Menu";
    public static DataEneMy dataEneMy;
    public DataEneMy[] data;
    public Image imgEnemy;
    public Vector2[] listPoint;
    public GameObject[] Listskill;
    public AnimationReferenceAsset[] listEnim;
    public Vector2[] pointStart;
    public SkillBot skill1;
    public SkillBot2 skill2;
    public SkillBot3 skill3;
    public int random, randomPoint, randomSkill, center;
    public SkeletonAnimation skeletonAnimation;

    public bool isCheck = false;
    public bool isCheckSkill = false;
    public bool isAttack = true;
    public bool isPoint = false;
}
