using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTwoScript : Tile
{

    public override void GetBuffOrDebuff()
    {
        int randomChoose = Random.Range(0,100);
        if(randomChoose < 30)
        {
            Debug.Log("Nothing");
        }
        else if(randomChoose>= 30 && randomChoose<60)
        {
            _gameboardController.SpawnEnemy(valDice);
            _gamemanager.EnemyIsSpawn();//informo il gamemanager della presenza di un mostro
        }
        else if(randomChoose>= 60 && randomChoose < 80)
        {
            int randoBuffOrDebuff = Random.Range(0,8);
            switch (randoBuffOrDebuff)
            {
                case 0:
                    _playerController.Strength+=2;
                break;
                case 1:
                    _playerController.Defense+=2;
                break;
                case 2:
                    _playerController.Astuteness+=2;
                break;
                case 3:
                    _playerController.Speed+=2;
                break;
                case 4:
                    _playerController.Strength-=2;
                break;
                case 5:
                    _playerController.Defense-=2;
                break;
                case 6:
                    _playerController.Astuteness-=2;
                break;
                case 7:
                    _playerController.Speed-=2;
                break;

            }
 
        }
        else if(randomChoose>= 80 && randomChoose < 90) 
        {
            for (int i = 0; i < 2; i++)
            {
                int randoBuffOrDebuff = Random.Range(0,4);
                switch (randoBuffOrDebuff)
                {
                    case 0:
                        _playerController.Strength-=2;
                    break;
                    case 1:
                        _playerController.Defense-=2;
                    break;
                    case 2:
                        _playerController.Astuteness-=2;
                    break;
                    case 3:
                        _playerController.Speed-=2;
                    break;
                }                
            }            
        }
        else if(randomChoose>= 90 && randomChoose < 97)
        {
            _playerController.Health +=2;
        } 
        else
        {
            for (int i = 0; i < 2; i++)
            {
                int randoBuffOrDebuff = Random.Range(0,4);
                switch (randoBuffOrDebuff)
                {
                    case 0:
                        _playerController.Strength+=2;
                    break;
                    case 1:
                        _playerController.Defense+=2;
                    break;
                    case 2:
                        _playerController.Astuteness+=2;
                    break;
                    case 3:
                        _playerController.Speed+=2;
                    break;
                }                
            }
        }
    }    
}
