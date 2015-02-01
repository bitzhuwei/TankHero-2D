using UnityEngine;
using System.Collections;

public class FactoryInfo : MonoBehaviour {

    public Transform factory;

    void OnDestroy()
    {
        if (factory != null)
        {
            var status = factory.GetComponent<ProductStatus>();
            status.tankCount--;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
