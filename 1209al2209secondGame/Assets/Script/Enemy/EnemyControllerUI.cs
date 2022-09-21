using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerUI : MonoBehaviour
{
    
    protected GameManager _gamemanager;
    protected UIManager _uIManager;

    int old;
    Color baseColor = Color.white;
    public int Strength{
        set
        {
            old = strength;
            strength = value;
            _uIManager.strength.text = strength.ToString();
            
        }
        get{ return strength;}
    }
    public int Defense{
        set{
            defense = value;
            _uIManager.defense.text = defense.ToString();
        }
        get{ return defense;}
    }    
    public int Luck{
        set{
            luck = value;
            _uIManager.luck.text = luck.ToString();
        }
        get{ return luck;}
    }     
    public int Astuteness
    {
        set{
            astuteness = value;
            _uIManager.astuteness.text = speed.ToString();
        }
        get{return astuteness;}        
    }
    public int Speed{
        set{
            speed = value;
            _uIManager.speed.text = speed.ToString();
        }
        get{return speed;}
    }
    public int Health{
        set{
            health = value;
            _uIManager.health.text = health.ToString();
        }
        get{return health;}
    }

    protected int astuteness = 1;
    protected int speed = 1;
    protected int luck = 0;
    protected int health = 5;
    protected int defense = 1;
    protected int strength = 1;
}
