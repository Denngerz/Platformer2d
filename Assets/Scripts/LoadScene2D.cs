using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene2D : MonoBehaviour
{
    public int playerGoTo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Coin2DPro.countAll = Coin2DPro.count;
            UnityEngine.SceneManagement.SceneManager.LoadScene(playerGoTo);
        }
    }
}
