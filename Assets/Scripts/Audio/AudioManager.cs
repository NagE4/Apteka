using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // public void OnApproveButtonClicked()
    // {
    //     decisionManager.Approve();
    //     audioManager.PlaySFX(approveSound); // Play click sound
    // }
}

