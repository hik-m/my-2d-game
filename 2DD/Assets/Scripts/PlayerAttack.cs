using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    HitRange HitRange;
    public GameObject HIt;
    public float atk1;
    public float atk2;

    private int combo = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HitRange = HIt.GetComponent<HitRange>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (!HitRange.isAttacking) // isAttacking이 false일 때만 공격
        {
            StartCoroutine(Combo());
        }
    }

    IEnumerator Combo()
    {
        if (combo == 1)
        {
            anim.SetBool("Atk1", true);
            HitRange.isAttacking = true;
            HitRange.ApplyDamage(); // 데미지 적용
            yield return new WaitForSeconds(atk1);
            anim.SetBool("Atk1", false);
            HitRange.isAttacking = false;
        }
        else
        {
            anim.SetBool("Atk2", true);
            HitRange.isAttacking = true;
            HitRange.ApplyDamage(); // 데미지 적용
            yield return new WaitForSeconds(atk2);
            anim.SetBool("Atk2", false);
            HitRange.isAttacking = false;
        }

        combo = (combo + 1) % 2;
    }
}
