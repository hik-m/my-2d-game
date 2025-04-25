using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    MobHit MobHit;

    public float speed;
    public float jumpPower;

    public int health = 100;
    public float invincibleTimer = 0f;
    public float invincibleCoolTime = 1f; // 무적 시간 설정 (1초)

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        MobHit = GetComponent<MobHit>();
    }

    // Update is called once per frame
    void Update()
    {
        // 무적 타이머 처리
        if (invincibleTimer > 0)
        {
            invincibleTimer -= Time.deltaTime; // 무적 시간 감소
        }

        if (MobHit.beHItted)
        {
            MobHit.beHItted = false;
            StartInvincible();
        }

        // (여기서는 나머지 이동 로직, AI, 행동 등을 처리)
    }

    public void TakeDamage(int damage)
    {
        if (isDead || invincibleTimer > 0) return; // 무적 중이거나 이미 죽었으면 피격 X

        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {health}");

        if (health <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("Death");
            return;
        }

        // 피격 시 무적 시간 시작
        StartInvincible();
    }

    void StartInvincible()
    {
        if (invincibleTimer > 0) return; // 이미 무적 상태라면 종료 X

        invincibleTimer = invincibleCoolTime; // 무적 시간 설정
        anim.SetBool("BeHitted", true); // 피격 애니메이션 시작
        StartCoroutine(HitRecover());
    }

    IEnumerator HitRecover()
    {
        yield return new WaitForSeconds(invincibleCoolTime); // 무적 시간만큼 대기
        anim.SetBool("BeHitted", false); // 피격 애니메이션 종료
    }
}
