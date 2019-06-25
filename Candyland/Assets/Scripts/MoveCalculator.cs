using System;
using UnityEngine;

public class MoveCalculator : MonoBehaviour
{
    public static Action<Tile[]> MoveCalculated;
    private Tile[] moveQueue;
    private Player player;
    private Board board;

    private void Start()
    {
        SpinnerController.OnSpinnerResults += CalculateMove;
        PieceMover.OnMoveFinished += ClearMoveQueue;
        player = GetComponent<Player>();
        board = FindObjectOfType<Board>();
    }

    private void CalculateMove(TileType tileType, int singleOrDouble)
    {
        int moveCount = 0;
        Tile nextTile = player.CurrentTile.NextTile;

        for (int i = 0; i < singleOrDouble;)
        {
            moveCount++;
            if (nextTile.tileType == tileType)
            {
                i++;
            }
            nextTile = nextTile.NextTile;
        }
        moveQueue =  new Tile[moveCount];

        nextTile = player.CurrentTile.NextTile;
        for(int i = 0; i < moveCount; i++)
        {
            moveQueue[i] = nextTile;
            nextTile = nextTile.NextTile;
        }

        MoveCalculated(moveQueue);
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




/*
 * currentTile index in board
 * new array length will number of moves
 * count the amount of tiles between currentTile and final tile.
 * for every next tile that isn't the result increment counter
 * once you've reached the final tile stop counting
 * for the number of moves add to the move queue the next tiles.
 * send off movequeue
 * 
 */
