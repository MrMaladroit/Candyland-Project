using UnityEngine;

public class Player : MonoBehaviour
{
    public static int PlayerCount = 0;
    public bool IsHuman = false;
    public bool IsCurrentPlayer { get; set; }


    private bool isCurrentPlayer = false;
    private PieceMover pieceMover;
    private MoveCalculator moveCalculator;

    private void Start()
    {
        PlayerCount++;
        pieceMover = GetComponent<PieceMover>();
        moveCalculator = GetComponent<MoveCalculator>();    
        pieceMover.enabled = false;
    }

    private void OnDisable()
    {
        PlayerCount = 0;
    }

    private void Update()
    {
        pieceMover.enabled = IsCurrentPlayer;
        moveCalculator.enabled = IsCurrentPlayer;
    }


}