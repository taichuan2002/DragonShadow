using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayGame : MonoBehaviour
{
    public Image Player;
    public Image[] Enemy;
    public Sprite[] sprite;
    int level;
    void Start()
    {
        Player.transform.DOLocalMove(new Vector2(0, 60), 2).SetLoops(-1, LoopType.Yoyo);
        //Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
        CheckLevel();
    }

    public void CheckLevel()
    {
        level = PlayerPrefs.GetInt("levelMap");
        switch (level)
        {
            case 0:
                Enemy[4].sprite = sprite[0];
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 1:
                Enemy[4].sprite = sprite[1];
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 2:
                Enemy[4].sprite = sprite[2];
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 3:
                Enemy[4].sprite = sprite[3];
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 4:
                Enemy[0].sprite = sprite[0];
                Enemy[2].sprite = sprite[1];
                Enemy[4].enabled = false;
                Enemy[1].enabled = false;
                Enemy[3].enabled = false;
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 5:
                Enemy[0].sprite = sprite[2];
                Enemy[2].sprite = sprite[3];
                Enemy[4].enabled = false;
                Enemy[3].enabled = false;
                Enemy[1].enabled = false;
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 6:
                Enemy[4].sprite = sprite[0];
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 7:
                Enemy[0].sprite = sprite[0];
                Enemy[1].sprite = sprite[1];
                Enemy[2].sprite = sprite[2];
                Enemy[4].enabled = false;
                Enemy[3].enabled = false;
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[1].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 8:
                Enemy[0].sprite = sprite[2];
                Enemy[1].sprite = sprite[0];
                Enemy[2].sprite = sprite[3];
                Enemy[4].enabled = false;
                Enemy[3].enabled = false;
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[1].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 9:
                Enemy[0].sprite = sprite[1];
                Enemy[1].sprite = sprite[0];
                Enemy[2].sprite = sprite[3];
                Enemy[4].enabled = false;
                Enemy[3].enabled = false;
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[1].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 10:
                Enemy[4].sprite = sprite[3];
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 11:
                Enemy[0].sprite = sprite[0];
                Enemy[2].sprite = sprite[1];
                Enemy[1].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].enabled = false;
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 12:
                Enemy[1].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].enabled = false;
                Enemy[0].sprite = sprite[1];
                Enemy[2].sprite = sprite[2];
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 13:
                Enemy[3].enabled = false;
                Enemy[1].enabled = false;
                Enemy[4].enabled = false;
                Enemy[0].sprite = sprite[2];
                Enemy[2].sprite = sprite[3];
                Enemy[0].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                Enemy[2].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;
            case 14:
                Enemy[0].enabled = false;
                Enemy[1].enabled = false;
                Enemy[2].enabled = false;
                Enemy[3].enabled = false;
                Enemy[4].sprite = sprite[3];
                Enemy[4].transform.DOLocalMove(new Vector2(0, -60), 2).SetLoops(-1, LoopType.Yoyo);
                break;

        }
    }
}
