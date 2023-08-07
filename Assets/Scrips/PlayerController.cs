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
    [SerializeField] GameObject[] Listskill1;
    [SerializeField] Transform attack;
    [SerializeField] GameObject pointAttack;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AnimationReferenceAsset[] ListAnim;
    [SerializeField] GameObject Bot;
    [SerializeField] DataPlayer playerData;
    [SerializeField] Transform gameDead;
    [SerializeField] TextMeshProUGUI _txtPointCoin;


    public Animator animator;
    public GameObject[] hitVFX;
    public float speed;
    public Skin sk;
    public SkeletonAnimation skeletonAnimation;
    public Vector3[] v3;
    public Button[] _btn;
    public string sceneName = "Menu";


    private Vector2 mousePos;
    private float minX = -10f;
    private float maxX = 2.2f;
    private float minY = -4.5f;
    private float maxY = 4.5f;
    private bool isAttack = true;
    private bool isSkillRunning = false;
    private int Coin;
    private bool isImmortal = false;
    private float invincibleTime = 5f;
    private float invincibleTimer = 0f;




    private void Start()
    {
        OnInit();
        OnInitCoin();
    }


    private void Update()
    {
        if (isAttack)
        {
            Control();
        }
        if (hp == 0)
        {
            gameDead.gameObject.SetActive(true);
            StartCoroutine(nextScene());
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
        Application.targetFrameRate = 90;
        hp = playerData.maxHp;
        mana = playerData.maxMana;
        maxhp = playerData.maxHp;
        maxmana = playerData.maxMana;

        healbar.SetNewHp(maxhp);
        healbar.SetNewMana(maxmana);
        healbar.OnInit(maxhp, maxmana);

        rb = GetComponent<Rigidbody2D>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        mousePos = transform.position;
    }

    public void OnInitCoin()
    {
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
                onSkill(40);
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
                isAttack = false;
                skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[2], false);
                Instantiate(Listskill1[1], attack.position, attack.rotation);
                Instantiate(Listskill1[1], attack.position, attack.rotation);
                Instantiate(Listskill1[1], attack.position, attack.rotation);
                Instantiate(Listskill1[1], attack.position, attack.rotation);
                Instantiate(Listskill1[1], attack.position, attack.rotation);
                onSkill(25);
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
                skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[3], false);
                Instantiate(Listskill1[2], attack.position, attack.rotation);
                onSkill(15);
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
                skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[8], false);
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
                skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[5], false);
                Instantiate(Listskill1[4], attack.position, attack.rotation);
                onSkill(40);
                StartCoroutine(DelayIdle());
            }
            else
            {
                Debug.Log("Yếu Sinh Lý");
            }
        }
    }
    public void SieuSayya()
    {
        if (isAttack)
        {
            StartCoroutine(delayTransform());
            isAttack = false;
        }
    }

    IEnumerator Immortal()
    {
        yield return new WaitForSeconds(invincibleTime);
        isImmortal = false;
    }
    IEnumerator delaySkill4()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[4], false);
        yield return new WaitForSeconds(0.5f);
        Instantiate(Listskill1[3], attack.position, attack.rotation);
        onSkill(40);
        StartCoroutine(DelayIdle());
    }
    IEnumerator delayTransform()
    {
        int levelValue2 = int.Parse(playerData.level);
        int levelValue = int.Parse(level);
        yield return new WaitForSeconds(0.4f);

        if (levelValue < levelValue2)
        {
            _btn[1].interactable = true;
            hp = maxhp;
            mana = maxmana;
            healbar.SetNewHp(hp);
            healbar.SetNewMana(mana);
            skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[6], false);
            levelValue++;
            level = levelValue.ToString();
            skeletonAnimation.skeleton.SetSkin(level);
            StartCoroutine(DelayIdle());
        }
        if (levelValue >= levelValue2)
        {
            _btn[1].interactable = false;
        }


    }
    public void eatBeans()
    {
        if (hp != maxhp || mana != maxmana)
        {
            if (Coin >= 500)
            {
                _btn[0].interactable = true;
                Coin -= 500;
                OnInitCoin();
                hp = maxhp;
                mana = maxmana;
                healbar.SetNewHp(hp);
                healbar.SetNewMana(mana);
            }
            if (Coin < 500)
            {
                _btn[0].interactable = false;
            }
        }
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("openPanel", 1);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator DelaySkill1()
    {
        isSkillRunning = true;
        rb.velocity = Vector2.zero;
        skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[7], false);
        GameObject hVFX = Instantiate(hitVFX[0], transform.position, transform.rotation);
        GameObject hVFX2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[1], false);
        yield return new WaitForSeconds(0.5f);
        Destroy(hVFX);
        Destroy(hVFX2);
        GameObject newSkill = Instantiate(Listskill1[0], attack.position, attack.rotation);
        StartCoroutine(DelayIdle());
        isSkillRunning = false;
    }
    IEnumerator DelayIdle()
    {
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[0], false);
        isAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BeanBlue"))
        {
            mana = maxmana;
            healbar.SetNewMana(mana);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BeanRed"))
        {
            hp = maxhp;
            healbar.SetNewHp(hp);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BeanGreen"))
        {
            mana = maxmana;
            hp = maxhp;
            healbar.SetNewHp(hp);
            healbar.SetNewMana(mana);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Armor"))
        {
            if (!isImmortal)
            {
                isImmortal = true;
                invincibleTimer = invincibleTime;
                StartCoroutine(Immortal());
            }
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            Coin += 1000;
            OnInitCoin();
            Destroy(collision.gameObject);
        }
    }

}
