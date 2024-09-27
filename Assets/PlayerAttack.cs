using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public float attackDamage = 10f;
    private int enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

}
