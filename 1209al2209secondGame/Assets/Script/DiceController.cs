using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] Sprite [] diceFaces;
    GameObject _playeContoller;
    bool firstHighlight = true;
    [SerializeField] private GameObject _boardGame;
    private SpriteRenderer spriteRenderer;
    private bool coroutineAllowed = true;
    

    private void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();            
        spriteRenderer.sprite = diceFaces[0];//1
        _playeContoller = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if(coroutineAllowed)
            StartCoroutine("RollDice");
    }

    /// <summary>
    /// Come fare un routine a tempo
    /// </summary>
    /// <returns> valore del dado lanciato</returns>
    private IEnumerator RollDice()
    {
        if(!firstHighlight)
            _boardGame.GetComponent<GameBoardController>().RemoveHighLights();

        coroutineAllowed = false;
        int randomDice = 0;
        for (int i = 0; i < 20; i++)
        {
            randomDice = Random.Range(0,5);
            spriteRenderer.sprite = diceFaces[randomDice];
            yield return new WaitForSeconds(0.05f);
        }
        coroutineAllowed = true;
        _boardGame.GetComponent<GameBoardController>().HighLights(randomDice + 1);
        _playeContoller.GetComponent<PlayerController>().CanMove = true;
        firstHighlight = false;
    }
}
