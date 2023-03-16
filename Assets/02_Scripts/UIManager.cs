using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killCntText;
    public Text levelText;
    public GameMgr gameMgr;

    void Start()
    {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameMgr>();
    }

    
    void Update()
    {
        killCntText.text = "KILL : " + gameMgr.killCnt;
        levelText.text = "LV : " + gameMgr.curLv;
    }

    public void RangeOff()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Attack_Range");
        for (int i=0; i < objs.Length; i++)
        {
            objs[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
