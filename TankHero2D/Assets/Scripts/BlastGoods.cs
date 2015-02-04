using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlastGoods : MonoBehaviour {

    public List<Transform> goods;
    private Health healthScript;
    private LevelController levelController;
    void Awake()
    {
        if (goods == null) { goods = new List<Transform>(); }
        healthScript = this.GetComponentInChildren<Health>();
        var levelControllerGameObject = GameObject.FindGameObjectWithTag(Tags.levelController);
        this.levelController = levelControllerGameObject.GetComponent<LevelController>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (healthScript.health > 0) { return; }
        if (goods == null || goods.Count < 1) { return; }

        var index = Random.Range(0, goods.Count);
        Instantiate(goods[index], this.transform.position, this.transform.rotation);

        levelController.EnemyDying(this.gameObject);

        Destroy(this.gameObject);
    }
}
