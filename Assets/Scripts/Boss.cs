using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public float time = 1;
    public int lifes = 100;
    public int bulletSpeed = 100;
    public TMPro.TextMeshPro t;
    void Start()
    {
        InvokeRepeating("Timer",time,time);
    }

    void Timer()
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * bulletSpeed);
        Destroy(go, 5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            lifes--;
            if (lifes <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(11);
            }
            t.text = "" + lifes;
        }
    }
}
