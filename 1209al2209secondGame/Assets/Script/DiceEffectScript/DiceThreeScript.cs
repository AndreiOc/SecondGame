using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThreeScript : Tile
{
    public override void GetBuffOrDebuff()
    {
 
        int randomChoose = Random.Range(0,100);
        if(randomChoose < 30)
        {
            Debug.Log("Nothing");
        }
        else if(randomChoose>= 30 && randomChoose<55)
        {
            _gameboardController.SpawnEnemy(valDice);
            _gamemanager.EnemyIsSpawn();//informo il gamemanager della presenza di un mostro
        }
        else if(randomChoose>= 55 && randomChoose < 65)
        {
            for (int i = 0; i < 2; i++)
            {
	            int randoBuffOrDebuff = Random.Range(0,4);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength+=3;
	                break;
	                case 1:
	                    _playerController.Defense+=3;
	                break;
	                case 2:
	                    _playerController.Astuteness+=3;
	                break;
	                case 3:
	                    _playerController.Speed+=3;
	                break;

	
	            }
            }
 
        }
        else if(randomChoose>= 65 && randomChoose < 70) 
        {
            Debug.Log("StrongEnemy");
        }
        else if(randomChoose>= 70 && randomChoose < 90)
        {
            for (int i = 0; i < 3; i++)
            {
	           int randoBuffOrDebuff = Random.Range(0,8);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength+=3;
	                break;
	                case 1:
	                    _playerController.Defense+=3;
	                break;
	                case 2:
	                    _playerController.Astuteness+=3;
	                break;
	                case 3:
	                    _playerController.Speed+=3;
	                break;
	                case 4:
	                    _playerController.Strength-=3;
	                break;
	                case 5:
	                    _playerController.Defense-=3;
	                break;
	                case 6:
	                    _playerController.Astuteness-=3;
	                break;
	                case 7:
	                    _playerController.Speed-=3;
	                break;
	
	            }        
    
            }
        } 
        else if(randomChoose>= 90 && randomChoose < 95) 
        {
            _playerController.Health +=3;
        }
        else
        {
            _playerController.Health -=3;

        }
    }       
}
