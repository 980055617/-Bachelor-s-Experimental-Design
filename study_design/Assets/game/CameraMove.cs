using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float rotationSpeed = 2f; // 回転速度
    public float ascentSpeed = 5f; // 上昇速度
    public float descentSpeed = 5f; // 下降速度

    private Transform cameraTransform; // カメラのTransform

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // AとDキーまたは矢印キーの左右の入力
        float verticalInput = Input.GetAxis("Vertical"); // WとSキーまたは矢印キーの上下の入力;

        // カメラの移動ベクトルを計算
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // カメラを移動
        cameraTransform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 上昇と下降
        if (Input.GetKey(KeyCode.Space))
        {
            cameraTransform.Translate(Vector3.up * ascentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            cameraTransform.Translate(Vector3.down * descentSpeed * Time.deltaTime);
        }

        // カメラの回転
        float rotateInput = Input.GetAxis("Rotation"); // QとEキーの入力
        Vector3 rotation = cameraTransform.eulerAngles;
        rotation.y += rotateInput * rotationSpeed;
        cameraTransform.eulerAngles = rotation;
    }
}