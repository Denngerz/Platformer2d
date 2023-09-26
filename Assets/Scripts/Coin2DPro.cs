using UnityEngine;

public class Coin2DPro : MonoBehaviour
{
    public TMPro.TextMeshProUGUI t1;
    public string text = "Coins: ";
    public AudioSource music;
    public static int count = 0;
    public static int countAll = 0;
    bool was = false;  // doesn't work twice

    private void Start()
    {
        t1.text = text + countAll;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && was == false)
        {
            count++;
            was = true;
            t1.text = text + count;
            music.Play();
            Destroy(gameObject);
        }
    }
}
