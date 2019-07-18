using UnityEngine;
using System;
using System.Collections;

public class PieceMover : MonoBehaviour
{
    public static Action OnTurnEnd;
    public static Action<Player> OnEndReached;

    public Tile CurrentTile { get { return currentTile; } private set { currentTile = value; } }

    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] private float smoothDistance = 0.1f;
    [SerializeField] private Tile currentTile;

    private Transform currentTransform;
    private MoveCalculator moveCalculator;
    private bool isMoving = false;
    private Vector2 velocity;
    private Player player;
    private static bool isGameOver = false;

    private void Start()
    {        
        transform.position = currentTile.transform.position;
        moveCalculator = GetComponent<MoveCalculator>();
        player = GetComponent<Player>();
        isGameOver = false;
    }

    private void OnEnable()
    {
        MoveCalculator.MoveCalculated += HandleMove;
    }

    private void OnDisable()
    {
        MoveCalculator.MoveCalculated -= HandleMove;
    }

    private void HandleMove(Tile[] moveQueue)
    {
        if (player.IsCurrentPlayer == false || isGameOver == true)
        {
            return;
        }

        if(isMoving != true)
        {
            StartCoroutine(MovePiece(moveQueue));
        }
    }

    private IEnumerator MovePiece(Tile[] moveQueue)
    {
        isMoving = true;
        Tile finalTile = moveQueue[moveQueue.Length - 1];
        while (currentTile != finalTile)
        {
            if (Vector2.Distance(transform.position, currentTile.NextTile.transform.position) < 0.01f)
            {
                currentTile = currentTile.NextTile;
            }

            if(currentTile.tileType != TileType.End)
            {
                transform.position = Vector2.SmoothDamp(transform.position, currentTile.NextTile.transform.position, ref velocity, smoothTime);
            }
            else
            {
                isGameOver = true;
                OnEndReached(player);
            }

            yield return null;
        }

        isMoving = false;

        if(finalTile.HasSpecialAction && isGameOver != true)
        {
            currentTile = currentTile.SecondaryNextTile;
            moveCalculator.ClearMoveQueue();
            moveQueue = finalTile.shortcutRoute;
            HandleMove(moveQueue);
        }
        else if(isGameOver != true)
        {
            OnTurnEnd();
        }
    }
}


/*
 * Need to set up movement for choclate bridge and gummy bridge
 * Need to add functions for moving to special item tiles like ice cream, cupcake, hard candy, and peanut
 * Need to add event for landing on lose a turn space.
 * 
 * LOOKOUT FOR OBJECT REFERENCE NOT SET TO AN INSTANCE OF AN OBJECT WHEN PLAYER REACHES END TILE.
 */ 