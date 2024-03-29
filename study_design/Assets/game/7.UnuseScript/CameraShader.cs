using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShader : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    private void OnRenderImage(RenderTexture source, RenderTexture dest){
        Graphics.Blit(source, dest, _material);
    }
}
