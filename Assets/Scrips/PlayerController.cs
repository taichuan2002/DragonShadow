using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Charactor
{
    [SerializeField] private GameObject[] Listskill1;
    [SerializeField] private Transform attack;
    [SerializeField] private GameObject pointAttack;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AnimationReferenceAsset[] ListAnim;
    [SerializeField] private GameObject Bot;
    [SerializeField] private DataPlayer playerData;

    public GameObject[] hitVFX;
    private Vector3 mousePos;
    public float speed;
    private float minX = -10f;
    private float maxX = 1;
    private float minY = -4.5f;
    private float maxY = 4.5f;
    private bool isCheck = false;
    private bool isAttack = true;
    private bool isSkillRunning = false;

    private int Coin = 0;
    public Skin sk;
    public SkeletonAnimation skeletonAnimation;
    public Vector3[] v3;
    

    private void Start()
    {
        hp = playerData.playerProperties.maxHp;
        mana = playerData.playerProperties.maxMana;
        maxhp = playerData.playerProperties.maxHp;
        maxmana = playerData.playerProperties.maxMana;
        
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
    

    private void Update()
    {
        OnInit();
        
        if (isAttack)
        {
            Control();
        }
    }

    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
    }
    
    public  void Control()
    {
        
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (!IsMouseOverButton())
        {
            float clampedX = Mathf.Clamp(mousePos.x, minX, maxX);
            float clampedY = Mathf.Clamp(mousePos.y, minY, maxY);
            Vector2 clampedMousePos = new Vector2(clampedX, clampedY);
            transform.position = Vector2.Lerp(transform.position, clampedMousePos, 5f * Time.deltaTime);
        }
    }

    public void OnInit()
    {
        UIManager.Instance.SetCoin(Coin);
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
                isAttack=false;
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
                skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[2], false);
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
        hp = maxhp;
        mana = maxmana;
        healbar.SetNewHp(hp);
        healbar.SetNewMana(mana);
        skeletonAnimation.AnimationState.SetAnimation(1, ListAnim[6], false);
        StartCoroutine(delayTransform());
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
            levelValue++;
            level = levelValue.ToString();
            skeletonAnimation.skeleton.SetSkin(level);
            StartCoroutine(DelayIdle());
        }
    }
    public void eatBeans()
    {
        if(Coin>= 500)
        {
            Coin -= 500;
            UIManager.Instance.SetCoin(Coin);
            hp = maxhp;
            mana = maxmana;
            healbar.SetNewHp(hp);
            healbar.SetNewMana(mana);
        }
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
        isSkillRunning=false;
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
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            Coin += 100;
            PlayerPrefs.SetInt("Coin", Coin);
            UIManager.Instance.SetCoin(Coin);
            Destroy(collision.gameObject);
        }
    }

}
