using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] Player[] players;
    private int turnCounter = 0;
    private BannerTextController bannerTextController;

    private void Start()
    {
        PieceMover.OnTurnEnd += PassTurn;
        players[0].IsCurrentPlayer = true;
        bannerTextController = FindObjectOfType<BannerTextController>();
        bannerTextController.SetText("Player 1's Turn");
    }

    private void PassTurn()
    {
        FlipPlayerIsCurrentPlayerProp();
        turnCounter++;
        FlipPlayerIsCurrentPlayerProp();
        bannerTextController.SetText("Player " + ((turnCounter % Player.PlayerCount)  + 1 ) + "'s Turn");
    }

    private void FlipPlayerIsCurrentPlayerProp()
    {
        players[turnCounter % Player.PlayerCount].IsCurrentPlayer = !players[turnCounter % Player.PlayerCount].IsCurrentPlayer;
    }

}