using UnityEngine;
using System.Collections;

public class ShowUp : MonoBehaviour {

    public float showUpSpeed = 1;
    private SpriteRenderer spriteRenderer;
    private bool goWhite;

    static Color initialColor = new Color(Color.white.r, Color.white.g, Color.white.b, 0);
    
    void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.spriteRenderer.color = initialColor;
        this.goWhite = true;
    }

    float rotation;
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.EulerRotation(0, rotation, 0);
        rotation += Time.deltaTime * 3;
        if (this.goWhite)
        {
            this.spriteRenderer.color = Color.Lerp(this.spriteRenderer.color, Color.white, this.showUpSpeed * Time.deltaTime);

            //Debug.Log(string.Format("A: {0}", this.spriteRenderer.color.a));
            if (Mathf.Abs(Color.white.a - this.spriteRenderer.color.a) <= 0.02f)
            {
                this.spriteRenderer.color = Color.white;
                this.goWhite = false;
            }
        }
        else
        {
            return;
            this.spriteRenderer.color = Color.Lerp(this.spriteRenderer.color, initialColor, this.showUpSpeed * Time.deltaTime);

            //Debug.Log(string.Format("A: {0}", this.spriteRenderer.color.a));
            if (Mathf.Abs(initialColor.a - this.spriteRenderer.color.a) <= 0.02f)
            {
                this.spriteRenderer.color = initialColor;
                this.goWhite = true;
            }
        }

	}
}
