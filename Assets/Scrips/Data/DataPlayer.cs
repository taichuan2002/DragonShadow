using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataPlayer", menuName = "DataPlayer/PlayerMovement")]
public class DataPlayer : ScriptableObject
{
    public int level;
    public SkeletonAnimation player;
    public PropertiesPlayer playerProperties;
    public Skin skin;

    public void Initialize()
    {
        if (player != null)
        {
            SkeletonData skeletonData = player.Skeleton.Data;
            if (skeletonData != null && level == 1 && skeletonData.Skins.Count >= 1)
            {
                skin = skeletonData.Skins.Items[1];
            }
        }
    }
}
