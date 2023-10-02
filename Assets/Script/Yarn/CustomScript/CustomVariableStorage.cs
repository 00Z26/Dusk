using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Yarn.Unity;

public class CustomVariableStorage : VariableStorageBehaviour
{
    public AttributeData dayAttributeData;
    public AttributeData nightAttributeData;
    public override bool TryGetValue<T>(string variableName, out T result) 
    {
       if(dayAttributeData.expressionNum != null)
        {
            result = default(T);
            return true;

        }
        result = default(T);
        return false;
    }
    public override void SetValue(string variableName, string stringValue) { }
    public override void SetValue(string variableName, float floatValue) { }
    public override void SetValue(string variableName, bool boolValue) { }
    public override void Clear() 
    {   
        // delete?
        dayAttributeData.expressionNum = 0;
        nightAttributeData.expressionNum = 0;
        dayAttributeData.honestNum = 0;
        nightAttributeData.honestNum = 0;
    }
    public override bool Contains(string variableName) 
    {
        return true;
    }

    public override void SetAllVariables(Dictionary<string, float> floats, Dictionary<string, string> strings, Dictionary<string, bool> bools, bool clear = true)
    {
        throw new System.NotImplementedException();
    }

    //[return: TupleElementNames(new[] { "FloatVariables", "StringVariables", "BoolVariables" })]
    public override (Dictionary<string, float> FloatVariables, Dictionary<string, string> StringVariables, Dictionary<string, bool> BoolVariables) GetAllVariables()
    {
        throw new System.NotImplementedException();
    }
}
