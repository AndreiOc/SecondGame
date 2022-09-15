using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceOneScript : Tile
{
    public override void GetBuffOrDebuff()
    {
        int randomChoose = Random.Range(0,100);
        if(randomChoose < 70)
        {
            Debug.Log("Nothing");
        }
        else if(randomChoose>= 70 && randomChoose<90)
        {
            _player.GetComponent<PlayerController>().Attack -= 1;
        }
        else 
        {
            _player.GetComponent<PlayerController>().Attack += 1;

        }
    }

}
