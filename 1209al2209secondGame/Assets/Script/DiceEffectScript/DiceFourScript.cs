using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFourScript : Tile
{
    public override void GetBuffOrDebuff()
    {
        int randomChoose = Random.Range(0,100);
        if(randomChoose < 10)
        {
            Debug.Log("Nothing");
        }
        else if(randomChoose>= 10 && randomChoose<15)
        {
            _playerController.Health +=2;
        }
        else if(randomChoose>= 15 && randomChoose<20)
        {
            _playerController.Health -=4;

        }
        else if(randomChoose>= 20 && randomChoose<40)
        {
            _gameboardController.SpawnEnemy(valDice);
            _gamemanager.EnemyIsSpawn();//informo il gamemanager della presenza di un mostro
        }
        else if(randomChoose>= 40 && randomChoose<50)
        {
            Debug.Log("Strong enemt");
        }   
        else if(randomChoose>= 50 && randomChoose < 65)
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
        else if(randomChoose>= 65 && randomChoose < 70) 
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
        else if(randomChoose>= 70 && randomChoose < 90)
        {
            for (int i = 0; i < 5; i++)
            {
	           int randoBuffOrDebuff = Random.Range(0,8);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength+=4;
	                break;
	                case 1:
	                    _playerController.Defense+=4;
	                break;
	                case 2:
	                    _playerController.Astuteness+=4;
	                break;
	                case 3:
	                    _playerController.Speed+=4;
	                break;
	                case 4:
	                    _playerController.Strength-=4;
	                break;
	                case 5:
	                    _playerController.Defense-=4;
	                break;
	                case 6:
	                    _playerController.Astuteness-=4;
	                break;
	                case 7:
	                    _playerController.Speed-=4;
	                break;
	
	            }        
    
            }
        } 
        else
        {
            for (int i = 0; i < 3; i++)
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
