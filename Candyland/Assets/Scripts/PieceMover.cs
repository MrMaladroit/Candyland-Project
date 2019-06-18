using UnityEngine;
using System;
using System.Collections;

public class PieceMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private float smoothDistance = 0.1f;
    private Transform currentTransform;
    private Player player;
    private MoveCalculator moveCalculator;

    private void Start()
    {
        player = GetComponent<Player>();
        SpinnerController.OnSpinnerResults += HandleSpinnerResults;
        transform.position = player.CurrentTile.transform.position;
        moveCalculator = GetComponent<MoveCalculator>();
    }

    private void HandleSpinnerResults(TileType tileType, int numberOfMoves)
    {
        StartCoroutine(MoveToNextTile());
    }

    private IEnumerator MoveToNextTile()
    {
        var startPos = transform.position;
        float elapsedTime = 0f;
        float time = 1f;
        Tile[] moveQueue = moveCalculator.GetMoveQueue();
        int moveQueueIndex = 0;
        while(elapsedTime < time)
        {
            bool isCloseEnoughToTarget = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), player.CurrentTile.NextTile.transform.position) < smoothDistance;
            if (isCloseEnoughToTarget)
            {
                player.CurrentTile = player.CurrentTile.NextTile;

                if(moveQueue == null || moveQueueIndex == (moveQueue.Length))
                {
                    StopCoroutine(MoveToNextTile());
                }
                else
                {
                    moveQueueIndex++;
                }
            }
            float pospct = elapsedTime / time;
            transform.position = Vector3.Lerp(startPos, player.CurrentTile.NextTile.transform.position, pospct);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(MoveToNextTile());
    }
}