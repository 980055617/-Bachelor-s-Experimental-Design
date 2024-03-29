using UnityEngine;
using System.Collections;

public class IconBystanderScenario : MonoBehaviour
{
    public GameObject prefabToSpawn; // 生成するPrefab
    public manipulatecanvas manipulateCanvasA; // manipulatecanvasコンポーネントをリンクするためのフィールド
    public cntBystander cntBystanderA; // cntBystanderコンポーネントをリンクするためのフィールド

    public Transform rangeA;
    public Transform rangeB;

    public startSignal startSignalA;

    private bool startFlag = false;

    private void Update()
    {
        // プレファブを指定の位置に生成

        // シナリオ開始
        if (startSignalA.start && ! startFlag)
        {
            startFlag = true;
            Debug.Log("Start");
            StartCoroutine(WaitAndExecuteAction()); // 15
        }



    }

    IEnumerator WaitAndExecuteAction()
    {
        yield return new WaitForSeconds(15f); // 15s
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        float y = 1.55f;
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        GameObject spawnedPrefab = Instantiate(prefabToSpawn, new Vector3(x, y, z), prefabToSpawn.transform.rotation);

        IconGen IconGenA = spawnedPrefab.GetComponent<IconGen>();

        IconGenA.manipulateCanvasA = manipulateCanvasA;

        IconGenA.cntBystanderA = cntBystanderA;

        x = Random.Range(rangeA.position.x, rangeB.position.x);
        y = 1.55f;
        z = Random.Range(rangeA.position.z, rangeB.position.z);

        GameObject spawnedPrefab1 = Instantiate(prefabToSpawn, new Vector3(x, y, z), prefabToSpawn.transform.rotation);

        IconGen IconGenB = spawnedPrefab1.GetComponent<IconGen>();

        IconGenB.manipulateCanvasA = manipulateCanvasA;

        IconGenB.cntBystanderA = cntBystanderA;

        yield return new WaitForSeconds(5f); // 20s

        Destroy(spawnedPrefab);
        Destroy(spawnedPrefab1);


        yield return new WaitForSeconds(20f); // 40s

        x = Random.Range(rangeA.position.x, rangeB.position.x);
        y = 1.55f;
        z = Random.Range(rangeA.position.z, rangeB.position.z);

        spawnedPrefab = Instantiate(prefabToSpawn, new Vector3(x, y, z), prefabToSpawn.transform.rotation);

        IconGenA = spawnedPrefab.GetComponent<IconGen>();

        IconGenA.manipulateCanvasA = manipulateCanvasA;

        IconGenA.cntBystanderA = cntBystanderA;

        x = Random.Range(rangeA.position.x, rangeB.position.x);
        y = 1.55f;
        z = Random.Range(rangeA.position.z, rangeB.position.z);

        spawnedPrefab1 = Instantiate(prefabToSpawn, new Vector3(x, y, z), prefabToSpawn.transform.rotation);

        IconGenB = spawnedPrefab1.GetComponent<IconGen>();

        IconGenB.manipulateCanvasA = manipulateCanvasA;

        IconGenB.cntBystanderA = cntBystanderA;

        x = Random.Range(rangeA.position.x, rangeB.position.x);
        y = 1.55f;
        z = Random.Range(rangeA.position.z, rangeB.position.z);

        GameObject spawnedPrefab2 = Instantiate(prefabToSpawn, new Vector3(x, y, z), prefabToSpawn.transform.rotation);

        IconGen IconGenC = spawnedPrefab2.GetComponent<IconGen>();

        IconGenC.manipulateCanvasA = manipulateCanvasA;

        IconGenC.cntBystanderA = cntBystanderA;

        yield return new WaitForSeconds(20f); // 60s

        Destroy(spawnedPrefab);
        Destroy(spawnedPrefab1);
        Destroy(spawnedPrefab2);

        yield return new WaitForSeconds(15f); // 75s

        x = Random.Range(rangeA.position.x, rangeB.position.x);
        y = 1.55f;
        z = Random.Range(rangeA.position.z, rangeB.position.z);

        spawnedPrefab = Instantiate(prefabToSpawn, new Vector3(x, y, z), prefabToSpawn.transform.rotation);

        IconGenA = spawnedPrefab.GetComponent<IconGen>();

        IconGenA.manipulateCanvasA = manipulateCanvasA;

        IconGenA.cntBystanderA = cntBystanderA;
    }

}
