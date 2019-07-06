using UnityEngine;

public class Player : MonoBehaviour
{
    public static int PlayerCount = 0;
    public bool IsHuman = false;
    public bool IsCurrentPlayer { get; set; }


    private bool isCurrentPlayer = false;
    private PieceMover pieceMover;

    private void Start()
    {
        PlayerCount++;
        pieceMover = GetComponent<PieceMover>();
        pieceMover.enabled = false;
        PieceMover.OnMoveFinished += SetPieceMoverActivity;
    }

    private void SetPieceMoverActivity()
    {
        pieceMover.enabled = isCurrentPlayer;
    }


}