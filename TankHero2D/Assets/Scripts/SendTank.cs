using UnityEngine;
using System.Collections;

public class SendTank : MonoBehaviour {

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
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        passedInterval += Time.deltaTime;
        if (passedInterval < sendInterval) { return; }

	    if (status.tankCount < status.maxTank)
        {
            if (Random.Range(0, 1000) < sendSpeed)
            {
                var tank = Instantiate(tankPrefab, this.transform.position, this.transform.rotation) as Transform;
                status.tankCount++;
                var factoryInfo = tank.GetComponent<FactoryInfo>();
                factoryInfo.factory = this.gameObject.transform;
                passedInterval = 0;
            }
        }
	}
}
