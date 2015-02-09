using UnityEngine;
using System.Collections;
using System.Linq;

public class TriggerTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("{0} trigger {1}'s({2})", this.name, other.name, other.GetInstanceID()));
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(string.Format("{0} collision {1}'s({2})", this.name, collision.transform.name, collision.collider.GetInstanceID()));
    }
}
