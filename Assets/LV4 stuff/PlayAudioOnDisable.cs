using UnityEngine;

public class PlayAudioOnDisable : MonoBehaviour
{
    private AudioManagerScript audioManagerScript;

    private void Awake()
    {
        audioManagerScript = AudioManagerScript.Instance;
    }

    private void OnDisable()
    {
        if (audioManagerScript != null)
        {
            audioManagerScript.PlayAudio();
        }
    }
}
