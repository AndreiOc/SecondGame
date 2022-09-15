using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private List<Tile>board = new List<Tile>();


    public int Attack{
        set{attack += value;}
        get{ return attack;}
    }
    private int attack = 1;
    public int Defense{
        set{defense += value;}
        get{ return defense;}
    }    
    private int defense = 1;
    public int Luck{
        set{luck += value;}
        get{ return luck;}
    }     
    private int luck = 0;
    private int health = 5;

    /// <summary>
    /// Funzione che setta quando il giocatore può e non può muoversi
    /// </summary>
    /// <value></value>
    public bool CanMove{
        set{canMove = value;}
        get{return canMove;}
    }

    private bool canMove = true;

    private Camera currentCamera;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!currentCamera){
            currentCamera = Camera.main;
            return;
        }
        if(canMove)
        {
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);        
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("HighLight"))
                {
                    int x = hit.collider.GetComponent<Tile>().X;
                    int y = hit.collider.GetComponent<Tile>().Y;
                    Vector2 desiredPosition = new Vector2(x,y);
                    if(Input.GetMouseButtonDown(0))
                    {
                        transform.position = desiredPosition;
                        canMove = false;
                        TakeBuffOrDebuff(hit.collider.gameObject);
                        Debug.Log(attack);

                    }
                }
            }  
        }
    }

    private void TakeBuffOrDebuff(GameObject diceTile)
    {
        int valTile = diceTile.GetComponent<Tile>().ValDice;
        if(valTile == 1)
        {
            diceTile.GetComponent<DiceOneScript>().GetBuffOrDebuff();
        }
    }

}
