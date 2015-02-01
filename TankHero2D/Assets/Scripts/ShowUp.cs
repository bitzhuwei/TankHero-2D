using UnityEngine;
using System.Collections;

public class ShowUp : MonoBehaviour {

    public float showUpSpeed = 1;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        var color = this.spriteRenderer.color;
        this.spriteRenderer.color = new Color(color.r, color.g, color.b, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (this.spriteRenderer == null) { return; }

        this.spriteRenderer.color = Color.Lerp(this.spriteRenderer.color, Color.white, this.showUpSpeed * Time.deltaTime);

        //Debug.Log(string.Format("A: {0}", this.spriteRenderer.color.a));
        if (Mathf.Abs(Color.white.a - this.spriteRenderer.color.a) <= 0.02f)
        {
            this.spriteRenderer.color = Color.white;
            this.spriteRenderer = null;
        }
	}
}
