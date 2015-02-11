using UnityEngine;
using System.Collections;

/// <summary>
/// add Base.Awake() if you inherit this class and put Awake() method in it.
/// </summary>
public abstract class Weapon : MonoBehaviour {

    public bool userFires;
    public float shootInterval;
    public float bulletVelocity;
    public AudioClip shootAudioClip;
    protected AudioSource shootAudioSource;
    protected Movement movementScript;
    protected string shooterTag;
    protected float passedInterval;


    protected void Awake()
    {
        this.movementScript = this.GetComponentInParent<Movement>();
        this.shootAudioSource = this.audio;
        this.shootAudioSource.clip = shootAudioClip;
        this.shooterTag = this.transform.parent.tag;
        passedInterval = 0;
    }

}
