using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private AudioManager audioManager;

    private ScoreManager1 scoreText;
    private bool addedScore = false;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        scoreText = GameObject.Find("Score").GetComponent<ScoreManager1>();
    }

    // 衝突を検知するためのコライダー
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがLeftHandまたはRightHandであるかをチェック
        if (collision.gameObject.name == "HandColliderRight(Clone)" || collision.gameObject.name == "HandColliderLeft(Clone)")
        {

            // 効果音を再生
            audioManager.PlaySFX();
            // CubeCenterオブジェクトを破壊
            Destroy(gameObject);
            if (addedScore == false)
            {
                scoreText.IncreaseScore();
                addedScore = true;
            }
        }
        else if (collision.gameObject.name == "HeadCollider" || collision.gameObject.name == "BodyCollider")
        {
            Destroy(gameObject);
        }
    }
}
