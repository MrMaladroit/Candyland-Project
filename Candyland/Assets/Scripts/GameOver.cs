using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Image gameOverPanel;
    [SerializeField] private TextMeshProUGUI playerText;

    private void Start()
    {
        PieceMover.OnEndReached += HandleGameOver;
    }

    private void OnDisable()
    {
        PieceMover.OnEndReached -= HandleGameOver;
    }

    private void HandleGameOver(Player player)
    {
        playerText.text = player.gameObject.name + " Wins!";
        gameOverPanel.gameObject.SetActive(true);
    }
}