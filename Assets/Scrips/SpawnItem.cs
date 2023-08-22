using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> listItem = new List<GameObject>();
    [SerializeField] GameObject[] HitVFX;
    GameObject newItem, newItem2, vfx, vfx2;
    int randomItem;
    void Start()
    {
        StartCoroutine(SpawnListItem());
        //StartCoroutine(SpawnListItem2());
    }

    private void Update()
    {
        if (newItem != null)
        {
            vfx.transform.position = newItem.transform.position;
            if (newItem == null)
            {
                Destroy(vfx);
            }
        }
        if (newItem2 != null)
        {
            vfx2.transform.position = newItem2.transform.position;
            if (newItem2 == null)
            {
                Destroy(vfx2);
            }
        }
    }

    private void SpawnPointItem()
    {
        randomItem = Random.Range(0, 4);
        float randomY = Random.Range(-3.9f, 3.9f);
        Vector2 spawnItem = new Vector2(10, randomY);
        newItem = Instantiate(listItem[3], spawnItem, transform.rotation);
        vfx = Instantiate(HitVFX[3], newItem.transform.position, newItem.transform.rotation);
        StartCoroutine(MoveItem(newItem));
    }
    private void SpawnPointItem2()
    {
        int randomItem2 = Random.Range(0, 4);
        float randomY = Random.Range(-3.9f, 3.9f);
        Vector2 spawnItem2 = new Vector2(10, randomY);
        newItem2 = Instantiate(listItem[3], spawnItem2, transform.rotation);
        vfx2 = Instantiate(HitVFX[3], newItem2.transform.position, newItem2.transform.rotation);
        StartCoroutine(MoveItem(newItem2));
    }
    private IEnumerator SpawnListItem()
    {
        yield return new WaitForSeconds(10);
        while (true)
        {
            SpawnPointItem();
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
    private IEnumerator SpawnListItem2()
    {
        yield return new WaitForSeconds(10);
        while (true)
        {
            SpawnPointItem2();
            yield return new WaitForSeconds(Random.Range(5f, 25f));
        }
    }
    private IEnumerator MoveItem(GameObject item)
    {
        while (item != null)
        {
            item.transform.Translate(Vector2.left * 5f * Time.deltaTime);
            yield return null;
        }

    }
}
