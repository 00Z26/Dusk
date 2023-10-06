using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributeShow : MonoBehaviour
{
    public AttributeData dayAttribute;
    public AttributeData nightAttribute;
    public TextMeshProUGUI dayAttrShow;
    public TextMeshProUGUI nightAttrShow;



    private void Update()
    {
        showAttr();
    }
    public void showAttr()
    {
        string dayText = "day:\n\n";
        string nightText = "night:\n\n";

        for(int i = 0;i < dayAttribute.attribute.Count;i++)
        {
            if(dayAttribute.attribute[i] != -1 && dayAttribute.attribute[i] != 0)
            {
               dayText = dayText + dayAttribute.GetAttrName(i) + ":" + dayAttribute.attribute[i] + "\n\n\n";
            }
        }
        for (int i = 0; i < nightAttribute.attribute.Count; i++)
        {
            if (nightAttribute.attribute[i] != -1 && nightAttribute.attribute[i] != 0)
            {
                nightText = nightText + nightAttribute.GetAttrName(i) + ":" + nightAttribute.attribute[i] + "\n\n\n";
            }
        }

        dayAttrShow.text = dayText;
        nightAttrShow.text = nightText;
    }

}
