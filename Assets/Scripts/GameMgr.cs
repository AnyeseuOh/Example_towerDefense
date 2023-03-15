using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public int curLv = 1;
    public int curEnemyHp = 100;
    public float curEnemySpeed = 1f;
    public int stageEnemyCnt = 2;
    public int killCnt = 0;



    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void StageLvUp()
    {
        curEnemyHp *= 2;
        curEnemySpeed *= 1.1f;
        stageEnemyCnt *= 2;
    }
}
