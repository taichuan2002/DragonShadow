using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaunItem : MonoBehaviour
{
    public GameObject[] Items;
    public float spawnTime;


    void Start()
    {
        spawnTime = 0;
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
        spawnItem();
            spawnTime = spawnTime;
        }
    }

    public void spawnItem()
    {
        float randomY = Random.Range(-3, 3);
        int random = Random.Range(0, 4);
        Vector2 spawnitem = new Vector2(8, randomY);
        GameObject tf = Instantiate(Items[random], spawnitem, Quaternion.identity);
        tf.transform.position = -transform.right * 5f;
    }

}
