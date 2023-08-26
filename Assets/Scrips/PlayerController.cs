using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : Charactor
{
    [SerializeField] Transform attack;
    [SerializeField] GameObject pointAttack;
    [SerializeField] Rigidbody2D rb;
    public static DataPlayer playerData;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI _txtPointCoin;
    [SerializeField] TextMeshProUGUI _txtLevelSSJ;
    [SerializeField] float speed;
    [SerializeField] Skin sk;
    [SerializeField] SkillKame skillKame;
    [SerializeField] Skill2 skill2;
    [SerializeField] testSkill2 testskill2;
    [SerializeField] Skill3 skill3;
    [SerializeField] SkillKame skill4;
    [SerializeField] Skill5 skill5;
    [SerializeField] string sceneName = "Menu";
    [SerializeField] SkeletonAnimation[] skeletonAnimation;
    [SerializeField] DataPlayer[] data;
    [SerializeField] AnimationReferenceAsset[] ListAnim;
    [SerializeField] GameObject[] Listskill;
    [SerializeField] GameObject[] hitVFX;
    [SerializeField] GameObject VfxArmor;
    [SerializeField] Vector3[] v3;
    [SerializeField] Button[] _btn;

    public string targetBtnTag = "btnTags";
    public GameObject skill2Prf;
    public Transform Attack;
    public Vector3[] Points;

    private Vector2 mousePos;
    private float minX = -10f;
    private float maxX = 2.2f;
    private float minY = -4.5f;
    private float maxY = 4.5f;
    private bool isAttack = true;
    private bool isSkillRunning = false;
    private bool isCheck = false;
    private int Coin, levelprefs, levelValue;
    private bool isImmortal = false;
    private float invincibleTime = 5f;
    private float invincibleTimer = 0f;
    int center, point, levelMap;
    GameObject hVFX, vfxArmor;
    private float t = 0f;
    private int currentWaypointIndex = 0;
    private int randomPointUp, randomPointDown;
    private Coroutine effectCoroutine;
    bool isCheckSkill2 = true;
    bool vfx = true;
    bool isArmor = false;
    bool checkArmor = false;
    private void Start()
    {

        GameObject PointCoin = GameObject.FindGameObjectWithTag("PointCoin");
        GameObject LevelSSj = GameObject.FindGameObjectWithTag("LevelSSJ");
        _txtLevelSSJ = LevelSSj.GetComponent<TextMeshProUGUI>();
        _txtPointCoin = PointCoin.GetComponent<TextMeshProUGUI>();
        Button[] btns = GameObject.FindObjectsOfType<Button>();
        if (isAttack)
        {
            foreach (Button btn in btns)
            {
                if (btn.CompareTag(targetBtnTag))
                {
                    btn.onClick.AddListener(() => ButtonClicked(btn.gameObject));
                }
            }
        }

        center = PlayerPrefs.GetInt("idPlayer");
        OnInitCoin();
        OnInit();

    }

    private void Update()
    {

        string targetObjectName = "Canvas_Heal";
        GameObject heal = GameObject.Find(targetObjectName);
        if (!isCheck)
        {
            if (heal != null)
            {
                healbar = heal.GetComponent<Healing>();
                Debug.Log("healbar Player" + healbar);
                if (healbar != null)
                {
                    LevelUpSSJ();
                    isCheck = true;
                }
            }
        }
        if (Bot.dataEneMy != null)
        {
            if (Bot.dataEneMy.isDead == true)
            {
                isAttack = false;
            }
        }

        playerData = data[center];
        if (isAttack)
        {
            Control();
        }
        if (hp == 0)
        {
            PlayerPrefs.SetInt("isDead", 1);
            playerData.isDead = true;
            Destroy(gameObject);
        }
        if (isImmortal)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
            {
                isImmortal = false;
            }
        }
    }

    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        levelprefs = PlayerPrefs.GetInt("LevelSSJ0");
    }

    public void ButtonClicked(GameObject btn)
    {
        Button btnBean = btn.GetComponent<Button>();
        if (btn.name == "Skill1")
        {
            Skill1();
        }
        if (btn.name == "Skill2")
        {
            Skill2();
        }
        if (btn.name == "Skill3")
        {
            Skill3();
        }
        if (btn.name == "Skill4")
        {
            Skill4();
        }
        if (btn.name == "Skill5")
        {
            Skill5();
        }
        if (btn.name == "btn_Bean")
        {
            if (hp != maxhp || mana != maxmana)
            {
                if (Coin >= 500)
                {
                    Coin -= 500;
                    OnInitCoin();
                    hp = maxhp;
                    mana = maxmana;
                    healbar.SetNewHp(hp);
                    healbar.SetNewMana(mana);
                    btnBean.interactable = true;
                }
                else
                {
                    btnBean.interactable = false;
                }
            }
        }
        if (btn.name == "btn_Strengthen")
        {
            if (isAttack)
            {
                StartCoroutine(DelayTransform());
                isAttack = false;
            }
            IEnumerator DelayTransform()
            {
                levelValue = int.Parse(level);
                yield return new WaitForSeconds(0.4f);
                Button btnSSJ = btn.GetComponent<Button>();
                if (levelValue < levelprefs)
                {
                    btnSSJ.interactable = true;
                    LevelUpSSJ();
                    hp = maxhp;
                    mana = maxmana;
                    healbar.SetNewHp(maxhp);
                    healbar.SetNewMaxHp(maxhp);
                    healbar.SetNewMana(mana);
                    skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[6], false);
                    levelValue++;
                    _txtLevelSSJ.text = "SSJ ." + levelValue;
                    level = levelValue.ToString();
                    skeletonAnimation[center].skeleton.SetSkin(level);
                    StartCoroutine(DelayIdle());
                }
                if (levelValue >= levelprefs)
                {
                    btnSSJ.interactable = false;
                    isAttack = true;
                }
            }
        }

    }



    public void Control()
    {

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (mousePos.x >= minX && mousePos.x <= maxX && mousePos.y >= minY && mousePos.y <= maxY)
        {
            if (!IsMouseOverButton())
            {
                float clampedX = Mathf.Clamp(mousePos.x, minX, maxX);
                float clampedY = Mathf.Clamp(mousePos.y, minY, maxY);
                Vector2 clampedMousePos = new Vector2(clampedX, clampedY);
                transform.position = Vector2.Lerp(transform.position, clampedMousePos, speed * Time.deltaTime);
            }
        }
    }

    public void OnInit()
    {
        point = 0;
        playerData = data[center];
        Application.targetFrameRate = 90;
        maxhp = playerData.maxHp;
        maxmana = playerData.maxMana;
        hp = playerData.maxHp;
        mana = playerData.maxMana;
        Damage1 = playerData.DamageAttack1;
        Damage2 = playerData.DamageAttack2;
        Damage3 = playerData.DamageAttack3;
        Damage4 = playerData.DamageAttack4;
        rb = GetComponent<Rigidbody2D>();
        skeletonAnimation[center] = GetComponent<SkeletonAnimation>();
        PlayerController.playerData.Immortal = false;
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        mousePos = transform.position;
    }

    public void OnInitCoin()
    {
        PlayerPrefs.SetInt("tongCoin", point);
        UIManager.Instance.SetCoin(Coin);
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.Save();
        _txtPointCoin.text = Coin.ToString();
    }

    private bool IsMouseOverButton()
    {
        return EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject != null;
    }
    public void Skill1()
    {
        if (isAttack)
        {
            if (mana >= 40 && !isSkillRunning)
            {
                isAttack = false;
                OnSkill(40);
                StartCoroutine(DelaySkill1());
            }
            else
            {
                Debug.Log("Yếu Sinh Lý");
            }
        }
    }
    public void Skill2()
    {
        if (isAttack)
        {

            if (mana >= 25)
            {
                isAttack = true;
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[2], false);
                skill2 = GetComponent<Skill2>();
                testskill2 = Instantiate(Listskill[1], attack.position, attack.rotation).GetComponent<testSkill2>();
                //skill2.SetDame(Damage2);
                OnSkill(25);
                StartCoroutine(DelayIdle());
            }
            else
            {
                Debug.Log("Yếu Sinh Lý");
            }
        }

    }
    public void Skill3()
    {

        if (mana >= 15)
        {
            isAttack = false;
            skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[3], false);
            skill3 = Instantiate(Listskill[2], attack.position, attack.rotation).GetComponent<Skill3>();
            skill3.SetDame(Damage3);
            skill3.OnInit();
            OnSkill(15);
            StartCoroutine(DelayIdle());
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }
    }
    public void Skill4()
    {
        if (isAttack)
        {
            if (mana >= 40)
            {
                isAttack = false;
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[8], false);
                StartCoroutine(delaySkill4());
            }
            else
            {
                Debug.Log("Yếu Sinh Lý");
            }
        }
    }
    public void Skill5()
    {
        if (isAttack)
        {
            if (mana >= 40)
            {
                isAttack = false;
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[5], false);
                skill5 = Instantiate(Listskill[4], attack.position, attack.rotation).GetComponent<Skill5>();
                skill5.SetDame(Damage4);
                skill5.OnInit();
                OnSkill(40);
                StartCoroutine(DelayIdle());
            }
            else
            {
                Debug.Log("Yếu Sinh Lý");
            }
        }
    }

    bool isCheckArmor = false;

    IEnumerator Immortal()
    {
        isArmor = true;
        checkArmor = true;
        VfxArmor.SetActive(true);
        PlayerController.playerData.Immortal = true;
        yield return new WaitForSeconds(9f);
        if (checkArmor)
        {
            PlayerController.playerData.Immortal = false;
            VfxArmor.SetActive(false);
            isArmor = false;
        }


    }
    IEnumerator Immortal2()
    {
        isArmor = false;
        checkArmor = false;
        VfxArmor.SetActive(true);
        PlayerController.playerData.Immortal = true;
        yield return new WaitForSeconds(9f);
        if (!checkArmor)
        {
            PlayerController.playerData.Immortal = false;
            VfxArmor.SetActive(false);
            isArmor = false;
        }

    }
    IEnumerator delaySkill4()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[4], false);
        yield return new WaitForSeconds(0.5f);
        skill4 = Instantiate(Listskill[3], attack.position, attack.rotation).GetComponent<SkillKame>();
        skill4.SetDame(Damage4);
        skill4.OnInit();
        OnSkill(40);
        StartCoroutine(DelayIdle());
    }
    IEnumerator DelaySkill1()
    {
        isSkillRunning = true;
        rb.velocity = Vector2.zero;
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[7], false);
        GameObject hVFX = Instantiate(hitVFX[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[1], false);
        yield return new WaitForSeconds(0.5f);
        Destroy(hVFX);
        skillKame = Instantiate(Listskill[0], attack.position, attack.rotation).GetComponent<SkillKame>();
        skillKame.SetDame(Damage1);
        skillKame.OnInit();
        StartCoroutine(DelayIdle());
        isSkillRunning = false;
    }

    IEnumerator CollisionItem()
    {
        if (vfx && !hVFX)
        {
            hVFX = Instantiate(hitVFX[2], transform);
            vfx = false;
        }
        yield return new WaitForSeconds(2.5f);
        Destroy(hVFX);
    }
    IEnumerator DelayIdle()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[0], false);
        isAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BeanBlue"))
        {
            mana = maxmana;
            vfx = true;
            healbar.SetNewMana(mana);
            StartCoroutine(CollisionItem());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BeanRed"))
        {
            hp = maxhp;
            vfx = true;
            healbar.SetNewHp(hp);
            StartCoroutine(CollisionItem());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BeanGreen"))
        {
            mana = maxmana;
            hp = maxhp;
            vfx = true;
            healbar.SetNewHp(hp);
            healbar.SetNewMana(mana);
            StartCoroutine(CollisionItem());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Armor"))
        {
            vfx = true;
            if (!isArmor)
            {
                StartCoroutine(Immortal());
                StopCoroutine(Immortal2());
                checkArmor = true;
            }
            else
            {
                StopCoroutine(Immortal());
                StartCoroutine(Immortal2());
                checkArmor = false;

            }
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            Coin += 99999;
            point += 99999;
            OnInitCoin();
            Destroy(collision.gameObject);
        }
    }
    public void LevelUpSSJ()
    {
        float hpNew = maxhp + ((playerData.arrPower[levelValue] * 0.001f) * (0.1f * levelValue));
        float dame1New = Damage1 + (((playerData.arrPower[levelValue] * 0.001f) * 0.35f));
        float dame2New = Damage2 + (((playerData.arrPower[levelValue] * 0.001f) * 0.10f));
        float dame3New = Damage3 + (((playerData.arrPower[levelValue] * 0.001f) * 0.55f));
        float dame4New = Damage4 + (((playerData.arrPower[levelValue] * 0.001f) * 0.35f));
        Damage1 = dame1New;
        Damage2 = dame2New;
        Damage3 = dame3New;
        Damage4 = dame4New;
        SetDame(dame1New, dame2New, dame3New, dame4New);
        maxhp = hpNew;
    }
}
