using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite CardFrontImage;
    public Sprite CardBackImage;
    public TileType TileType;
    public bool IsDouble;
}
