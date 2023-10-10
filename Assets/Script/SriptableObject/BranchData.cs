using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
[CreateAssetMenu(fileName = "BranchData", menuName = "SO_Branch")]
public class BranchData : ScriptableObject
{
    [SerializeField]
    public int a6_test;
    public int a7_desk;
    public int a7_talk;
    public int a8_lecture;
    public int leader;
    public int a9_honest;
    public int a9_trust;
    public int a9_mhonest;
    public int m9_trust;
    public int a9_choco;
    public int a10_confess;
    public int a10_settle;
    public int a10_care;
    public int b10_confide;
    public int contest;
    public int a10_mconfess;
    public int a10_msettle;
    public int a10_mcare;
    public int b10_mconfide;

    public int b6_test;
    public int b7_other;
    public int b7_talk;
    public int b8_lecture;
    public int b9_honest;
    public int b9_mhonest;
    public int b10_confess;
    public int b10_care;
    public int b10_mconfess;
    public int b10_mcare;


    public int GetValue(string name)
    {
        Type customVaribleType = Type.GetType(this.name);
        object customAaribleObj = Activator.CreateInstance(customVaribleType);
        FieldInfo pi = customVaribleType.GetField(name);

        return (int)pi.GetValue(this);
 
    }

    //传不带$符的name
    public void SetValue(string name,int val)
    {
        //if(this.GetType().GetProperty(name) != null)
        //{
        Type customVaribleType = Type.GetType(this.name);
        object customAaribleObj = Activator.CreateInstance(customVaribleType);
        FieldInfo pi = customVaribleType.GetField(name);
        pi.SetValue(this, val);
        //this.GetType().GetProperty("a6_test").SetValue(this, val);
        //}
    }
}
