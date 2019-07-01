using UnityEngine;

public class Player : MonoBehaviour
{
    public static int PlayerCount = 0;
    public bool IsHuman = false;
    public bool IsCurrentPlayer { get { return isCurrentPlayer; } private set { isCurrentPlayer = value; } }

    private bool isCurrentPlayer = false;

    private void Start()
    {
        PlayerCount++;
    }
}