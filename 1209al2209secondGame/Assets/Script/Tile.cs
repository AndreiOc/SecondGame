using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Tile: MonoBehaviour
{

    private int x;
    public int X
    {
        set{x = value;}
        get{return x;}
    }
    private int y;
    public int Y
    {
        set{y = value;}
        get{return y;}
    }


    public int ValDice
    {
        set{valDice = value;}
        get{return valDice;}
    }
    public bool isConsumed = false;

    [SerializeField]protected EnemyController enemy;
    [SerializeField] Sprite highLightSprite;
    [SerializeField] Sprite consumedSprite;
    [SerializeField] Sprite enemyTileSprite;
    [SerializeField]protected int valDice;
    protected Sprite diceSprite;
    protected SpriteRenderer spriteRenderer;
    //mi serve per poi definire tutto
    private BoxCollider2D bc2D;
    protected GameManager _gamemanager;
    protected PlayerController _playerController;
    protected GameBoardController _gameboardController;


    private void Start()
    {
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameboardController = GameObject.FindGameObjectWithTag("Board").GetComponent<GameBoardController>();
        bc2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        diceSprite = spriteRenderer.sprite;

        transform.tag = "None";
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }
    /// <summary>
    /// Verifica inserita per evitare che il giocatore vadi sopra la tile
    /// </summary>
    public void HighLight()
    {
            spriteRenderer.sprite = highLightSprite;
            transform.tag = "HighLight";
        
    }
    public void RemoveHighLight()
    {
        spriteRenderer.sprite = diceSprite;
        transform.tag = "None";

    }

    public void ConsumedTile(bool isEnemied = false)
    {
        if(!isEnemied)
            spriteRenderer.sprite = consumedSprite;
        else
            spriteRenderer.sprite = enemyTileSprite;
        isConsumed = true; 
    }
    public abstract void GetBuffOrDebuff();


}