using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRange : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer spriteRen;
    public Vector2 pos;
    public bool isAttacking;

    private List<Enemy> enemiesInRange = new List<Enemy>();
    public int attackDamage = 10;

    void Start()
    {
        spriteRen = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 rangPos = pos;
        if (spriteRen.flipX == false)
        {
            rangPos.x = rangPos.x * -1;
        }

        transform.position = player.transform.position + rangPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }

    public void ApplyDamage()
    {
        if (isAttacking)
        {
            foreach (var enemy in enemiesInRange)
            {
                if (enemy != null)
                    enemy.TakeDamage(attackDamage);
            }
        }
    }
}
