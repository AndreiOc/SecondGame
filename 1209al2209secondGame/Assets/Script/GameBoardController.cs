using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{

    /// <summary>
    /// Lista contenente la posizione di tutte le mie tiles
    /// </summary>
    //! Componenti per la generazioni delle tiles
    private List<Tile>tiles;
    private int TILE_COUNT_X = 10;
    private int TILE_COUNT_Y = 10;
    [SerializeField] Tile [] diceTile;
    public GameObject player;
    private void Awake()
    {
        GenerateAllTiles(TILE_COUNT_X,TILE_COUNT_Y);    
        Vector2 positionPlayer;
        foreach (var item in tiles)
        {
            if(item.ValDice == 1)
            {
                positionPlayer = new Vector2(item.X,item.Y);
                Instantiate(player,positionPlayer,Quaternion.identity);
                break;
            }
        }
    }
    void Start()
    {    }

    

    private void GenerateAllTiles(int tileCountX, int tileCountY)
    {

        tiles = new List<Tile>();
        for (int x = 0; x < TILE_COUNT_X; x++)
        {
            for (int y = 0; y < TILE_COUNT_Y; y++)
            {
                tiles.Add(GenerateSingleTile(x, y));
                
            }
        }
    }


    public Tile GenerateSingleTile(int x, int y)
    {

        Tile tileObject;
        int valTile = Random.Range(0,100);
        if(valTile <= 40)
        {
            tileObject = Instantiate(diceTile[0],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 1;
        }
        else if(valTile > 40 && valTile <= 67)
        {
            tileObject = Instantiate(diceTile[1],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 2;

        }
        else if(valTile > 67 && valTile <= 78)
        {
            tileObject = Instantiate(diceTile[2],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 3;
        }
        else if(valTile>78 && valTile <= 88)
        {
            tileObject = Instantiate(diceTile[3],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 4;
        }
        else if(valTile>88 && valTile <= 97)
        {
            tileObject = Instantiate(diceTile[4],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 5;
        }
        else
        {
            tileObject = Instantiate(diceTile[5],new Vector3(x,y,0),Quaternion.identity);
            tileObject.ValDice = 6;
        }

        tileObject.X = x;
        tileObject.Y = y;
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
            if(item.ValDice == valDice){
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
            item.RemoveHighLight();
        }
    }
}
