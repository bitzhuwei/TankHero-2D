using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

    public List<Transform> enemyBornPoints;
    private Queue<int> levelSteps;
    private int stepEnemyCount;
    private int stepBornEnemyCount;
    private int stepDeadEnemyCount;

    public List<Transform> tankPrefabs;
    public int sendSpeed = 1;
    public float sendInterval = 1;
    private float passedInterval;

    void Awake()
    {
        //todo: initial this field with config or network.
        levelSteps = new Queue<int>(new int[] { 1, 1, 3, 3, 4, 5, 6, 7, 8, 9 });
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (enemyBornPoints == null || levelSteps == null || tankPrefabs == null) { return; }
        //if (tankPrefabs.Count == 0) { return; }

        if (stepEnemyCount == stepDeadEnemyCount && levelSteps.Count == 0)// go to menu for next level
        { Application.LoadLevel(Application.loadedLevel); }

        if (stepDeadEnemyCount >= stepEnemyCount)
        {
            stepEnemyCount = levelSteps.Dequeue();
            stepDeadEnemyCount = 0;
            stepBornEnemyCount = 0;
        }

        if (stepBornEnemyCount < stepEnemyCount)
        {
            passedInterval += Time.deltaTime;
            if (passedInterval >= sendInterval)
            {            
                if (Random.Range(0, 1000) < sendSpeed)
                {
                    var bornTransform = this.enemyBornPoints[bornPointIndex];
                    var tank = Instantiate(tankPrefabs[0], bornTransform.position, bornTransform.rotation) as Transform;
                    this.bornPointIndex++;
                    if (this.bornPointIndex >= this.enemyBornPoints.Count) { this.bornPointIndex = 0; }
                    passedInterval = 0;
                    stepBornEnemyCount++;
                }
            }
        }
	}
    int bornPointIndex;

    public void EnemyDying(GameObject enemy)
    {
        System.Threading.Interlocked.Increment(ref this.stepDeadEnemyCount);
    }
}
