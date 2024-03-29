using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterSample : MonoBehaviour {

    public ScoreManager scoreText;
    public ObjectSpawner objectSpawner;

    public AudioSource audioSource; // 効果音用のオーディオソース
    public AudioClip collisionSound; // 衝突時の効果音

    private void OnCollisionEnter(Collision collision)
    {
        // Ballが衝突したオブジェクトがFloorだった場合
        if (collision.gameObject.name == "Floor") {
            // 机の上に戻る
            GetComponent<Transform>().position = new Vector3(-2.812f, 1.5f, -10.91f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (collision.gameObject.name == "Target(Clone)") {
            // 衝突したオブジェクトを破棄する
            Destroy(collision.gameObject);

            // ObjectSpawner スクリプトの RemoveObject メソッドを呼び出してオブジェクトをリストから削除
            objectSpawner.RemoveObject(collision.gameObject);

            // スコアを増加
            scoreText.IncreaseScore();

            // 衝突時の効果音を再生
            if (audioSource != null && collisionSound != null) {
                audioSource.PlayOneShot(collisionSound);
            }

        }
    }
}





