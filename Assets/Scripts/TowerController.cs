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
    public Animator anim;

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
                if (enemyDetecting.enemies.Count > 0 && targetEnemy != null) //������ ����Ʈ�� ���� �ʾҴٸ�
                {
                    targetEnemy = enemyDetecting.enemies[0]; //���� ���� enemy�� ����
                    towerState = TOWERSTATE.ATTACK;
                }
                break;
            case TOWERSTATE.ATTACK:
                if (targetEnemy != null) //������ ����Ʈ�� ���� �ʾҴٸ�
                {
                    transform.LookAt(targetEnemy.transform);
                    Vector3 dir = transform.localRotation.eulerAngles; //���� ������ ���� ���Ϸ��� �ٲ۴�
                    dir.x = 0; // x�� 0���� ���� ������Ų��
                    transform.localRotation = Quaternion.Euler(dir); // ���ʹϾ� ���Ϸ��� �ٲ��ش�.
                    attackCurTime += Time.deltaTime;
                    if(attackCurTime > attackSpeed)
                    {
                        Debug.Log("Attack!");
                        attackCurTime = 0;
                        GameObject bullet = Instantiate(bulletPrefab); //���ݽ� �Ѿ� ����
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
                /*
                 * ToDo
                 * 1. ���׷��̵� �߿� �ִϸ��̼� ���
                 * 2. ���ݷ� / �ӵ� / ���� ���� ����
                 */
                break;
            case TOWERSTATE.NONE:
                break;
        }
    }
}