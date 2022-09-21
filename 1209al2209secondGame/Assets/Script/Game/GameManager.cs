using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    private PlayerController _playerController;
    private GameObject _gameBoard;
    private DiceController _diceController;
    public GameState state;
    public bool AreThereEnemy = false;
    List<EnemyController>_enemyControllers = new List<EnemyController>();

    private void Awake()
    {
        instance = this;
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

    }

    
}
public enum GameState
{
    DiceThrownState,
    PlayerTurn,
    EnemyTurn
}
