using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Image cardImage;
    public TileType TileType;
    public bool IsDouble;
}
