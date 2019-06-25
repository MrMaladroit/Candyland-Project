﻿using UnityEngine;
using System;
using System.Collections;

public class PieceMover : MonoBehaviour
{
    public static Action OnMoveFinished;
    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] private float smoothDistance = 0.1f;
    private Transform currentTransform;
    private Player player;
    private MoveCalculator moveCalculator;
    private bool isMoving = false;
    private Vector2 velocity;

    private void Start()
    {
        player = GetComponent<Player>();
        MoveCalculator.MoveCalculated += HandleMove;
        transform.position = player.CurrentTile.transform.position;
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
        while (Vector2.Distance(transform.position, finalTile.transform.position) > 0.01f)
        {
            if(Vector2.Distance(transform.position, player.CurrentTile.NextTile.transform.position) < 0.01f)
            {
                player.CurrentTile = player.CurrentTile.NextTile.NextTile;
            }
            transform.position = Vector2.SmoothDamp(transform.position, player.CurrentTile.NextTile.transform.position, ref velocity, smoothTime);
            yield return null;
        }
        isMoving = false;
        OnMoveFinished();
        StopCoroutine(MovePiece(moveQueue));
    }
}