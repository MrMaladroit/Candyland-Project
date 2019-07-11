using UnityEngine;

public class BannerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Play()
    {
        animator.Play("ScrollWithBounce");
    }
}