using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSign : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform[] spawnPoints;
    public float spawnDistance = 10f;
    public float spawnInterval = 5f;
    public AudioClip soundClip1; // 効果音用のAudioClip

    public AudioClip soundClip2; // 効果音用のAudioClip

    private AudioSource audioSource;
    private GameObject spawnedSphere;
    private int currentSpawnPointIndex = 0;
    private float timer = 0f;
    private bool hasPlayedSound = false; // 効果音が再生されたかどうかのフラグ

    private void Start()
    {
        spawnedSphere = Instantiate(spherePrefab, spawnPoints[currentSpawnPointIndex].position, Quaternion.identity);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(spawnPoints[currentSpawnPointIndex].position, GameObject.Find("Player").transform.position);

        if (!hasPlayedSound && distanceToPlayer < spawnDistance)
        {
            // プレイヤーが近くにいて、効果音が再生されていない場合
            audioSource.PlayOneShot(soundClip1);
            hasPlayedSound = true; // フラグを設定

            // タイマーをリセット
            timer = 0f;
        }
        if (distanceToPlayer < spawnDistance)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                if (spawnedSphere != null)
                {
                    Destroy(spawnedSphere);
                }

                currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPoints.Length;
                spawnedSphere = Instantiate(spherePrefab, spawnPoints[currentSpawnPointIndex].position, Quaternion.identity);

                timer = 0f;
                audioSource.PlayOneShot(soundClip2,0.5f);
                hasPlayedSound = false;
            }
        }
    }
}