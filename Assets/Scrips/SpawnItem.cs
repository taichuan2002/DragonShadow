using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> listItem = new List<GameObject>();
    GameObject newItem, newItem2;
    int randomItem;
    void Start()
    {
        StartCoroutine(SpawnListItem());
        StartCoroutine(SpawnListItem2());
    }

    private void Update()
    {
        if (Bot.dataEneMy != null || PlayerController.playerData)
        {
            if (Bot.dataEneMy.isDead == true || PlayerController.playerData.isDead == true)
            {
                StopCoroutine(SpawnListItem());
                StopCoroutine(SpawnListItem2());
            }
        }
    }

    private void SpawnPointItem()
    {
        randomItem = Random.Range(0, 4);
        float randomY = Random.Range(-3.9f, 3.9f);
        Vector2 spawnItem = new Vector2(10, randomY);
        newItem = Instantiate(listItem[randomItem], spawnItem, transform.rotation);
        StartCoroutine(MoveItem(newItem));
    }
    private void SpawnPointItem2()
    {
        int randomItem2 = Random.Range(0, 4);
        float randomY = Random.Range(-3.9f, 3.9f);
        Vector2 spawnItem2 = new Vector2(10, randomY);
        newItem2 = Instantiate(listItem[randomItem2], spawnItem2, transform.rotation);
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
