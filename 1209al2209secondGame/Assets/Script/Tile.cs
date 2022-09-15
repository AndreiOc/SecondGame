using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Tile: MonoBehaviour
{


    protected GameObject _player;

    private int x;
    public int X{
        set{x = value;}
        get{return x;}
    }
    private int y;
    public int Y{
        set{y = value;}
        get{return y;}
    }


    public int ValDice{
        set{valDice = value;}
        get{return valDice;}
    }
    
    [SerializeField] Sprite highLight;
    [SerializeField]private int valDice;
    private Sprite diceSprite;
    private SpriteRenderer spriteRenderer;
    //mi serve per poi definire tutto
    private BoxCollider2D bc2D;
    private void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        diceSprite = spriteRenderer.sprite;

        transform.tag = "None";
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void HighLight()
    {
        spriteRenderer.sprite = highLight;    
        transform.tag = "HighLight";
    }
    public void RemoveHighLight()
    {
        spriteRenderer.sprite = diceSprite;
        transform.tag = "None";

    }
    public abstract void GetBuffOrDebuff();
    
}