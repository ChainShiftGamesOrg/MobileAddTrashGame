using UnityEngine;
using UnityEngine.UI;

public class SliderValueToFloatVariableValue : MonoBehaviour
{
    public Slider Slider;
    public FloatVariable Variable;

    private void Start()
    {
        if (Slider != null && Variable != null)
            Slider.value = Variable.Value;
    }

    public void UpdateFloatVariable()
    {
        if (Slider != null && Variable != null)
            Variable.Value = Slider.value;
    }
}
