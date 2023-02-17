using UnityEngine;

public class MovingPlatformOnY : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform bottomEdge;
    [SerializeField] private Transform topEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private bool movingLeft;

    [Header("Idel Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.y >= bottomEdge.position.y)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.y <= topEdge.position.y)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        //Move direction
        enemy.position = new Vector3(enemy.position.x,
            enemy.position.y + Time.deltaTime * _direction * speed, enemy.position.z);
    }
}
