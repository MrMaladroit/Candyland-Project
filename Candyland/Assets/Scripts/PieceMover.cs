using UnityEngine;
using System;
using System.Collections;

public class PieceMover : MonoBehaviour
{
    public static Action OnMoveFinished;
    public Tile CurrentTile { get { return currentTile; } private set { currentTile = value; } }
    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] private float smoothDistance = 0.1f;
    [SerializeField] private Tile currentTile;
    private Transform currentTransform;
    private MoveCalculator moveCalculator;
    private bool isMoving = false;
    private Vector2 velocity;

    private void Start()
    {        
        MoveCalculator.MoveCalculated += HandleMove;
        transform.position = currentTile.transform.position;
        moveCalculator = GetComponent<MoveCalculator>();
    }

    private void HandleMove(Tile[] moveQueue)
    {
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
            if(Vector2.Distance(transform.position, currentTile.NextTile.transform.position) < 0.01f)
            {
                currentTile = currentTile.NextTile;
            }

            transform.position = Vector2.SmoothDamp(transform.position, currentTile.NextTile.transform.position, ref velocity, smoothTime);
            yield return null;
        }

        isMoving = false;

        if(finalTile.HasSpecialAction)
        {
            currentTile = currentTile.SecondaryNextTile;
            moveCalculator.ClearMoveQueue();
            moveQueue = finalTile.shortcutRoute;
            HandleMove(moveQueue);
        }
        OnMoveFinished();
    }
}


/*
 * Need to set up movement for choclate bridge and gummy bridge
 * Need to add functions for moving to special item tiles like ice cream, cupcake, hard candy, and peanut
 * Need to add event for landing on lose a turn space.
 * 
 * LOOKOUT FOR OBJECT REFERENCE NOT SET TO AN INSTANCE OF AN OBJECT WHEN PLAYER REACHES END TILE.
 */ 