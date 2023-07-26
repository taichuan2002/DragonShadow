using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollviewManager : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject[] contentObject;
    public Text prime;

    private int centerIndex;
    private float[] distances;
    void Start()
    {
        distances = new float[contentObject.Length];
        
    }

    private void CalculateDistances()
    {
        Vector2 centerPosition = new Vector2(scrollRect.viewport.rect.center.x, scrollRect.viewport.rect.center.y);
    
        for(int i =0; i < contentObject.Length; i++)
        {
            distances[i] = Vector2.Distance(contentObject[i].transform.position, centerPosition);
        }
        centerIndex = GetClosestObjectIndex();
    }

    private int GetClosestObjectIndex()
    {
        float minDistance = Mathf.Min(distances);
        return System.Array.IndexOf(distances, minDistance);
    }

    private void OnScrollviewValue(Vector2 scrollValue)
    {
        CalculateDistances();

        int newCenterIndex = GetClosestObjectIndex();
        if(newCenterIndex != centerIndex)
        {
            centerIndex = newCenterIndex;
            UpdateDisplayData(centerIndex);
        }
    }
    private void UpdateDisplayData(int index)
    {
        DataPlayer data = contentObject[index].GetComponent<DataPlayer>();
        prime.text = "" + data.name.ToString();
    }

}
