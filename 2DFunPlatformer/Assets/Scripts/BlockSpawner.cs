using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DansLibrary;

public class BlockSpawner : MonoBehaviour
{
    #region Singleton
    public static BlockSpawner instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private float countdown = 5f;
    [SerializeField] private GameObject[] block;
    [SerializeField] private MasterTimer timerClass;
    private int startingBlockAmount = 5;
    private Vector3 previousPos;

    [Header("Instances")]
    private GlobalTimer timer;
    private Difficulty difficultyLevel;
    // Start is called before the first frame update
    void Start()
    {
        //Used to spawn the blocks every 10 seconds 

        //timerClass.CreateNewTimer(10f, true);
        timer = new GlobalTimer(1f);
        StartCoroutine(timer.ScaledTimer());
        timer.timerCompleted += SpawnNewBlock;
        
        CalculateDifficulty();
    }


    private int CalculateDifficulty()
    {
        //Use the current difficult level to choose which block to spawn

        return 0;
    }

    private int ReturnBlockSize()
    {
        return 0;
    }

    private void SpawnNewBlock()
    {
        float x = Random.Range(point1.position.x, point2.position.x);

        if(previousPos != Vector3.zero)
        {
            Debug.Log("Previous pos here");
            while (x < previousPos.x + 2 && x > previousPos.x - 2)
            {
                x = Random.Range(point1.position.x, point2.position.x);
                Debug.Log("Position is invalid");
            }
        }

        Vector3 randomPoint = new Vector3(x, point1.position.y, 0);
        previousPos = randomPoint;
        Instantiate(block[Random.Range(0, block.Length)], randomPoint, Quaternion.identity);
        //GameEvents.instance.BlockSpawning(randomPoint);

        StartCoroutine(timer.ScaledTimer());
    }

    
}
