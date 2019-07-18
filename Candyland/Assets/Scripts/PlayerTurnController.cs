using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] Player[] players;
    private int turnCounter = 0;
    private BannerTextController bannerTextController;

    private void Start()
    {
        players[0].IsCurrentPlayer = true;
        bannerTextController = FindObjectOfType<BannerTextController>();
        bannerTextController.SetText("Player 1's Turn");
    }

    private void OnEnable()
    {
        PieceMover.OnTurnEnd += PassTurn;
    }

    private void OnDisable()
    {
        PieceMover.OnTurnEnd -= PassTurn;
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