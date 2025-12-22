using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private float setPitch = 1.0f;

    public void PlaySound(AudioClip clip = null, float pitchLowerBound = 1.0f, float pitchUpperBound = 1.0f, float volume = 1.0f)
    {
        if (clip == null)
        {
            Debug.LogWarning("AudioManager: No AudioClip provided to PlaySound method.");
            return;
        }

        setPitch = Random.Range(pitchLowerBound, pitchUpperBound);
        audioSource.pitch = setPitch;
        audioSource.PlayOneShot(clip, volume);
        audioSource.clip = null;
        //audioSource.pitch = 1.0f;
    }
}
