using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MaxHealthPoints = 100f;
    [SerializeField] float currentHealthPoints = 100f;

    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / MaxHealthPoints;
        }
    }
}
