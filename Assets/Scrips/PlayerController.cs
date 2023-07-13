using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Charactor
{
    [SerializeField] private GameObject[] skill1;
    [SerializeField] private Transform attack;
    [SerializeField] private Rigidbody2D rb;

    private Vector3 mousePos;
    public float speed;
    private bool isCheck = false;
    private float minX = -9f;
    private float maxX = 0;
    private float minY = -4.5f;
    private float maxY = 4.5f;

    void Start()
    {
        mousePos = transform.position;
    }

    void Update()
    {
        Control();
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

    private bool IsMouseOverButton()
    {
        return EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject != null;
    }
    public void Skill1()
    {
        if (mana >= 40)
        {
            Instantiate(skill1[0], attack.position, attack.rotation);
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
            Instantiate(skill1[1], attack.position, attack.rotation);
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
            Instantiate(skill1[2], attack.position, attack.rotation);
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
            Instantiate(skill1[3], attack.position, attack.rotation);
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
            Instantiate(skill1[4], attack.position, attack.rotation);
            onSkill(40);
        }
        else
        {
            Debug.Log("Yếu Sinh Lý");
        }
    }

    public void ActiveSkill1()
    {
        
    }
    
}
