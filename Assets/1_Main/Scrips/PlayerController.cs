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
    [SerializeField] Image ImgPlayer;
    [SerializeField] TextMeshProUGUI _txtPointCoin;
    [SerializeField] TextMeshProUGUI _txtLevelSSJ;
    [SerializeField] float speed;
    [SerializeField] Skin sk;
    [SerializeField] SkillKame skillKame;
    [SerializeField] testSkill2 testskill2;
    [SerializeField] Skill3 skill3;
    [SerializeField] Skill4 skill4;
    [SerializeField] Skill5 skill5;
    [SerializeField] string sceneName = "Menu";
    [SerializeField] AudioSource audios;
    [SerializeField] SkeletonAnimation targetBot;
    [SerializeField] AudioClip[] audioClick;
    [SerializeField] SkeletonAnimation[] skeletonAnimation;
    [SerializeField] DataPlayer[] data;
    [SerializeField] AnimationReferenceAsset[] ListAnim;
    [SerializeField] GameObject[] Listskill;
    [SerializeField] GameObject[] hitVFX;
    [SerializeField] GameObject VfxArmor;
    [SerializeField] Vector3[] v3;
    [SerializeField] Button[] _btn;
    [SerializeField] GameObject[] _anim;

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
    private int randomPointUp, randomPointDown, bean;
    private Coroutine effectCoroutine;
    bool vfx = true;
    bool isArmor = false;
    bool checkArmor = false;
    bool isSkill = false;
    bool isSSJ = false;
    bool isTime = false;
    bool isMouse = false;
    bool isMouseNull = false;
    bool isMouseBtn = false;
    private bool isTouchPressed = false;
    private bool hasProcessedTouch = false;
    private void Start()
    {
        GameObject PointCoin = GameObject.FindGameObjectWithTag("PointCoin");
        GameObject LevelSSj = GameObject.FindGameObjectWithTag("LevelSSJ");
        GameObject imgPl = GameObject.FindGameObjectWithTag("ImgPlayer");
        testskill2 = GetComponent<testSkill2>();
        _txtLevelSSJ = LevelSSj.GetComponent<TextMeshProUGUI>();
        _txtPointCoin = PointCoin.GetComponent<TextMeshProUGUI>();
        ImgPlayer = imgPl.GetComponent<Image>();
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
        int number = PlayerPrefs.GetInt("idPlayer");
        levelprefs = PlayerPrefs.GetInt("LevelSSJ" + number.ToString());
        center = PlayerPrefs.GetInt("idPlayer");
        PlayerPrefs.SetInt("SSJ", 0);
        PlayerPrefs.Save();
        StartCoroutine(DelayTimeSkill());
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
                if (healbar != null)
                {
                    //LevelUpSSJ();
                    isCheck = true;
                }
            }
        }
        if (isAttack)
        {
            Control();
        }
        if (Bot.dataEneMy != null)
        {
            if (Bot.dataEneMy.isDead == true)
            {
                isAttack = false;
            }
        }

        playerData = data[center];

        if (hp == 0)
        {
            PlayerPrefs.SetInt("isDead", 1);
            PlayerPrefs.Save();
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerData.Immortal = true;
        }
    }

    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        bean = PlayerPrefs.GetInt("Bean", 0);

    }

    public void ButtonClicked(GameObject btn)
    {
        Button btnClick = btn.GetComponent<Button>();

        if (btn.name == "Skill1")
        {
            if (isTime)
            {
                Skill1();
            }
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
            if (isTime)
            {
                Skill4();
            }
        }
        if (btn.name == "Skill5")
        {
            Skill5();
        }
        if (btn.name == "btn_Bean")
        {
            if (hp != maxhp || mana != maxmana)
            {
                if (bean > 0)
                {
                    audios.Stop();
                    AudioItem();
                    bean -= 1;
                    OnInitCoin();
                    hp = maxhp;
                    mana = maxmana;
                    healbar.SetNewHp(hp);
                    healbar.SetNewMana(mana);
                }
                else
                {
                    if (Coin >= 500)
                    {
                        audios.Stop();
                        AudioItem();
                        AudioAddCoin();
                        Coin -= 500;
                        PlayerPrefs.SetInt("EatBean", 1);
                        OnInitCoin();
                        hp = maxhp;
                        mana = maxmana;
                        healbar.SetNewHp(hp);
                        healbar.SetNewMana(mana);
                        btnClick.interactable = true;
                    }
                    else
                    {
                        btnClick.interactable = false;
                    }
                }

            }
        }
        if (btn.name == "btn_Strengthen")
        {
            StartCoroutine(DelayTransform());
            IEnumerator DelayTransform()
            {

                isAttack = true;
                levelValue = int.Parse(level);
                yield return new WaitForSeconds(0.4f);
                Button btnSSJ = btn.GetComponent<Button>();
                if (levelValue < levelprefs)
                {
                    if (!isSSJ)
                    {
                        audios.Stop();
                        AudioSSJ();
                        _anim[0].SetActive(true);
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
                        PlayerPrefs.SetInt("SSJ", levelValue);
                        PlayerPrefs.Save();
                        ImgPlayer.sprite = playerData.listSprite[levelValue];
                        skeletonAnimation[center].skeleton.SetSkin(level);
                        StartCoroutine(DelayIdle());
                        isSSJ = true;
                    }
                }
                if (levelValue >= levelprefs)
                {
                    btnSSJ.interactable = false;
                }
            }

        }

    }

    IEnumerator DelayTimeSkill()
    {
        yield return new WaitForSeconds(2);
        isTime = true;
    }

    public void Control()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    isMouseNull = false;
                    if (hit.collider.CompareTag("mouse"))
                    {
                        isMouse = true;
                        if (isMouse && !isMouseBtn && !isMouseNull)
                        {
                            float clampedX = Mathf.Clamp(ray.origin.x, minX, maxX);
                            float clampedY = Mathf.Clamp(ray.origin.y, minY, maxY);
                            Vector2 clampedMousePos = new Vector2(clampedX, clampedY);
                            transform.position = Vector2.MoveTowards(transform.position, clampedMousePos, speed * Time.deltaTime);
                        }
                    }
                    if (hit.collider.name == "btnStop")
                    {
                        isMouseBtn = true;
                    }
                    else if (hit.collider.name == "btn_Bean")
                    {
                        isMouseBtn = true;
                    }
                    else if (hit.collider.name == "btn_Strengthen")
                    {
                        isMouseBtn = true;
                    }
                    else if (hit.collider.name == "Image")
                    {
                        isMouseBtn = true;
                    }
                    else
                    {
                        isMouseBtn = false;
                    }

                }
                else
                {
                    isMouseNull = true;
                }

            }

        }

    }

    public void OnInit()
    {
        point = 0;
        playerData = data[center];
        maxhp = playerData.maxHp;
        maxmana = playerData.maxMana;
        hp = playerData.maxHp;
        mana = playerData.maxMana;
        Damage1 = playerData.DamageAttack1;
        Damage2 = playerData.DamageAttack2;
        Damage3 = playerData.DamageAttack3;
        Damage4 = playerData.DamageAttack4;
        Damage5 = playerData.DamageAttack5;
        rb = GetComponent<Rigidbody2D>();
        skeletonAnimation[center] = GetComponent<SkeletonAnimation>();
        PlayerController.playerData.Immortal = false;
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        mousePos = transform.position;
        ImgPlayer.sprite = playerData.listSprite[0];

    }

    public void OnInitCoin()
    {
        PlayerPrefs.SetInt("tongCoin", point);
        UIManager.Instance.SetCoin(Coin);
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.SetInt("Bean", bean);
        PlayerPrefs.Save();
        _txtPointCoin.text = Coin.ToString();
    }


    public void Skill1()
    {
        if (isAttack)
        {
            if (mana >= maxmana / 2 && !isSkillRunning)
            {
                isAttack = false;
                isSkill = true;
                OnSkill(maxmana / 2);
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
        if (!isSkill)
        {
            if (mana >= 20)
            {
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[2], false);
                testskill2 = Instantiate(Listskill[1], attack.position, attack.rotation).GetComponent<testSkill2>();
                AudioSkill2();
                testskill2.SetDame(Damage2);
                testskill2.OnInit();
                OnSkill(20);
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
        if (!isSkill)
        {
            if (mana >= 10)
            {
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[3], false);
                AudioSkill3();
                skill3 = Instantiate(Listskill[2], attack.position, attack.rotation).GetComponent<Skill3>();
                skill3.SetDame(Damage3);
                skill3.OnInit();
                OnSkill(10);
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
            if (mana >= maxmana / 2)
            {
                isSkill = true;
                isAttack = false;
                _anim[1].SetActive(true);
                _anim[2].SetActive(true);
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
            if (mana >= maxmana / 2)
            {
                isSkill = true;
                skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[5], false);
                audios.PlayOneShot(audioClick[6]);
                skill5 = Instantiate(Listskill[4], attack.position, attack.rotation).GetComponent<Skill5>();
                skill5.SetDame(Damage5);
                skill5.OnInit();
                OnSkill(maxmana / 2);
                StartCoroutine(DelayIdle());
            }
            else
            {
                Debug.Log("Yếu Sinh Lý");
            }
        }
    }

    private void SetSkillKame()
    {
        GameObject targetBotObj = GameObject.FindGameObjectWithTag("Bot");
        targetBot = targetBotObj.GetComponent<SkeletonAnimation>();
        Vector2 targetPosition = (targetBotObj.transform.position - transform.position);
        skillKame = Instantiate(Listskill[0], attack.position, attack.rotation).GetComponent<SkillKame>();
        skillKame.GetComponent<Rigidbody2D>().velocity = targetPosition.normalized * 20;
        skillKame.SetDame(Damage1);
    }
    private void SetSkillKingki()
    {
        GameObject targetBotObj = GameObject.FindGameObjectWithTag("Bot");
        targetBot = targetBotObj.GetComponent<SkeletonAnimation>();
        Vector2 targetPosition = (targetBotObj.transform.position - transform.position);
        skill4 = Instantiate(Listskill[3], attack.position, attack.rotation).GetComponent<Skill4>();
        skill4.GetComponent<Rigidbody2D>().velocity = targetPosition.normalized * 20;
        skill4.SetDame(Damage4);
    }
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
        AudioSkill4();
        yield return new WaitForSeconds(2.3f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[4], false);
        yield return new WaitForSeconds(0.5f);
        SetSkillKingki();

        _anim[1].SetActive(false);
        _anim[2].SetActive(false);
        OnSkill(maxmana / 2);
        StartCoroutine(DelayIdle());
    }
    IEnumerator DelaySkill1()
    {
        isSkillRunning = true;
        rb.velocity = Vector2.zero;
        _anim[1].SetActive(true);
        _anim[2].SetActive(true);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[7], false);
        AudioSkill1a();
        GameObject hVFX = Instantiate(hitVFX[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(2.2f);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[1], false);
        AudioSkill1b();
        Destroy(hVFX);
        AudioSkill1b();
        yield return new WaitForSeconds(0.3f);
        SetSkillKame();
        StartCoroutine(DelayIdle());
        _anim[1].SetActive(false);
        _anim[2].SetActive(false);
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
        _anim[0].SetActive(false);
        skeletonAnimation[center].AnimationState.SetAnimation(1, ListAnim[0], false);
        isSSJ = false;
        isAttack = true;
        isSkill = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BeanBlue"))
        {
            AudioItem();
            mana = maxmana;
            vfx = true;
            healbar.SetNewMana(mana);
            StartCoroutine(CollisionItem());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BeanRed"))
        {
            AudioItem();
            hp = maxhp;
            vfx = true;
            healbar.SetNewHp(hp);
            StartCoroutine(CollisionItem());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BeanGreen"))
        {
            AudioItem();
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
            AudioItem();
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
            GameObject hVFX = Instantiate(hitVFX[3], transform.position, transform.rotation);
            AudioCoin();
            Coin += 100;
            point += 100;
            OnInitCoin();
            Destroy(collision.gameObject);
            Destroy(hVFX, 3);
        }
    }
    public void LevelUpSSJ()
    {
        float dame4New = Damage4;
        float dame5New = Damage5;
        float hpNew = maxhp * 2;
        float manaNew = maxmana * 1.2f;
        float dame1New = Damage1 * 2;
        float dame2New = Damage2 + (Damage2 * 0.6f);
        float dame3New = Damage3 + (Damage3 * 0.6f); ;
        if (levelValue >= 3)
        {
            dame5New = Damage5 * 2;

        }
        if (levelValue >= 6)
        {
            dame4New = Damage4 * 2;
        }

        Damage1 = dame1New;
        Damage2 = dame2New;
        Damage3 = dame3New;
        Damage4 = dame4New;
        Damage5 = dame5New;
        SetDame(dame1New, dame2New, dame3New, dame4New, dame5New);
        maxhp = hpNew;
        maxmana = manaNew;
        healbar.SetNewMaxHp(maxhp);
        healbar.SetNewMaxMana(maxmana);
    }
    public void AudioSkill1a()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[0]);

        }
    }
    public void AudioSkill1b()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[1]);
        }
    }
    public void AudioSkill2()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[2]);

        }
    }
    public void AudioSkill3()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[3]);
            audios.PlayOneShot(audioClick[4]);
        }
    }
    public void AudioSkill4()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[5]);
        }
    }
    public void AudioSkill5()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[6]);
        }
    }
    public void AudioSSJ()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[7]);
        }
    }
    public void AudioItem()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[8]);
        }
    }
    public void AudioCoin()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[10]);
        }
    }
    public void AudioAddCoin()
    {
        int a = PlayerPrefs.GetInt("audioClick");
        if (a == 0)
        {
            audios.PlayOneShot(audioClick[9]);
        }
    }
}
