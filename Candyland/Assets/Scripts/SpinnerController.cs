using UnityEngine;
using System;

public class SpinnerController : MonoBehaviour
{
#if (UNITY_EDITOR)
    public TileType MOVETESTTILETYPE = TileType.Blue;
    public int MOVETESTSINGLEORDOUBLE = 1;
#endif

    public static event Action<TileType, int> OnSpinnerResults;

    [SerializeField] private int minAmountOfSpins = 2;
    [SerializeField] private int maxAmountOfSpins = 7;
    [SerializeField] private int targetRotation = 90;
    [SerializeField] private float spinSpeed = 5f;

    private Transform rotation;
    private int totalDegrees = 0;
    private float newRotationClamped = 0f;
    private float newRotation = 0f;
    private TileType tileType;

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
        OnSpinnerResults(MOVETESTTILETYPE, MOVETESTSINGLEORDOUBLE);
    }
}