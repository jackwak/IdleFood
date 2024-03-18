using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private float _takingOrderTime;

    public float TakingOrderTime
    {
        get { return _takingOrderTime; }
        set
        {
            if (value > 0)
            {
                _takingOrderTime = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
