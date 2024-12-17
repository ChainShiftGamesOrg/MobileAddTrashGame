using UnityEngine;

public class VariableAudioTrigger : MonoBehaviour
{
    public AudioSource AudioSource;

    public FloatVariable Variable;

    public FloatReference LowThreshold;

    private void Update()
    {
        if (Variable.Value < LowThreshold)
        {
            if (!AudioSource.isPlaying)
                AudioSource.Play();
        }
        else
        {
            if (AudioSource.isPlaying)
                AudioSource.Stop();
        }
    }
}
