using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private GameObject[] listItem;

    void Start()
    {
        StartCoroutine(SpawnListItem());
    }

    // Update is called once per frame
   

    private void SpawnPointItem()
    {
        int randomItem = Random.Range(0,6);
        Debug.Log(randomItem);
        float randomY = Random.Range(-3.9f, 3.9f);
        Vector2 spawnItem = new Vector2(10, randomY);
        GameObject newItem = Instantiate(listItem[randomItem], spawnItem, Quaternion.identity);
        StartCoroutine(MoveItem(newItem));
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
    private IEnumerator MoveItem(GameObject item)
    {
        while(item != null)
        {
            item.transform.Translate(Vector2.left * 5f * Time.deltaTime);
            yield return null;
        }
    }

}
