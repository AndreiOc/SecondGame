using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{

    /// <summary>
    /// Lista contenente la posizione di tutte le mie tiles
    /// </summary>
    //! Componenti per la generazioni delle tiles
    public List<Tile>tiles;
    public List<Tile>tiles2;
    private int TILE_COUNT_X = 10;
    private int TILE_COUNT_Y = 10;
    private int avaibleTiles;
    public int changeStage = 0;
    [SerializeField] Tile [] diceTile;
    [SerializeField] EnemyController enemy;
    [SerializeField]public int[,] _valDiceArray = new int[10,10];
    GameManager _gamemanager;
    private void Awake()
    {
        GenerateAllTiles(TILE_COUNT_X,TILE_COUNT_Y);    
    }


    private void GenerateAllTiles(int tileCountX, int tileCountY)
    {
        Debug.Log(transform.position);
        tiles = new List<Tile>();
        for (int x = 0; x < TILE_COUNT_X; x++)
            for (int y = 0; y < TILE_COUNT_Y; y++)
                tiles.Add(GenerateSingleTile(x + changeStage, y));         
      
    }


    public Tile GenerateSingleTile(int x, int y)
    {
        
        Tile tileObject;
        int valTile = Random.Range(0,100);
        if(valTile <= 25)
        {
            tileObject = Instantiate(diceTile[0],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 1;
        }
        else if(valTile > 25 && valTile <= 47)
        {
            tileObject = Instantiate(diceTile[1],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 2;

        }
        else if(valTile > 47 && valTile <= 66)
        {
            tileObject = Instantiate(diceTile[2],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 3;
        }
        else if(valTile>66 && valTile <= 82)
        {
            tileObject = Instantiate(diceTile[3],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 4;
        }
        else if(valTile>82 && valTile <= 93)
        {
            tileObject = Instantiate(diceTile[4],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 5;
        }
        else
        {
            tileObject = Instantiate(diceTile[5],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 6;
        }

        tileObject.X = (int)transform.position.x + x ;
        tileObject.Y = (int)transform.position.y + y;
        _valDiceArray[x,y] = tileObject.ValDice;
        tileObject.transform.parent = transform;
        tileObject.transform.position = new Vector2(x, y);

        return tileObject;
    }
    /// <summary>
    /// Illumina tutti i dadi con quel valore
    /// </summary>
    /// <param name="valDice">Valore dado</param>    
    public void HighLights(int valDice)
    {
        foreach (var item in tiles)
        {
            if(item.ValDice == valDice)
            {
                if(item.transform.tag != "Untagged" && !item.isConsumed)
                    item.HighLight();
            }
        }
    }
    /// <summary>
    /// Rimuovi l'illuminazione corrente
    /// </summary>
    public void RemoveHighLights()
    {
        foreach (var item in tiles)
        {
            if(item.transform.tag != "Untagged" && !item.isConsumed)
            {
                item.RemoveHighLight();
            }
        }
    }


    /// <summary>
    /// Quando rimuovo un oggetto dalla mia gameboard 
    /// cambio la tag in None
    /// consumo la tile 
    /// rimuovo dalla lista
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void RemoveFromList(int x, int y)
    {
        _valDiceArray[x,y] = 0 ;
        tiles.Find(val => (val.X == x && val.Y == y)).ConsumedTile();
        //tiles.Remove(tiles.Find(val => (val.X == x && val.Y == y)));
  
    }
    /// <summary>
    /// Spawn un nemico casualmente sulla plancia di gioco
    /// </summary>
    /// <param name="currentDice"></param>
    public void SpawnEnemy(int currentDice)
    {
        Tile tile;
        do
        {
            tile = tiles[Random.Range(0,tiles.Count)];
            tile.transform.tag = "Untagged";
        }while(tile.isConsumed);
        tile.ConsumedTile(true);
        Instantiate(enemy,new Vector2(tile.X,tile.Y + 0.8f),Quaternion.identity);
        Debug.Log("list count : " + tiles.Count);   
    }
}
