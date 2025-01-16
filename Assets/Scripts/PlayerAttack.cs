using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float reload;
    public float startreload;
    public Transform attackpos;
    public LayerMask enemy;
    public float attackrange;
    public int damage;



    void Start()
    {
        
    }

    
    void Update()
    {
        if (reload <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackpos.position, attackrange, enemy);
                for (int i = 0;i<enemies.Length;i++)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                    reload = startreload;
                }
            }
        }
        else
        {
            reload -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position,attackrange);
    }

}
