using UnityEngine;

[CreateAssetMenu(menuName = "Variables/String")]
public class StringVariable : ScriptableObject
{
    [SerializeField]
    private string value = "";

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public string Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public void SetValue(string value)
    {
        Value = value;
    }

    public void SetValue(StringVariable value)
    {
        Value = value.Value;
    }

    public void AppendValue(string value)
    {
        Value += value;
    }

    public void AppendValue(StringVariable value)
    {
        Value += value.Value;
    }
}
