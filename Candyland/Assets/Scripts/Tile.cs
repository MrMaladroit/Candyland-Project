using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tile primaryNextTile;
    [SerializeField] private Transform secondaryNextTile;

    private Board board;
    private bool hasSpecialAction = false;
    public bool HasSpecialAction { get { return hasSpecialAction; } }
    public Tile NextTile { get { return primaryNextTile; } }
    public Transform SecondaryNextTile { get { return secondaryNextTile; } }

    public TileType tileType;

    private void Start()
    {
        board = FindObjectOfType<Board>();

        int index = Array.IndexOf(board.boardTiles, this);
        if(board.boardTiles[index].tileType != TileType.End)
        {
            primaryNextTile = board.boardTiles[index + 1];
        }

        hasSpecialAction = secondaryNextTile == null ? false : true;
        PieceMover.OnMoveFinished += HandleSpecialTile;
   }


    private void HandleSpecialTile()
    {

    }
}
