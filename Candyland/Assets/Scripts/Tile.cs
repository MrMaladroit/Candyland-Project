using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tile primaryNextTile;
    [SerializeField] private Transform secondaryNextTile;

    private Board board;
    public Tile NextTile { get { return primaryNextTile; } }
    public Transform SecondaryNextTile { get { return secondaryNextTile; } }

    public TileType tileType;

    private void Start()
    {
        board = FindObjectOfType<Board>();
        // TODO Refactor for checking End tile
        int index = Array.IndexOf(board.boardTiles, this);
        if(board.boardTiles[index].tileType != TileType.End)
        {
            primaryNextTile = board.boardTiles[index + 1];
        }
    }

}
