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

    public List<TextMeshProUGUI> dayAttrShowList;
    public List<TextMeshProUGUI> nightAttrShowList;



    private void Update()
    {
        showAttr();
    }
    public void showAttr()
    {
        //string dayText = "day:\n\n";
        //string nightText = "night:\n\n";

        //dayAttribute.attribute[0]
        for (int i = 0;i < dayAttribute.attribute.Count;i++)
        {
            if(dayAttribute.attribute[i] != -1 && dayAttribute.attribute[i] != 0)
            {
                dayAttrShowList[i].transform.parent.gameObject.SetActive(true);
                dayAttrShowList[i].text = dayAttribute.attribute[i] <= 99 ? dayAttribute.attribute[i].ToString() : "99";
               //dayText = dayText + dayAttribute.GetAttrName(i) + ":" + dayAttribute.attribute[i] + "\n\n\n";
            }
        }
        for (int i = 0; i < nightAttribute.attribute.Count; i++)
        {
            if (nightAttribute.attribute[i] != -1 && nightAttribute.attribute[i] != 0)
            {
                nightAttrShowList[i].transform.parent.gameObject.SetActive(true);
                nightAttrShowList[i].text = nightAttribute.attribute[i] <=99 ? nightAttribute.attribute[i].ToString() : "99";
                //nightText = nightText + nightAttribute.GetAttrName(i) + ":" + nightAttribute.attribute[i] + "\n\n\n";
            }
        }
    }

}
