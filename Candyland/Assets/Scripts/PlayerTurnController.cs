using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] Player[] players;
    private int turnCounter = 0;
        
    private void Start()
    {
        PieceMover.OnMoveFinished += PassTurn;
    }

    private void PassTurn()
    {
        FlipPlayerIsCurrentPlayerProp();
        turnCounter++;
        FlipPlayerIsCurrentPlayerProp();
    }

    private void FlipPlayerIsCurrentPlayerProp()
    {
        players[turnCounter % Player.PlayerCount].IsCurrentPlayer = !players[turnCounter % Player.PlayerCount].IsCurrentPlayer;
    }

}