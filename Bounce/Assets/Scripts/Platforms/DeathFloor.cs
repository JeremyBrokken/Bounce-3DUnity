using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SoulControl>().LoadCheckPoint();
        }
    }
}
