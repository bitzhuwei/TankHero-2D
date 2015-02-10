using UnityEngine;
using System.Collections;

public class DrawText : MonoBehaviour {
    
    UnityEngine.UI.Text txtInfo;
    private GameObject tankHero;
    private CoinManager coinManagerScript;
    private Health healthScript;
    private PlayerMovement playerMovement;
    private LevelController2 levelController;

    void Awake()
    {
        txtInfo = this.GetComponent<UnityEngine.UI.Text> ();
        UpdateTankHero();
        var controller = GameObject.FindGameObjectWithTag(Tags.levelController);
        this.levelController = controller.GetComponent<LevelController2>();
    }
    
    void UpdateTankHero()
    {
        tankHero = GameObject.FindGameObjectWithTag(Tags.hero);
        if (tankHero == null) { return; }
        coinManagerScript = tankHero.GetComponent<CoinManager>();
        healthScript = tankHero.GetComponentInChildren<Health>();
        playerMovement = tankHero.GetComponent<PlayerMovement>();
    }
    
    // Use this for initialization
    void Start () {
        
    }
    
    
    // Update is called once per frame
    void Update () {
        var builder = new System.Text.StringBuilder();
        //DrawMouseInfo(builder);
        DrawScreenInfo(builder);
        DrawTankHeroInfo(builder);
        DrawLevelInfo(builder);
        txtInfo.text = builder.ToString();
    }
    
    void DrawMouseInfo(System.Text.StringBuilder builder)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;     
        if(Physics.Raycast(ray, out hit))
        {
            builder.AppendLine(string.Format ("input: {0} mouse: {1} | {2}", 
                                              Input.mousePosition, hit.point, hit.transform.gameObject.name));
        }
        else
        {
            builder.AppendLine(string.Format ("input: {0} mouse: {1} | {2}", 
                                              Input.mousePosition, "null", "null"));
        }
    }
    
    void DrawScreenInfo(System.Text.StringBuilder builder)
    {
        var width = Screen.width;
        var height = Screen.height;
        builder.AppendLine(string.Format("screen:{0}, {1}", width, height));
    }
    
    void DrawTankHeroInfo(System.Text.StringBuilder builder)
    {
        if (tankHero == null) { UpdateTankHero(); }
        
        if (tankHero == null || coinManagerScript == null || healthScript == null) 
        {
            builder.AppendLine("tank heor not found!"); 
            return;
        }
        
        builder.AppendLine(string.Format("money: {0}", coinManagerScript.money));
        builder.AppendLine(string.Format("HP: {0}/{1}", healthScript.HP, healthScript.fullHP));
        builder.AppendLine(string.Format("Speed:{0}", playerMovement.speed));
        
    }

    void DrawLevelInfo(System.Text.StringBuilder builder)
    {
        builder.AppendLine(levelController.ToString());
    }
}
