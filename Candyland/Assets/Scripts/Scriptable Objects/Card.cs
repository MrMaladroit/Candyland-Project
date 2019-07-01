using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite cardImage;
    public TileType TileType;
    public bool IsDouble;
}
