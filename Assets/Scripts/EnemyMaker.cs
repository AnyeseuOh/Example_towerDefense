using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime = 2f;
    public int enemyCnt = 0;
    public int enemyMaxCnt = 0;

    public GameMgr gameMgr;

    public bool isRunning = false;
    
    void Start()
    {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameMgr>();
        isRunning = true;
    }

    
    void Update()
    {

        if (enemyCnt > enemyMaxCnt)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = transform.position;
                enemy.name = "Enemy_" + enemyCnt;
                enemy.GetComponent<EnemyController>().enemyHp = gameMgr.curEnemyHp;
                enemy.GetComponent<EnemyController>().moveSpeed = gameMgr.curEnemySpeed;
                enemyMaxCnt = gameMgr.stageEnemyCnt;
                enemyCnt++;
            }
        }
    }

    public void InitEnemyMaker()
    {
        enemyCnt = 0;
        isRunning = true;
        gameMgr.curLv++;
        gameMgr.StageLvUp();
    }
}
