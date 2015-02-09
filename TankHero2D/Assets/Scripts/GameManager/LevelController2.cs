using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class LevelController2 : MonoBehaviour
{
    static int levelIndex = 0;

    public List<Transform> enemyBornPoints;
    public List<Transform> tankPrefabs;
    public int sendSpeed = 100;
    public float sendInterval = 1;
    private float passedInterval;
    private Level currentLevel;
    private List<Transform> aliveTanks;
    private int nextTankIndex;

    void Awake()
    {
        this.currentLevel = LevelLoader.GetLevel(levelIndex);
        levelIndex++;

        this.nextTankIndex = 0;

        this.aliveTanks = new List<Transform>();

        if (sendSpeed > 100) { sendSpeed = 100; }

        foreach (var item in this.currentLevel)
        {
            if(!item.IsStop())
            { this.total++; }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.aliveTanks.Count == 0 && nextTankIndex >= this.currentLevel.Count)// goto menu for next level
        { return; }

        if (this.aliveTanks.Count > 0)
        {
            if (nextTankIndex < this.currentLevel.Count 
                && this.currentLevel[nextTankIndex].IsStop())
            { return; }
        }

        if (nextTankIndex < this.currentLevel.Count)
        {
            passedInterval += Time.deltaTime;
            if (passedInterval >= sendInterval)
            {
                if (UnityEngine.Random.Range(0, 100) < sendSpeed)
                {
                    while (nextTankIndex < this.currentLevel.Count
                        && this.currentLevel[nextTankIndex].IsStop())
                    {
                        nextTankIndex++;
                    }

                    if (nextTankIndex < this.currentLevel.Count)
                    {
                        var egg = this.currentLevel[nextTankIndex];
                        var bornTransform = this.enemyBornPoints[egg.bornPointIndex];
                        var tank = Instantiate(tankPrefabs[egg.enemyPrefabIndex], bornTransform.position, bornTransform.rotation) as Transform;
                        this.aliveTanks.Add(tank);
                        passedInterval = 0;
                        nextTankIndex++;
                    }
                }
            }
        }
    }

    public void EnemyDying(GameObject enemy)
    {
        this.killed++;
        this.aliveTanks.Remove(enemy.transform);
    }

    private int killed = 0;
    private int total = 0;
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(string.Format("Killed: {0}/{1} next:{2} alive:{3}", killed, total, nextTankIndex, this.aliveTanks.Count));
        return builder.ToString();
    }

}
