using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMusic : MonoBehaviour
{
    GameObject music;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(music);
    }
}
