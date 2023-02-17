using UnityEngine;

public class SoulControl : MonoBehaviour
{
    public Vector3 checkPoint;
    //write code to get an in game objects transform position and assign it to a variable

    

    private void Awake()
    {
        checkPoint = transform.position;
    }

    public void LoadCheckPoint()
    {
        transform.position = checkPoint;
    }

    public void SaveCheckPoint()
    {
        checkPoint = transform.position;
    }
}
