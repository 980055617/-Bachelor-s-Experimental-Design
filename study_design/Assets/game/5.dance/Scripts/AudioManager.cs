using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource sfxAudioSource;
    public AudioClip destroySound;

    public AudioClip bgmSound;
    private AudioSource bgmAudioSource;

    void Start()
    {
        // AudioManager オブジェクトに AudioSource コンポーネントを追加
        sfxAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        // sfxAudioSourceに効果音を設定
        sfxAudioSource.clip = destroySound;
        sfxAudioSource.volume = 0.1f; //0.2

        // bgmAudioSourceにBGｍを設定
        bgmAudioSource.clip = bgmSound;
        bgmAudioSource.volume = 0.02f; //0.12
    }

    public void PlaySFX()
    {
        // 効果音を再生

        sfxAudioSource.Play();
    }

    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }
    public IEnumerator FadeOut()
    {
        float currentTime = 0;
        float startVolume = bgmAudioSource.volume;
        while (currentTime < 1.0f)
        {
            currentTime += Time.deltaTime;
            bgmAudioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / 1.0f);
            yield return null;
        }

        // 音量を確実にゼロにセット
        bgmAudioSource.Stop();
    }

}
