using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eSkins
{
    eSkin1, eSkin2, eSkin3, eSkin4, eSkin5, eSkin6,
    eSkin7, eSkin8, eSkin9, eSkin10, eSkin11, eSkin12,
    eSkin13, eSkin14, eSkin15, eSkin16, eSkin17, eSkin18,
    eSkin19, eSkin20
}

[CreateAssetMenu(fileName = "DataPlayer", menuName = "DataPlayer/PlayerMovement")]

public class DataPlayer : ScriptableObject
{
    public string level;
    public SkeletonAnimation player;
    public PropertiesPlayer playerProperties;
}
