using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation targetBot;
    public Rigidbody2D rb;
    public GameObject[] hitVFX;
    public DataPlayer player;
    float Damecurren;
    void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        Destroy(gameObject, 3);
    }

    public void SetDame(float dame)
    {
        Damecurren = dame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<CharactorEnemy>().OnHit(Damecurren);
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
            GameObject hitvfx3 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            Vector3 largerScale = new Vector2(3, 3);
            hitvfx.transform.localScale = largerScale;
            Destroy(gameObject);
            Destroy(hitvfx, 1);
            Destroy(hitvfx2, 1);
            Destroy(hitvfx3, 1);
        }
    }
}
