using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    
    protected GameManager _gamemanager;

    int old;
    public int Strength{
        set
        {
            old = strength;
            strength = value;
            
        }
        get{ return strength;}
    }
    public int Defense{
        set{
            defense = value;
        }
        get{ return defense;}
    }    
    public int Luck{
        set{
            luck = value;
        }
        get{ return luck;}
    }     
    public int Astuteness
    {
        set{
            astuteness = value;
        }
        get{return astuteness;}        
    }
    public int Speed{
        set{
            speed = value;
        }
        get{return speed;}
    }
    public int Health{
        set{
            int oldHeath = health;
            health = value;
            if(health<oldHeath && health > 0)
                animator.SetInteger("animationState",(int)AnimationState.isTakingDamage);
            else 
                animator.SetInteger("animationState",(int)AnimationState.isDying);
        }
        get{return health;}
    }

    protected int astuteness = 1;
    protected int speed = 1;
    protected int luck = 0;
    protected int health = 5;
    protected int defense = 1;
    protected int strength = 1;

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected GameObject _player;
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        SetStats(_player.GetComponent<PlayerController>());
    }

    // Update is called once per frame
    void Update()
    {
        if(_player.transform.position.x <= transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
    
    public void AnimationReaction(AnimationState state)
    {
        animator.SetInteger("animationState",((int)state));
    }

    public void RemoveEnemy()
    {
        Destroy(this.gameObject);
    }

    public void SetStats(PlayerController player)
    {

        health = player.Health + 1;
        if(player.Strength < 0)
            strength = 1;
        else
            strength = player.Strength + 1;

        if(player.Defense < 0)
            defense = 1;
        else
            defense = player.Defense + 1;

        if(player.Speed < 0)
            speed = 1;
        else
            speed = player.Speed + 1;

        if(player.Astuteness < 0)
            astuteness = 1;
        else
            astuteness = player.Astuteness + 1;

        if(player.Luck < 1)
            luck = 1;
        else
            luck = player.Luck + 1;

        Debug.Log(strength + " "+ defense +" "+ speed +" "+ astuteness +" "+ luck );
        
    }

}
 

public enum AnimationState
{
    isIdleing,
    isAttacking,
    isRunning,
    isTakingDamage,
    isDying
}