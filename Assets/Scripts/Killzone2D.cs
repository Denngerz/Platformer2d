using UnityEngine;

public class Killzone2D : MonoBehaviour
{
    public bool killMe;
    public bool killOther;
    public bool killPlayer;
    public bool killMonster;
    public int playerGoTo;
    public string ignoreTag = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ignoreTag)
        {
            return;
        }
        if (killMe == true)
        {
            Destroy(gameObject);
        }
        if (killOther == true && other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
        if (killPlayer == true && other.tag == "Player")
        {
            Coin2DPro.count = Coin2DPro.countAll;
            UnityEngine.SceneManagement.SceneManager.LoadScene(playerGoTo);
        }
    }
}
