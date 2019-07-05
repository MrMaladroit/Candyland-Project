using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card Card;
    public SpriteRenderer CardFrontArt;
    public SpriteRenderer CardBackArt;

    private bool isDouble;
    private TileType tileType;

    private void Start()
    {
        CardFrontArt.sprite = Card.CardFrontImage;
        CardBackArt.sprite = Card.CardBackImage;
        isDouble = Card.IsDouble;
        tileType = Card.TileType;
    }
}