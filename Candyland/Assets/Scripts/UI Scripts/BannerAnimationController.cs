﻿using UnityEngine;

public class BannerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PieceMover.OnTurnEnd += Play;
        Play();
    }

    private void OnDisable()
    {
        PieceMover.OnTurnEnd -= Play;
    }

    public void Play()
    {
        animator.Play("ScrollWithPause");
    }
}