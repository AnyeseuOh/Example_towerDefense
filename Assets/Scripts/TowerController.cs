using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public int attackPower;
    public float attackCurTime;
    public float attackSpeed;
    public GameObject targetEnemy;
    public GameObject bulletPrefab;
    public GameObject muzzleEffect;

    public enum TOWERSTATE
    {
        IDLE=0,
        ATTACK,
        UPGRADING,
        NONE
    }

    public TOWERSTATE towerState;
    public EnemyDetecting enemyDetecting;

    void Start()
    {
        towerState = TOWERSTATE.IDLE;
        enemyDetecting = GetComponentInChildren<EnemyDetecting>();
    }

    
    void Update()
    {
        switch (towerState)
        {
            case TOWERSTATE.IDLE:
                if (enemyDetecting.enemies.Count > 0 && targetEnemy != null) //적감지 리스트가 비지 않았다면
                {
                    targetEnemy = enemyDetecting.enemies[0]; //가장 앞의 enemy를 공격
                    towerState = TOWERSTATE.ATTACK;
                }
                break;
            case TOWERSTATE.ATTACK:
                if (targetEnemy != null) //적감지 리스트가 비지 않았다면
                {
                    transform.LookAt(targetEnemy.transform);
                    Vector3 dir = transform.localRotation.eulerAngles; //현재 각도를 벡터 오일러로 바꾼다
                    dir.x = 0; // x를 0으로 만들어서 고정시킨다
                    transform.localRotation = Quaternion.Euler(dir); // 쿼터니언 오일러로 바꿔준다.
                    attackCurTime += Time.deltaTime;
                    if(attackCurTime > attackSpeed)
                    {
                        Debug.Log("Attack!");
                        attackCurTime = 0;
                        GameObject bullet = Instantiate(bulletPrefab); //공격시 총알 생성
                        bullet.transform.position = transform.position;
                        bullet.GetComponent<BulletController>().target = targetEnemy;
                        bullet.GetComponent<BulletController>().bulletDamage = attackPower;
                    }
                }
                else
                {
                    attackCurTime = 0;
                    towerState = TOWERSTATE.IDLE;
                }
                break;
            case TOWERSTATE.UPGRADING:
                break;
            case TOWERSTATE.NONE:
                break;
        }
    }
}