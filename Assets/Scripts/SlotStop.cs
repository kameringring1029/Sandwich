using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotStop : MonoBehaviour {

    public int slotid;
    GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("Main Camera");
    }

    public void ButtonPush()
    {
        manager.GetComponent<GameMgr>().routeFlg[slotid] = true;
    }
}
