using UnityEngine;
using System;

public class SpinnerController : MonoBehaviour
{
    [SerializeField] private int minAmountOfSpins = 2;
    [SerializeField] private int maxAmountOfSpins = 7;
    [SerializeField] private int targetRotation = 90;
    [SerializeField] private float spinSpeed = 5f;
    private Transform rotation;
    private int totalDegrees = 0;
    private float newRotationClamped = 0f;
    private float newRotation = 0f;
    private TileType tileType;

    public static event Action<TileType, int> OnSpinnerResults;

    private void Awake()
    {
        rotation = GetComponent<Transform>();
    }

    private void Update()
    {
        newRotation += spinSpeed * Time.deltaTime;
        newRotationClamped = Mathf.Clamp(newRotation, 0, 360);
        rotation.eulerAngles = new Vector3(0, 0, newRotationClamped);
    }

    public void Spin()
    {
        int numberOfSpins = UnityEngine.Random.Range(minAmountOfSpins, maxAmountOfSpins);
        totalDegrees = (360 * numberOfSpins) + targetRotation;
    }

    public void Move()
    {
        OnSpinnerResults(TileType.Yellow, 1);
    }
}