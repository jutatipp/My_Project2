using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    private bool canTakeDamage = true;
    public bool playerIsAlive = true;
    public Logic logic;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        anim = GetComponentInParent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
        {
            return;
        }

        health -= damage;
        anim.SetBool("Damage", true);
        if (health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("You noob");
            playerIsAlive = false;
            logic.gameOver();
        }
        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }
}
