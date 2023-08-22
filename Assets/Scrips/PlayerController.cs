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
    [SerializeField] GameObject Bot;
    public static DataPlayer playerData;
    [SerializeField] GameObject gameDead;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI _txtPointCoin;
    [SerializeField] float speed;
    [SerializeField] Skin sk;
    [SerializeField] SkillKame skillKame;
    [SerializeField] Skill2 skill2;
    [SerializeField] Skill3 skill3;
    [SerializeField] SkillKame skill4;
    [SerializeField] SkillKame skill5;
    [SerializeField] testSkill2 skill2t;
    [SerializeField] string sceneName = "Menu";
    [SerializeField] SkeletonAnimation[] skeletonAnimation;
    [SerializeField] DataPlayer[] data;
    [SerializeField] AnimationReferenceAsset[] ListAnim;
    [SerializeField] GameObject[] Listskill1;
    [SerializeField] GameObject[] hitVFX;
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
    bool isCheckCroutine = false;
    private void Start()
    {

        GameObject PointCoin = GameObject.FindGameObjectWithTag("PointCoin");
        gameDead = GameObject.FindGameObjectWithTag("PanelDeadGame");

        _txtPointCoin = PointCoin.GetComponent<TextMeshProUGUI>();
        Button[] btns = GameObject.FindObjectsOfType<Button>();
        foreach (Button btn in btns)
        {
            if (btn.CompareTag(targetBtnTag))
            {
                btn.onClick.AddListener(() => ButtonClicked(btn.gameObject));
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
        if (vfxArmor != null && transform.position != null)
        {
            vfxArmor.transform.position = transform.position;
        }

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

        playerData = data[center];
        if (isAttack)
        {
            Control();
        }
        if (hp == 0)
        {
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

    public void OnInitSkill2()
    {
        Points[0] = skill2Prf.transform.position;
        Points[1] = new Vector3(skill2Prf.transform.position.x, 5f);
        Points[2] = new Vector3(skill2Prf.transform.position.x, 3.75f);
        Points[3] = new Vector3(skill2Prf.transform.position.x, 2.5f);
        Points[4] = new Vector3(skill2Prf.transform.position.x, 1.25f);
        Points[5] = new Vector3(skill2Prf.transform.position.x, 0f);
        Points[6] = new Vector3(skill2Prf.transform.position.x, -1.25f);
        Points[7] = new Vector3(skill2Prf.transform.position.x, -2.5f);
        Points[8] = new Vector3(skill2Prf.transform.position.x, -3.75f);
        Points[9] = new Vector3(skill2Prf.transform.position.x, -5f);
        Points[10] = new Vector3(skill2Prf.transform.position.x + 15, skill2Prf.transform.position.y);

        randomPointUp = UnityEngine.Random.Range(1, 5);
        randomPointDown = UnityEngine.Random.Range(6, 10);
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
                skill2 = Instantiate(Listskill1[1], attack.position, attack.rotation).GetComponent<Skill2>();
                skill2 = Instantiate(Listskill1[1], attack.position, attack.rotation).GetComponent<Skill2>();
                skill2 = Instantiate(Listskill1[1], attack.position, attack.rotation).GetComponent<Skill2>();
                skill2 = Instantiate(Listskill1[1], attack.position, attack.rotation).GetComponent<Skill2>();
                skill2 = Instantiate(Listskill1[1], attack.position, attack.rotation).GetComponent<Skill2>();
                skill2.SetDame(Damage2);
                skill2.OnInit();
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
        if (isAttack)
        {
            if (mana >= 15)
            {
                isAttack = false;
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[3], false);
                skill3 = Instantiate(Listskill1[2], attack.position, attack.rotation).GetComponent<Skill3>();
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
                skill5 = Instantiate(Listskill1[4], attack.position, attack.rotation).GetComponent<SkillKame>();
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



    IEnumerator Immortal()
    {
        if (!vfxArmor)
        {
            vfxArmor = Instantiate(hitVFX[3], transform.position, transform.rotation);
        }
        /* if (vfxArmor && vfx)
         {
             Destroy(vfxArmor);
             isCheckCroutine = true;
             StopCoroutine(effectCoroutine);
         }*/
        PlayerController.playerData.Immortal = true;
        yield return new WaitForSeconds(9f);
        PlayerController.playerData.Immortal = false;
        Destroy(vfxArmor);
    }
    IEnumerator delaySkill4()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[4], false);
        yield return new WaitForSeconds(0.5f);
        skill4 = Instantiate(Listskill1[3], attack.position, attack.rotation).GetComponent<SkillKame>();
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
        GameObject hVFX2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[1], false);
        yield return new WaitForSeconds(0.5f);
        Destroy(hVFX);
        Destroy(hVFX2);
        skillKame = Instantiate(Listskill1[0], attack.position, attack.rotation).GetComponent<SkillKame>();
        skillKame.SetDame(Damage1);
        skillKame.OnInit();
        StartCoroutine(DelayIdle());
        isSkillRunning = false;
    }

    IEnumerator CollisionItem()
    {
        if (vfx && !hVFX)
        {
            hVFX = Instantiate(hitVFX[2], transform.position, transform.rotation);
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
            effectCoroutine = StartCoroutine(Immortal());
            Destroy(collision.gameObject);
            isCheckCroutine = true;
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
        float hpNew = maxhp + (maxhp * 0.25f);
        float dame1New = Damage1 + (playerData.arrPower[levelValue] * 0.001f);
        float dame2New = Damage2 + (playerData.arrPower[levelValue] * 0.001f);
        float dame3New = Damage3 + (playerData.arrPower[levelValue] * 0.001f);
        float dame4New = Damage4 + (playerData.arrPower[levelValue] * 0.001f);
        Damage1 = dame1New;
        Damage2 = dame2New;
        Damage3 = dame3New;
        Damage4 = dame4New;
        SetDame(dame1New, dame2New, dame3New, dame4New);
        maxhp = hpNew;
    }
    Vector2 BezierPoint(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;

        Vector2 p = uu * a;
        p += 2f * u * t * b;
        p += tt * c;

        return p;
    }
    private Vector3 GetSkillDirectionUp(float t)
    {
        Vector3 point1 = BezierPoint(t, Points[0], Points[randomPointUp], Points[10]);
        Vector3 point2 = BezierPoint(t + 0.1f, Points[0], Points[randomPointUp], Points[10]);
        Vector3 direction = point2 - point1;
        direction.Normalize();
        return direction;
    }
    private Vector3 GetSkillDirectionDown(float t)
    {
        Vector3 point1 = BezierPoint(t, Points[0], Points[randomPointDown], Points[10]);
        Vector3 point2 = BezierPoint(t + 0.1f, Points[0], Points[randomPointDown], Points[10]);
        Vector3 direction = point2 - point1;
        direction.Normalize();
        return direction;
    }

}
