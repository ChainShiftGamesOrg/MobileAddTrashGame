using UnityEngine;
using UnityEngine.UI;

public class ThingMonitor : MonoBehaviour
{
    public ThingRuntimeSet Set;

    public Text Text;

    private int previousCount = -1;

    private void OnEnable()
    {
        UpdateText();
    }

    private void Update()
    {
        if (previousCount != Set.Items.Count)
        {
            UpdateText();
            previousCount = Set.Items.Count;
        }
    }

    public void UpdateText()
    {
        Text.text = "There are " + Set.Items.Count + " things.";
    }
}
