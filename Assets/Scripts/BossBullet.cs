using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public TMPro.TextMeshProUGUI t1;
    public string text = "Coins: ";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Coin2DPro.count = Coin2DPro.count - 5;
            t1.text = text + Coin2DPro.count;
            if (Coin2DPro.count <= 0)
            {
                Coin2DPro.count = Coin2DPro.countAll;
                UnityEngine.SceneManagement.SceneManager.LoadScene(10);
            }
        }
    }
}
