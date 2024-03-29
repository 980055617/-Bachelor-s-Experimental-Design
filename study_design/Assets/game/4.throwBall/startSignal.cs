using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSignal : MonoBehaviour
{
    // Start is called before the first frame update

    public bool start = false;
    private AudioSource audioSource;
    public AudioClip bgmClip; // BGM用のオーディオクリップ
    public float detectionTimer = 60f; // 検知タイマー
    private void Update()
    {
        if(start)
        {
            detectionTimer -= Time.deltaTime;
            if (detectionTimer <= 0f)
            {
                start = false;
                detectionTimer = 0f;
                audioSource.Stop();
            }
        }
        // スペースキーが押されたら
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = bgmClip;
            audioSource.loop = true; // ループ再生を有効にする
            audioSource.volume = 0.1f;
            audioSource.Play(); // BGMの再生を開始
        }
    }
}
