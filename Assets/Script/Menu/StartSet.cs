using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSet : MonoBehaviour
{
    public AttributeData dayAttr;
    public AttributeData nightAttr;
    public BranchData branch;

    private List<string> branchVarName = new List<string> { "a6_test", "a7_desk", "a7_talk", "a8_lecture", "leader", "a9_honest", "a9_trust", "a9_mhonest", "m9_trust", "a10_confess",
     "a10_settle", "a10_care", "b10_confide", "contest", "a10_mconfess", "a10_msettle", "a10_mcare", "b10_mconfide", "b6_test", "b7_other", "b7_talk",
     "b8_lecture", "b9_honest", "b9_mhonest", "b10_confess", "b10_care", "b10_mconfess", "b10_mcare","a9_choco" };
    private void OnEnable()
    {
        for(int i = 0; i < dayAttr.attribute.Count; i++)
        {
            dayAttr.attribute[i] = -1;
        }
        for (int i = 0; i < nightAttr.attribute.Count; i++)
        {
            nightAttr.attribute[i] = -1;
        }
        foreach (string varName in branchVarName)
        {
            branch.SetValue(varName, -1);
        }
    }
}
