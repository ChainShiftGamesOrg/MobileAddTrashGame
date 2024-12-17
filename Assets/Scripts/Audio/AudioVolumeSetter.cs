using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeSetter : MonoBehaviour
{
    public AudioMixer Mixer;
    public string ParameterName = "";
    public FloatVariable Variable;

    private void Update()
    {
        float dB = Variable.Value > 0.0f ?
            20.0f * Mathf.Log10(Variable.Value) :
            -80.0f;

        Mixer.SetFloat(ParameterName, dB);
    }
}
