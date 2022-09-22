using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        SetStats(_player.GetComponent<PlayerController>());
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        if(_player.transform.position.x <= transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }  
    new public void  SetStats(PlayerController player)
    {

        health = player.Health + 15;
        if(player.Strength < 0)
            strength = 15;
        else
            strength = player.Strength + 15;

        if(player.Defense < 0)
            defense = 15;
        else
            defense = player.Defense + 15;

        if(player.Speed < 0)
            speed = 15;
        else
            speed = player.Speed + 15;

        if(player.Astuteness < 0)
            astuteness = 15;
        else
            astuteness = player.Astuteness + 15;

        if(player.Luck < 15)
            luck = 15;
        else
            luck = player.Luck + 15;

        Debug.Log(strength + " "+ defense +" "+ speed +" "+ astuteness +" "+ luck );
        
    }
    new public void RemoveEnemy()
    {
        Destroy(this.gameObject);
        if(_gamemanager.stage ==  GameStage.FirstStage)
            _gamemanager.UpdateGameStage(GameStage.SecondStage);
        else if(_gamemanager.stage ==  GameStage.SecondStage)
            _gamemanager.UpdateGameStage(GameStage.ThirdStage);


    }
}
 


