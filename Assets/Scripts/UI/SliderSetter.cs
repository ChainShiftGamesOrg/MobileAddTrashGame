using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SliderSetter : MonoBehaviour
{
    public Slider Slider;
    public FloatVariable Variable;

    private void Update()
    {
        if (Slider != null && Variable != null)
            Slider.value = Variable.Value;
    }
}