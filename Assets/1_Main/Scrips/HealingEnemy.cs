using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingEnemy : MonoBehaviour
{
    [SerializeField] Image imgFillhp;
    [SerializeField] DataEneMy[] dataEneMy;
    public float hp;
    private float maxHp;
    private float Damage1;
    private float Damage2;
    private float Damage3;
    private float Damage4;

    private void Start()
    {
        int idEnemy = PlayerPrefs.GetInt("IdEnemy");
        this.maxHp = dataEneMy[idEnemy].maxHp;
        this.hp = maxHp;
        this.Damage1 = dataEneMy[idEnemy].Dame1;
        this.Damage2 = dataEneMy[idEnemy].Dame2;
        this.Damage3 = dataEneMy[idEnemy].Dame3;

    }

    private void Update()
    {
        imgFillhp.fillAmount = Mathf.Lerp(imgFillhp.fillAmount, hp / maxHp, Time.deltaTime * 3);
    }
    public void OnInit(float maxhp)
    {
        this.maxHp = maxhp;
        hp = maxhp;
        imgFillhp.fillAmount = 1;
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;
    }
    public void SetNewMaxHp(float maxhp)
    {
        this.maxHp = maxhp;
    }

    public void SetNewDame(float dame1, float dame2, float dame3)
    {
        this.Damage1 = dame1;
        this.Damage2 = dame2;
        this.Damage3 = dame3;

    }


    public void onHp(float dame)
    {
        hp -= dame;
    }

}

