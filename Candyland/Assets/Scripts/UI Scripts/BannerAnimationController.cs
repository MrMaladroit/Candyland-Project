using UnityEngine;

public class BannerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PieceMover.OnTurnEnd += Play;
        Play();
    }

    public void Play()
    {
        animator.Play("ScrollWithPause");
    }
}