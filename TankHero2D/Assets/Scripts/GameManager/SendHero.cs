using UnityEngine;
using System.Collections;

public class SendHero : MonoBehaviour {

    public Transform tankPrefab;
    public int sendSpeed = 1;
    public float sendInterval = 5;
    private float passedInterval;
    private ProductStatus status;

    void Awake()
    {
        status = this.GetComponent<ProductStatus>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime == 0) { return; }
        passedInterval += Time.deltaTime;
        if (passedInterval < sendInterval) { return; }

        if (status.tankCount < status.maxTank)
        {
            if (Random.Range(0, 1000) < sendSpeed)
            {
                var hero = Instantiate(tankPrefab, this.transform.position, this.transform.rotation) as Transform;
                var movement = hero.GetComponent<PlayerMovement>();
                movement.speed = GameController.instance.heroConfig.fullSpeed;
                var health = hero.GetComponentInChildren<Health>();
                health.fullHP = GameController.instance.heroConfig.fullHP;
                health.HP = GameController.instance.heroConfig.fullHP;
                status.tankCount++;
                passedInterval = 0;
            }
        }
    }
}
