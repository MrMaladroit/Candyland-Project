using System;
using UnityEngine;

public class MoveCalculator : MonoBehaviour
{
    private Tile[] moveQueue;
    private Player player;
    private Board board;

    private void Start()
    {
        SpinnerController.OnSpinnerResults += CalculateMove;
        player = GetComponent<Player>();
        board = FindObjectOfType<Board>();
    }

    private void CalculateMove(TileType tileType, int singleOrSingle)
    {
        int moveQueueIndex = 0;
        Tile nextTile = player.CurrentTile.NextTile;
        bool isFinalTile;
        for (int i = 1; i <= singleOrSingle; i++)
        {
            do
            {
                moveQueue[moveQueueIndex] = nextTile;
                isFinalTile = moveQueue[moveQueueIndex].tileType == tileType;
                nextTile = board.boardTiles[Array.IndexOf(board.boardTiles, player.CurrentTile.NextTile) + 1];
                moveQueueIndex++;
            } while (isFinalTile != true);
        }
    }

    public void ClearMoveQueue()
    {
        moveQueue = null;
    }

    public Tile[] GetMoveQueue()
    {
        return moveQueue;
    }
}