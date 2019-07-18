using System;
using UnityEngine;

public class MoveCalculator : MonoBehaviour
{
    public static Action<Tile[]> MoveCalculated;

    private Tile[] moveQueue;
    private PieceMover pieceMover;
    private Board board;
    private Player player;

    private void Start()
    {      
        pieceMover = GetComponent<PieceMover>();
        board = FindObjectOfType<Board>();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        Deck.DrawnCard += CalculateMove;
        PieceMover.OnTurnEnd += ClearMoveQueue;
    }
    private void OnDisable()
    {
        Deck.DrawnCard -= CalculateMove;
        PieceMover.OnTurnEnd -= ClearMoveQueue;
    }

    private void CalculateMove(TileType tileType, bool isDouble)
    {
        if(player.IsCurrentPlayer == false)
        {
            return;
        }

        int isDoubleAsInt = isDouble == true ? 2 : 1;

        int moveCount = 0;
        Tile nextTile = pieceMover.CurrentTile.NextTile;

        for (int i = 0; i < isDoubleAsInt;)
        {
            moveCount++;

            if (nextTile.tileType == TileType.End)
            {
                break;
            }
            else if (nextTile.tileType == tileType)
            {
                i++;
            }

            nextTile = nextTile.NextTile;
        }

        moveQueue = new Tile[moveCount];

        nextTile = pieceMover.CurrentTile.NextTile;
        for (int i = 0; i < moveCount; i++)
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