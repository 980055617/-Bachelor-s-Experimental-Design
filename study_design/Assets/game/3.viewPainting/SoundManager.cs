using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float detectionDistance = 10f; // プレイヤーを検出する距離
    public float soundInterval = 1f; // 音を再生する間隔
    private float lastSoundTime; // 最後に音を再生した時間
    public AudioSource audioSource; // 音を再生するためのAudioSource
    public AudioClip soundClip; // 再生する音のクリップ

    void Update()
    {
        if (player == null)
        {
            return; // プレイヤーが設定されていない場合は何もしない
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionDistance && Time.time - lastSoundTime >= soundInterval)
        {
            // プレイヤーが一定の距離以内にいて、音を再生する間隔が経過したら音を再生
            audioSource.PlayOneShot(soundClip);
            lastSoundTime = Time.time;
        }
}
}