using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    
    public void SpawnItems()
    {
        StartCoroutine(SpawnAfterTime());
    }

    IEnumerator SpawnAfterTime()
    {
        yield return new WaitForSeconds(3);
        GameObject fruit = Instantiate(items[Random.Range(0, items.Length)], this.transform) as GameObject;
        fruit.transform.localPosition = new Vector2(Random.Range(-9.5f, 9.5f), Random.Range(-3.4f, 4.6f));
        
    }
}
