using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceForBattle : MonoBehaviour, Searchable
{
    GameBoardController _gameboard;
    PlayerController _playerController;
    GameObject _player;
    private SpriteRenderer spriteRenderer;
    //! Graphic stuff
    [SerializeField] Sprite [] WinOrLosediceFaces;
    [SerializeField] Sprite [] neutralDiceFaces;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();            
        spriteRenderer.sprite = neutralDiceFaces[0];//1
        spriteRenderer.enabled = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameboard = GameObject.Find("GameBoard").GetComponent<GameBoardController>();
      
    }
    private void Update()
    {
        transform.position = new Vector2(_player.transform.position.x,_player.transform.position.y - 0.8f);    
    }

    public void Duel(Collider2D other)
    {
        spriteRenderer.enabled = true;
        PlayerController player = _player.GetComponent<PlayerController>();
        Debug.Log("becco un nemico");
        EnemyController enemy = other.GetComponent<EnemyController>();
        StartCoroutine(RollDiceRandomBattle(player,enemy));
        StartCoroutine(WaitForDisableSprite());

    }

    /// <summary>
    /// Disattivo lo spriterednere dopo 5 secondi dal duello
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForDisableSprite()
    {
        yield return new WaitForSeconds(4.0f);
        spriteRenderer.enabled = false;
    }

    private void StealAbility(PlayerController player, EnemyController enemy)
    {
        int stealRandomValue = Random.Range(0,5);
        switch (stealRandomValue)
        {
            case 0:
                player.Strength +=enemy.Strength;
                enemy.Strength = 0;
            break;            
            case 1:
                player.Defense +=enemy.Defense;
                enemy.Defense = 0;
            break; 
            case 2:
                player.Speed +=enemy.Speed;
                enemy.Speed = 0;
            break;  
            case 3:
                player.Luck +=enemy.Luck;
                enemy.Luck = 0;
            break;
            case 4:
                player.Astuteness+=enemy.Astuteness;
                enemy.Astuteness = 0;
            break;                                             
        }
        
    }

    // Update is called once per frame


    private IEnumerator RollDiceRandomBattle(PlayerController player, EnemyController enemy)
    {
        int randomTypeBattle = 0;
        for (int i = 0; i < 25; i++)
        {
            randomTypeBattle = Random.Range(0,100);
            if(randomTypeBattle <= 25)
                 randomTypeBattle = 0;
            else if(randomTypeBattle > 25 && randomTypeBattle <= 50) 
                randomTypeBattle = 1;
            else if(randomTypeBattle > 50 && randomTypeBattle <= 75) 
                randomTypeBattle = 2;
            else if(randomTypeBattle > 75 && randomTypeBattle <= 90) 
                randomTypeBattle = 3;
            else
                randomTypeBattle = 4;            

            spriteRenderer.sprite = neutralDiceFaces[randomTypeBattle];
            yield return new WaitForSeconds(0.05f);

        }
        switch (randomTypeBattle)
        {
            case 0://attacco
                if (enemy.Strength >= player.Strength)
                {
                    player.Health -= (enemy.Strength - player.Strength);
                    spriteRenderer.sprite = WinOrLosediceFaces[0];
                }
                else
                {
                    enemy.Health -= (player.Strength - enemy.Strength);
                    spriteRenderer.sprite = WinOrLosediceFaces[1];

                }
                break;
            case 1://difesa
                if (enemy.Strength >= player.Defense)
                {
                    player.Health -= (enemy.Strength - player.Defense);
                    spriteRenderer.sprite = WinOrLosediceFaces[2];

                }
                else
                {
                    enemy.Health -= (player.Defense - enemy.Defense);
                    spriteRenderer.sprite = WinOrLosediceFaces[3];

                }
                break;
            case 2://speed
                if (enemy.Speed >= player.Speed)
                {
                    spriteRenderer.sprite = WinOrLosediceFaces[4];

                    player.Strength -= 1;
                    player.Defense -= 1;
                    player.Speed -= 1;
                }
                else
                {
                    spriteRenderer.sprite = WinOrLosediceFaces[5];
                    player.CanMove = true;
                }
                break;
            case 3://astuzioa          
                if (enemy.Astuteness >= player.Astuteness)
                {
                    spriteRenderer.sprite = WinOrLosediceFaces[6];
                    
                    player.Astuteness -= player.Astuteness / 2;
                }
                else
                {
                    spriteRenderer.sprite = WinOrLosediceFaces[7];
                    StealAbility(player, enemy);
                }

                break;
            case 4://Luck
                
                break;
        }
    }

    public void SearchObject()
    {
        _gameboard = GameObject.Find("GameBoard").GetComponent<GameBoardController>();
        Debug.Log(_gameboard);

    }
}
