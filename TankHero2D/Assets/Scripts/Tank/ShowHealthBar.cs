using UnityEngine;
using System.Collections;

public class ShowHealthBar : MonoBehaviour {

    public Transform leftTop;
    public Transform rightBottom;
    public Texture HealthBarTexture;
	public const float interval = 3;
	private Health health;
	private SpriteRenderer spriteRenderer;
    private bool show;

	void Awake()
	{
		this.health = this.GetComponentInParent<Health> ();
		this.spriteRenderer = this.GetComponent<SpriteRenderer> ();
        this.show = false;
	}
		
	// Update is called once per frame
	void Update () {
		if (this.health == null) { return; }

		if (this.show)
		{
			if (Time.time - this.health.lastDamageTime > interval)
			{
                this.spriteRenderer.enabled = false;
				this.show = false;
			}
		}
		else
		{
			if (Time.time - this.health.lastDamageTime < interval)
			{
                this.spriteRenderer.enabled = true;
				this.show = true;
			}
		}
	}

    void OnGUI()
    {
        if (this.show)
        {
            var screenLeftTop = Camera.main.WorldToScreenPoint(this.leftTop.position);
            var screenRightBottom = Camera.main.WorldToScreenPoint(this.rightBottom.position);
            var width = (screenRightBottom.x - screenLeftTop.x) * this.health.health / this.health.maxHealth;
            var height = screenRightBottom.y - screenLeftTop.y;
            var rect = new Rect(screenLeftTop.x, Screen.height - screenLeftTop.y - height, width, height);

            GUI.DrawTexture(rect, this.HealthBarTexture, ScaleMode.StretchToFill);
            //Debug.Log(string.Format("Bar GUI depth: {0}", GUI.depth));
        }
    }
}
