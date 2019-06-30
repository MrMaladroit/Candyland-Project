using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsHuman = false;
    public bool IsCurrentPlayer { get { return isCurrentPlayer; } private set { isCurrentPlayer = value; } }


    private bool isCurrentPlayer = false;

}