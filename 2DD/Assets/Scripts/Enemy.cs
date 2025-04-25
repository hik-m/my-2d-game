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
    public float invincibleCoolTime = 1f; // ���� �ð� ���� (1��)

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
        // ���� Ÿ�̸� ó��
        if (invincibleTimer > 0)
        {
            invincibleTimer -= Time.deltaTime; // ���� �ð� ����
        }

        if (MobHit.beHItted)
        {
            MobHit.beHItted = false;
            StartInvincible();
        }

        // (���⼭�� ������ �̵� ����, AI, �ൿ ���� ó��)
    }

    public void TakeDamage(int damage)
    {
        if (isDead || invincibleTimer > 0) return; // ���� ���̰ų� �̹� �׾����� �ǰ� X

        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {health}");

        if (health <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("Death");
            return;
        }

        // �ǰ� �� ���� �ð� ����
        StartInvincible();
    }

    void StartInvincible()
    {
        if (invincibleTimer > 0) return; // �̹� ���� ���¶�� ���� X

        invincibleTimer = invincibleCoolTime; // ���� �ð� ����
        anim.SetBool("BeHitted", true); // �ǰ� �ִϸ��̼� ����
        StartCoroutine(HitRecover());
    }

    IEnumerator HitRecover()
    {
        yield return new WaitForSeconds(invincibleCoolTime); // ���� �ð���ŭ ���
        anim.SetBool("BeHitted", false); // �ǰ� �ִϸ��̼� ����
    }
}
