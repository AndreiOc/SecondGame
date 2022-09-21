using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceOneScript : Tile
{

    
    public override void GetBuffOrDebuff()
    {
        int randomChoose = Random.Range(0,100);
        if(randomChoose < 30)
        {
            Debug.Log("Nothing");
        }
        else if(randomChoose>= 30 && randomChoose<80)
        {
            _gameboardController.SpawnEnemy(valDice);
            _gamemanager.EnemyIsSpawn();//informo il gamemanager della presenza di un mostro
        }
        else if(randomChoose>= 80 && randomChoose < 95)
        {
            int randoBuffOrDebuff = Random.Range(0,8);
            switch (randoBuffOrDebuff)
            {
                case 0:
                    _playerController.Strength+=1;
                break;
                case 1:
                    _playerController.Defense+=1;
                break;
                case 2:
                    _playerController.Astuteness+=1;
                break;
                case 3:
                    _playerController.Speed+=1;
                break;
                case 4:
                    _playerController.Strength-=1;
                break;
                case 5:
                    _playerController.Defense-=1;
                break;
                case 6:
                    _playerController.Astuteness-=1;
                break;
                case 7:
                    _playerController.Speed-=1;
                break;

            }
 
        }
        else
        {
            _playerController.Health -= 1;
        }
    }

}
