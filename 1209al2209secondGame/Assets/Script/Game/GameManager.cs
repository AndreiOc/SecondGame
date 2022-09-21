using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    private PlayerController _playerController;
    private DiceController _diceController;
    public GameState state;
    public bool AreThereEnemy = false;
    List<EnemyController>_enemyControllers = new List<EnemyController>();




    [SerializeField] private GameObject _gameboard;
    GameObject firstStage;
    GameObject secondStage;
    GameObject thirdStage;
    GameObject bossStage;
    [SerializeField] private GameObject _diceGame;
    GameObject diceGame;
    [SerializeField]private GameObject _diceForBattle;
    GameObject diceForBattle;
    [SerializeField]private GameObject _player;
    GameObject player;

    [SerializeField] GameObject cameraObject;
    
    /// <summary>
    /// 
    /// 
    /// 
    /// </summary>
    private void Awake()
    {
        instance = this;
        firstStage = Instantiate(_gameboard,Vector3.zero,Quaternion.identity);
        firstStage.name = "GameBoard";
        
        Tile positionPlayer = firstStage.GetComponent<GameBoardController>().tiles.Find(val => val.ValDice == 1);
        player = Instantiate(_player,new Vector3(positionPlayer.X,positionPlayer.Y + 0.8f,0),Quaternion.identity);
        player.name = "Player";

        diceGame = Instantiate(_diceGame,new Vector3(16.5f,9f,0f),Quaternion.identity);
        diceGame.name = "Dice";

        diceForBattle = Instantiate(_diceForBattle,Vector3.zero,Quaternion.identity);
        diceForBattle.name = "DiceForBattle";
    }
        
    private void Start()
    {
        _diceController = GameObject.FindGameObjectWithTag("Dice").GetComponent<DiceController>();
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void UpdateState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.DiceThrownState:
            _diceController.CanIThrown = true;
            break;
            case GameState.PlayerTurn:
            _playerController.CanMove = true;
            break;
        }
    }

    public void EnemyIsSpawn()
    {
        Debug.Log("Todo");
    }

    public void ChangeStage()
    {
        DestroyImmediate(firstStage);
        secondStage = Instantiate(_gameboard, new Vector3(0,0,0),Quaternion.identity);
        secondStage.transform.position = new Vector3(30,0,0);
        foreach (var item in secondStage.GetComponent<GameBoardController>().tiles)
        {
            item.X +=30;
        }

        secondStage.name = "GameBoard";
        
        Tile positionPlayer = secondStage.GetComponent<GameBoardController>().tiles.Find(val => val.ValDice == 1);
        player.transform.position = new Vector2(positionPlayer.X,positionPlayer.Y + 0.8f);
        player.GetComponent<PlayerController>().SearchObject();
        diceGame.GetComponent<DiceController>().SearchObject();
        diceForBattle.GetComponent<DiceForBattle>().SearchObject();

        cameraObject.transform.position = new Vector3(36.5f,4.5f,-10);
        diceGame.transform.position = new Vector3(46f,9f,0);
    }
}
public enum GameState
{
    DiceThrownState,
    PlayerTurn,
    EnemyTurn
}
