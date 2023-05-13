using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttributeSet", menuName = "Attribute System/Attribute Set", order = 1)]
public class AttributeSet : ScriptableObject
{
    [SerializeField] protected List<ModifiableAttribute> _attributes = new List<ModifiableAttribute>();
    public List<ModifiableAttribute> Attributes => _attributes;

    public void OnValidate()
    {
        foreach(ModifiableAttribute attribute in _attributes)
        {
            attribute.CalculateValue();
        }
    }
    
    public ModifiableAttribute GetAttribute(AttributeType type)
    {
        return _attributes.Find(s => s.Type == type);
    }

    protected void InitAttributes()
    {
        foreach(ModifiableAttribute attribute in _attributes)
        {
            attribute.Awake();
            attribute.CalculateValue();
        }
    }
}
