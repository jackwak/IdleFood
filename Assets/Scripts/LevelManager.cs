using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private float _takingOrderTime;
    public List<Waiter> Waiters = new List<Waiter>();

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

    private void Start()
    {
        //set waiters
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

        // Her GameObject'i kontrol et
        foreach (GameObject obj in gameObjects)
        {
            // Eðer GameObject'te Waiter component'i varsa
            Waiter waiter = obj.GetComponent<Waiter>();
            if (waiter != null)
            {
                // Waiter component'ini Waiters listesine ekle
                Waiters.Add(waiter);
            }
        }

        //set start waiters position
        for (int i = 0; i < Waiters.Count; i++)
        {
            Waiters[i].transform.position = IdlePositionManager.Instance.IdlePositions[i].position;
        }
    }
}
