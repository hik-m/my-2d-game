using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHit : MonoBehaviour
{
    HitRange hitRange;
    public bool beHItted;
    BoxCollider2D BoxCollider2D;
    public GameObject hit;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        hitRange = hit.GetComponent<HitRange>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("HitRange") && !beHItted)
        {
            if (hitRange.isAttacking)
            {
                beHItted = true;
                enemy.TakeDamage(hitRange.attackDamage); // 데미지 적용
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HitRange"))
        {
            beHItted = false; // 피격 상태 해제
        }
    }
}
