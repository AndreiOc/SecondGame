using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private List<Tile>board = new List<Tile>();
    DiceForBattle diceForBattle;
    //!unità logiche con cui lavorare 


    /// <summary>
    /// Funzione che setta quando il giocatore può e non può muoversi
    /// </summary>
    /// <value></value>
    public bool CanMove{
        set{canMove = value;}
        get{return canMove;}
    }

    private bool canMove;
    private Camera currentCamera;
    GameBoardController gameBoardController;
    DiceController diceController;
    Vector2 desiredPosition;
    void Start()
    {
        diceForBattle =GameObject.Find("DIceForBattle").GetComponent<DiceForBattle>();
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        gameBoardController = GameObject.FindGameObjectWithTag("Board").GetComponent<GameBoardController>();
        diceController = GameObject.FindGameObjectWithTag("Dice").GetComponent<DiceController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //inizializzo i vari valori di attacco difesa e tutto 
        
        Health = 5;
        Speed = 1; 
        Defense = 1;
        Strength = 1;
        Luck = 1;
        
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public void Update()
    {
       if(!currentCamera){
            currentCamera = Camera.main;
            return;
        }
        if(canMove)
        {
            diceController.CanIThrown = false;
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);        
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("HighLight"))
                {
                    int x = hit.collider.GetComponent<Tile>().X;
                    int y = hit.collider.GetComponent<Tile>().Y;
                    desiredPosition = new Vector2(x,y  + 0.8f);
                    if(Input.GetMouseButtonDown(0))
                    {
                        int currentX = (int)desiredPosition.x;
                        int currentY = (int)desiredPosition.y;
                        if(transform.position.x > currentX)
                            spriteRenderer.flipX = true;
                        else
                            spriteRenderer.flipX = false;                        
                         
                        TakeBuffOrDebuff(hit.collider.gameObject);
                        gameBoardController.GetComponent<GameBoardController>().RemoveFromList(currentX,currentY);
                        transform.position =desiredPosition;

                        canMove = false;
                        _gamemanager.UpdateState(GameState.DiceThrownState);
                    }
                }
                else if(hit.collider.CompareTag("Enemy"))
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        diceForBattle.GetComponent<DiceForBattle>().Duel(hit.collider);
                        canMove = false;
                        _gamemanager.UpdateState(GameState.DiceThrownState);
                    }
                }
            }  
        }

        if(Input.GetKeyDown("space"))
        {
            Debug.Log("CAMBIO CAMPO PER TEST");
        }
    }
    /// <summary>
    /// Funzione che lancia i singoli script dei dadi da potere poi 
    /// definire il tipo di bonus che ricevo
    /// </summary>
    /// <param name="diceTile">Valore del dado colliso</param>
    private void TakeBuffOrDebuff(GameObject diceTile)
    {
        int diceValue = diceTile.GetComponent<Tile>().ValDice;
        if(diceValue == 1)
            diceTile.GetComponent<DiceOneScript>().GetBuffOrDebuff();
        else if(diceValue == 2)
            diceTile.GetComponent<DiceTwoScript>().GetBuffOrDebuff();
        else if(diceValue == 3)
            diceTile.GetComponent<DiceThreeScript>().GetBuffOrDebuff();
        else if(diceValue == 4)
            diceTile.GetComponent<DiceFourScript>().GetBuffOrDebuff();
        else if(diceValue == 5)
            diceTile.GetComponent<DiceFiveScript>().GetBuffOrDebuff();
        else
            diceTile.GetComponent<DiceSixScript>().GetBuffOrDebuff();
                                                

    }


}
