using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControl playerMoveControl;
    private GatherInput gatherInput;
    private Animator animator;

    public bool attackStart = false;
    public PolygonCollider2D attackCollider;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveControl = GetComponent<PlayerMoveControl>();
        animator = GetComponent<Animator>();
        gatherInput = GetComponent<GatherInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (gatherInput.tryAttack)
        {
            animator.SetBool("Attack", true);
            attackStart = true;
        }
    }

    public void ResetAttack()
    {
        animator.SetBool("Attack", false);
        gatherInput.tryAttack = false;
        attackStart = false;
        attackCollider.enabled = false;
        Debug.Log("Attack Finish");
    }

    public void ActivateAttack()
    {
        attackCollider.enabled = true;
        audioSource.Play();
    }

}
