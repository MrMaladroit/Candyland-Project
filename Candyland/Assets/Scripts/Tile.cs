using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType tileType;
    public bool HasSpecialAction { get { return hasSpecialAction; } }
    public Tile NextTile { get { return primaryNextTile; } }
    public Tile SecondaryNextTile { get { return secondaryNextTile; } }
    public Tile[] shortcutRoute; 

    [SerializeField] private Tile primaryNextTile;
    [SerializeField] private Tile secondaryNextTile;

    private Board board;
    private bool hasSpecialAction = false;


    private void Start()
    {
        board = FindObjectOfType<Board>();

        int index = Array.IndexOf(board.boardTiles, this);
        if (tileType != TileType.Shortcut)
        {
            if(board.boardTiles[index].tileType != TileType.End)
            {
                primaryNextTile = board.boardTiles[index + 1];
            }        
        }

        hasSpecialAction = secondaryNextTile == null ? false : true;
   }
}
