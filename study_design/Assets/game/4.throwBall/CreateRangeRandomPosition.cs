using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject createPrefab;
    public Transform rangeA;
    public Transform rangeB;

    public startSignal startSignalA;

    private float time = 0f;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        // 約1秒置きにランダムに生成されるようにする。
        if (time > 1.0f && spawnedObjects.Count < 3 && startSignalA.start)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = 1.55f;
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject newObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

            // 生成されたオブジェクトをリストに追加
            spawnedObjects.Add(newObject);

            // 経過時間リセット
            time = 0f;
        }
    }

    public void RemoveObject(GameObject obj)
    {
        spawnedObjects.Remove(obj);
    }
}