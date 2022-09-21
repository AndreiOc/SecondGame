using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour, Searchable
{
    [SerializeField] Sprite [] diceFaces;
    GameObject _playeContoller;
    GameManager _gamemanager;
    GameBoardController _gameboard;
    PlayerController playerController;
    bool firstHighlight = true;
    private SpriteRenderer spriteRenderer;
    private bool coroutineAllowed = true;
    public bool isThrown = false; 
    private bool canIThrown = true;
    public bool CanIThrown
    {
        set{canIThrown = value;}
        get{return canIThrown;}
    }
    private void Start()
    {
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();            
        spriteRenderer.sprite = diceFaces[0];//1
        _playeContoller = GameObject.FindGameObjectWithTag("Player");
        _gameboard = GameObject.Find("GameBoard").GetComponent<GameBoardController>();


    }
    // Update is called once per frame
    private void Update()
    {
        if(canIThrown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(coroutineAllowed)
                {
                    StartCoroutine("RollDice");
                    isThrown = true;
                }
            }
        }
    }


    /// <summary>
    /// Come fare un routine a tempo
    /// </summary>
    /// <returns> valore del dado lanciato</returns>
    private IEnumerator RollDice()
    {
        isThrown = false;
        if(!firstHighlight)
            _gameboard.RemoveHighLights();

        coroutineAllowed = false;
        int randomDice = 0;
        for (int i = 0; i < 25; i++)
        {
            randomDice = Random.Range(0,100);

            if(randomDice <= 25)
                 randomDice = 1;
            else if(randomDice > 25 && randomDice <= 47) 
                randomDice = 2;
            else if(randomDice > 47 && randomDice <= 66) 
                randomDice = 3;
            else if(randomDice > 66 && randomDice <= 82) 
                randomDice = 4;
            else if(randomDice > 82 && randomDice <= 93) 
                randomDice = 5;
            else 
                randomDice = 6;
            spriteRenderer.sprite = diceFaces[randomDice -1];
            yield return new WaitForSeconds(0.05f);
        }
        coroutineAllowed = true;
        if(CheckValDice(randomDice))
        {
            _gameboard.HighLights(randomDice);
            canIThrown = false;
            _gamemanager.UpdateState(GameState.PlayerTurn);
        }
        else
        {
            canIThrown = true;
        }
        firstHighlight = false;
    }

    private bool CheckValDice(int randomDice)
    {
        for(int x = 0; x < 10; x ++)
        {
            for(int y = 0; y < 10; y ++)
            {
                if(_gameboard._valDiceArray[x,y] == randomDice)
                {
                    Debug.Log("valore presente");
                    return true;
                }
            }

        }
        Debug.Log("Valore non prensente");
        return false;
    }

    public void SearchObject()
    {
        _gameboard = GameObject.Find("GameBoard").GetComponent<GameBoardController>();
        Debug.Log(_gameboard);    
    }
}
