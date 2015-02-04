using UnityEngine;
using System.Collections;

public class NormalBulletFly : BulletFly {

	public float damage;
    public long id { get;set; }
    private static long idCounter = 0;
    private bool shouldExplode = false;
    private bool exploded = false;

	void Awake()
	{
		if (this.damage <= 0)
		{ this.damage = 3; }

        this.id = idCounter++;
        this.name = string.Format("NormalBulletFly({0})", this.id);
        this.shouldExplode = false;
        this.exploded = false;
    }

	void Start()
	{
		Debug.Log ("NormalBulletFly.Start()");
	}

    new void Update()
    {
        if ((!exploded) && shouldExplode)
        {
            exploded = true;
            Destroy(this.gameObject);
        }

        if (!shouldExplode)
        {
            base.Update();
        }
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
        if (!shouldExplode)
        { Try2Explode(collider); }
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if (!shouldExplode)
        { Try2Explode(collider); }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (!shouldExplode)
        { Try2Explode(collider); }
    }

    void Try2Explode(Collider2D collider)
    {
        //Debug.Log (string.Format("NormalBulletFly.OnTriggerEnter2D({0})", collider.name));
        //if (base.undying) { return; }
        if (collider.tag == Tags.coin) { return; }
        //if (base.shooterTag == collider.tag) { return; }

        //Debug.Log(string.Format("{0}'s bullet hit {1}", base.shooterTag, collider.tag));
        this.shouldExplode = true;
    }

	public override float GetDamage (Transform gameObject)
	{
		return this.damage;
	}

    public override void Initiate(WeaponConfig weaponConfig, GameObject shooter, Movement movementScript)//, 
//                                  bool enableRenderer = true, bool undying = false)
    {
//        base.undying = undying;
        base.velocity = weaponConfig.velocity;
        base.shooterTag = shooter.tag;
        base.targetPosition = movementScript.fireTarget;
    }

	/* Update()事件，Unity只找那个离MonoBehaviour最远的Update()执行。
	void Update()
	{
		Debug.Log ("NormalBulletFly.Update()");
		base.Update ();
		//base.SendMessageUpwards ("Update", SendMessageOptions.DontRequireReceiver);
	}
	*/

}
