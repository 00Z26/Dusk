using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Yarn.Unity;

public class CustomVariableStorage : VariableStorageBehaviour
{
    public AttributeData dayAttributeData;
    public AttributeData nightAttributeData;
    public BranchData branchData;

    public GameObject calculate;
    private CalculateManager calculateManager;

    private List<string> branchVarName = new List<string> { "a6_test", "a7_desk", "a7_talk", "a8_lecture", "leader", "a9_honest", "a9_trust", "a9_mhonest", "m9_trust", "a10_confess",
     "a10_settle", "a10_care", "b10_confide", "contest", "a10_mconfess", "a10_msettle", "a10_mcare", "b10_mconfide", "b6_test", "b7_other", "b7_talk",
     "b8_lecture", "b9_honest", "b9_mhonest", "b10_confess", "b10_care", "b10_mconfess", "b10_mcare" };

    //debug ------------------------------------
    private Dictionary<string, object> variables = new Dictionary<string, object>();
    private Dictionary<string, System.Type> variableTypes = new Dictionary<string, System.Type>(); // needed for serialization
    public UnityEngine.UI.Text debugTextView = null;
    //debug ------------------------------------


    private void Start()
    {
        calculateManager = calculate.GetComponent<CalculateManager>();

    }


    //debug --------------------------------------------------
    internal void Update()
    {
        // If we have a debug view, show the list of all variables in it
        if (debugTextView != null)
        {
            debugTextView.text = GetDebugList();
            debugTextView.SetAllDirty();
        }
    }

    public string GetDebugList()
    {
        var stringBuilder = new System.Text.StringBuilder();
        foreach (KeyValuePair<string, object> item in variables)
        {
            stringBuilder.AppendLine(string.Format("{0} = {1} ({2})",
                                                    item.Key,
                                                    item.Value.ToString(),
                                                    variableTypes[item.Key].ToString().Substring("System.".Length)));
        }
        return stringBuilder.ToString();
    }
    //debug ------------------------------------

    public override bool TryGetValue<T>(string variableName, out T result) 
    {
        if (typeof(T) == typeof(string))
        {
            // TODO: search YarnString for variableName
        }
        else if (typeof(T) == typeof(bool))
        {
 
        }
        else if (typeof(T) == typeof(float))
        {
            int resNum = -1;
            // float值 获取人物属性
            resNum = GetAttributeNum(variableName);
            // 获取剧情分支值
            resNum = branchData.GetValue(variableName.Replace("$",""));

            if(resNum != -1)
            {
                result = (T)(object)resNum;
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }
        result = default(T);
        return false;
    }

    public override void SetValue(string variableName, string stringValue) { }
    public override void SetValue(string variableName, float floatValue) 
    {
        //float 设置人物属性值
        SetAttributeNum(variableName,floatValue);
        branchData.SetValue(variableName.Replace("$", ""),(int)floatValue);
    }
    public override void SetValue(string variableName, bool boolValue) { }
    public override void Clear() 
    {
        // 在数据存储中删除已有的数据
        for(int i = 0;i<dayAttributeData.attribute.Count;i++)
        {
            dayAttributeData.attribute[i] = -1;
        }
        for (int i = 0; i < nightAttributeData.attribute.Count; i++)
        {
            nightAttributeData.attribute[i] = -1;
        }
        foreach(string strName in branchVarName )
        {
            branchData.SetValue(strName, -1);
        }

    }
    public override bool Contains(string variableName) 
    {
        //默认全部包含
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

    private int GetAttributeNum(string variableName)
    {
        //float值 获取人物属性
        string roleName = variableName.Substring(1);
        int res = -1;
        //int attrIndex = this.calculateManager.VariableToAttrIndex(variableName);

        int attrIndex = this.dayAttributeData.GetAttrIndex(variableName.Substring(3,100));
        //确认获取的index
        Debug.Log(attrIndex);

        if (dayAttributeData.attribute[attrIndex] != -1 || nightAttributeData.attribute[attrIndex] != -1)
        {
            if (roleName == "$a")
            {
                res = dayAttributeData.attribute[attrIndex];
            }
            else if (roleName == "$b")
            {
                res = nightAttributeData.attribute[attrIndex];
            }
            return res;
        }
        return res;
    }
    private void SetAttributeNum(string variableName, float val)
    {
        string roleName = variableName.Substring(1);
        //int attrIndex = this.calculateManager.VariableToAttrIndex(variableName);
        int attrIndex = this.dayAttributeData.GetAttrIndex(variableName.Substring(3, 100));

        if (attrIndex != -1)
        {
            if (roleName == "$a")
            {
                dayAttributeData.attribute[attrIndex] = (int)val;
            }
            else if (roleName == "$b")
            {
                nightAttributeData.attribute[attrIndex] = (int)val;
            }
        }

    }
}
