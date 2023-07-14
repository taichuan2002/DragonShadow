using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Charactor
{
    [SerializeField] private GameObject[] Listskill1;
    [SerializeField] private Transform attack;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AnimationReferenceAsset idle, skill0, skill1, skill2, skill3, skill4, skilltransform;


    private Vector3 mousePos;
    public float speed;
    private bool isCheck = false;
    private float minX = -9f;
    private float maxX = 0;
    private float minY = -4.5f;
    private float maxY = 4.5f;


    private int Coin = 0;

    Animation nextAnim;
    SkeletonAnimation skeletonAnimation;


    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
        mousePos = transform.position;
    }

    private void Update()
    {
        Control();
        OnInit();
    }

    private void Awake()
    {
        Coin = PlayerPrefs.GetInt("Coin", 0);
    }

    public  void Control()
    {
        if (!isCheck) { 
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
        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation is not initialized!");
            return;
        }
        if (mana >= 40)
        {
            skeletonAnimation.AnimationState.SetAnimation(1, skill0, false);
            /* var track = skeletonAnimation.AnimationState.SetAnimation(1, skill0, false);
             track.AttachmentThreshold = 5f;
             track.MixDuration = 0f;*/
            Instantiate(Listskill1[0], attack.position, attack.rotation);
            onSkill(40);
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }
        //healbar.onDame(15);
        /*GameObject newSkill = Instantiate(skill1[0], attack.position, transform.rotation);
        Rigidbody2D skillRb = newSkill.GetComponent<Rigidbody2D>();
        skillRb.velocity = transform.right * speed;
        Destroy(newSkill, 4f);*/


    }


    public void Skill2()
    {
        if (mana >= 25)
        {
            skeletonAnimation.AnimationState.SetAnimation(1, skill1, false);
            Instantiate(Listskill1[1], attack.position, attack.rotation);
            onSkill(25);
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }
    }
    public void Skill3()
    {
        if (mana >= 15)
        {
            skeletonAnimation.AnimationState.SetAnimation(1, skill2, false);
            Instantiate(Listskill1[2], attack.position, attack.rotation);
            onSkill(15);
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }

    }
    public void Skill4()
    {
        if (mana >= 40)
        {
            skeletonAnimation.AnimationState.SetAnimation(1, skill3, false);
            Instantiate(Listskill1[3], attack.position, attack.rotation);
            onSkill(40);
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }
    }
    public void Skill5()
    {
        if (mana >= 40)
        {
            skeletonAnimation.AnimationState.SetAnimation(1, skill4, false);
            Instantiate(Listskill1[4], attack.position, attack.rotation);
            onSkill(40);
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }
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
