using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayGame : MonoBehaviour
{
    public Image Player;
    public Image Enemy;
    void Start()
    {
        Player.transform.DOLocalMove(new Vector2(0, 60), 2).SetLoops(-1, LoopType.Yoyo);
        Enemy.transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);

    }

    void Update()
    {

    }
}
