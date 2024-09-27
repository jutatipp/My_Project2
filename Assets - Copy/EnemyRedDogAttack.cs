using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDogAttack : EnemyAttack
{
    PlayerMoveControl playerMoveControl;

    public float forceX;
    public float forceY;
    public float duration;

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        playerMoveControl = playerStats.GetComponentInParent<PlayerMoveControl>();
        StartCoroutine(playerMoveControl.KnockBack(forceX, forceY, duration, transform));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
