using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public int id;
    private static int idCounter = 0;
    public HeroConfig heroConfig;

    void Awake()
    {
        if (instance == null)
        {
            heroConfig = new HeroConfig();

            instance = this;
            this.id = idCounter++;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
