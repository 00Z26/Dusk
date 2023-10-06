using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttributeData", menuName = "SO_Attribute")]
public class AttributeData : ScriptableObject
{
    public List<int> attribute;

    public string GetAttrName(int num)
    {
        List<string> attrName = new List<string>() {"expression","candor","understand" };
        return attrName[num];
    }

    public int GetAttrIndex(string name)
    {
        List<string> attrName = new List<string>() { "expression", "candor", "understand" };
        return attrName.IndexOf(name);
    }
}
