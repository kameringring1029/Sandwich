using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    private GameObject[] Slots = new GameObject[3];
    private GameObject[] IconNames = new GameObject[3];

    public Sprite[] icons;
    public string[] iconname;

    public bool[] routeFlg = new bool[3];
    private string[] finIconName = new string[3];


    // Use this for initialization
    void Start() { 
        Slots[0] = GameObject.Find("Slot1");
        Slots[1] = GameObject.Find("Slot2");
        Slots[2] = GameObject.Find("Slot3");
        IconNames[0] = GameObject.Find("Text1");
        IconNames[1] = GameObject.Find("Text2");
        IconNames[2] = GameObject.Find("Text3");

        routeFlg[0] = false;
        routeFlg[1] = false;
        routeFlg[2] = false;
        finIconName[0] = "";
        finIconName[1] = "";
        finIconName[2] = "";

        StartCoroutine(SlotRoutation(0));
        StartCoroutine(SlotRoutation(1));
        StartCoroutine(SlotRoutation(2));
    }
	
	// Update is called once per frame
	void Update () {

        // 全スロットが止まったら
        if(routeFlg[0] == true && routeFlg[1] == true && routeFlg[2] == true)
        {
            if(finIconName[0] == "ビーチ" && finIconName[1] == "スケッチ" && finIconName[2] == "サクラウチ")
            {

                GameObject.Find("ResultText").GetComponent<Text>().text = "Sandwich";
            }
            else if(finIconName[0] == finIconName[1] && finIconName[1] ==  finIconName[2])
            {
                GameObject.Find("ResultText").GetComponent<Text>().text = finIconName[0];
            }
            else
            {

                GameObject.Find("ResultText").GetComponent<Text>().text = "Miss...";
            }

        }
		
	}

    private IEnumerator SlotRoutation(int slotid)
    {
        GameObject Slot = Slots[slotid];
        GameObject IconName = IconNames[slotid];
        int iconnum = slotid;

        while (routeFlg[slotid] == false)
        {
            Slot.GetComponent<Image>().sprite = icons[iconnum];
            IconName.GetComponent<Text>().text = iconname[iconnum];

            // 1秒毎にループします
            yield return new WaitForSeconds(0.15f + 0.02f * 1.0f/(1.0f+slotid));

            iconnum++;
            if(iconnum > icons.Length -1)
            {
                iconnum = 0;
            }
        }

        finIconName[slotid] = IconName.GetComponent<Text>().text;
    }
}
