using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.tag == "Monster")
        {
            Destroy(other.gameObject);
            transform.position = new Vector3(0f, 1000f, 0f);
            Invoke("F1", 1f);
        }
    }
    void F1()
    {
        Destroy(gameObject);
    }
}