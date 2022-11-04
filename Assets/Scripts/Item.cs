using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Rigidbody2D rb;
    public int forceChance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (Random.Range(0, forceChance) == 0)
            {
                rb.AddForce(new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0), ForceMode2D.Impulse);
                Destroy(this.gameObject, 2);
                GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SpawnItems();
            }
            else
            {
                Destroy(this.gameObject);
                GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SpawnItems();
            }
 
        }
    }
    

    void Update()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
        GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SpawnItems();
    }

}

