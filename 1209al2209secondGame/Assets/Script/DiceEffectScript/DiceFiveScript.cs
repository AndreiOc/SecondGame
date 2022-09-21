using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFiveScript : Tile
{
    public override void GetBuffOrDebuff()
    {
        int randomChoose = Random.Range(0,100);
        if(randomChoose < 5)
        {
            Debug.Log("Nothing");
        }
        else if(randomChoose>= 5 && randomChoose<7)
        {
            _playerController.Health +=5;
            _playerController.Speed +=5;
            _playerController.Strength +=5;
            _playerController.Astuteness +=5;
            _playerController.Luck +=5;
            _playerController.Defense +=5;
            
        
        }
        /// <summary>
        /// Spawn double enemt
        /// </summary>
        /// <param name="randomChoose<15"></param>
        /// <returns></returns>
        else if(randomChoose>= 7 && randomChoose<15)
        {
            _gameboardController.SpawnEnemy(valDice);
            _gameboardController.SpawnEnemy(valDice);

        }
        else if(randomChoose>= 15 && randomChoose<30)
        {
            Debug.Log("Strong enemy");
        }
        else if(randomChoose>= 30 && randomChoose<40)
        {
            Debug.Log("Strong enemt");
        }   
        else if(randomChoose>= 30 && randomChoose<40)
        {
            _gameboardController.SpawnEnemy(valDice);

            Debug.Log("Strong enemt");
        }   
        else if(randomChoose>= 40 && randomChoose<55)
        {
            Debug.Log("TODO TRA IL 40 E IL 55");
        }   
        else if(randomChoose>= 55 && randomChoose < 65)
        {
            for (int i = 0; i < 4; i++)
            {
	            int randoBuffOrDebuff = Random.Range(0,4);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength+=5;
	                break;
	                case 1:
	                    _playerController.Defense+=5;
	                break;
	                case 2:
	                    _playerController.Astuteness+=5;
	                break;
	                case 3:
	                    _playerController.Speed+=5;
	                break;

	
	            }
            }
 
        }
        else if(randomChoose>= 65 && randomChoose < 70) 
        {
            for (int i = 0; i < 4; i++)
            {
	            int randoBuffOrDebuff = Random.Range(0,4);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength-=5;
	                break;
	                case 1:
	                    _playerController.Defense-=5;
	                break;
	                case 2:
	                    _playerController.Astuteness-=5;
	                break;
	                case 3:
	                    _playerController.Speed-=5;
	                break;

	
	            }
            }
        }
        else if(randomChoose>= 70 && randomChoose < 90)
        {
            Debug.Log("Da rifare");
            for (int i = 0; i < 10; i++)
            {
	           int randoBuffOrDebuff = Random.Range(0,8);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength+=5;
	                break;
	                case 1:
	                    _playerController.Defense+=5;
	                break;
	                case 2:
	                    _playerController.Astuteness+=5;
	                break;
	                case 3:
	                    _playerController.Speed+=5;
	                break;
	                case 4:
	                    _playerController.Strength-=5;
	                break;
	                case 5:
	                    _playerController.Defense-=5;
	                break;
	                case 6:
	                    _playerController.Astuteness-=5;
	                break;
	                case 7:
	                    _playerController.Speed-=5;
	                break;
	
	            }        
    
            }
        } 
        else if(randomChoose>= 90 && randomChoose < 95) 
        {
            for (int i = 0; i < 3; i++)
            {
	            int randoBuffOrDebuff = Random.Range(0,4);
	            switch (randoBuffOrDebuff)
	            {
	                case 0:
	                    _playerController.Strength+=5;
	                break;
	                case 1:
	                    _playerController.Defense+=5;
	                break;
	                case 2:
	                    _playerController.Astuteness+=5;
	                break;
	                case 3:
	                    _playerController.Speed+=5;
	                break;

	
	            }
            }        
		}
		else 
		{
			Debug.Log("something between 95 and 100");
		}
             
    
    }
}
