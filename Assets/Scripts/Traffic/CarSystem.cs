using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarSystem : MonoBehaviour
{
    [SerializeField]
    private List<Vector2> path = null;

    [SerializeField]
    private float

            arriveDistance = .3f,
            lastPointArriveDistance = .1f;

    [SerializeField]
    private float turningAngleOffset = 5;

    [SerializeField]
    private Vector2 currentTargetPosition;

    private int index = 0;

    private bool stop;

    public bool Stop
    {
        get
        {
            return stop;
        }
        set
        {
            stop = value;
        }
    }

    [field: SerializeField]
    public UnityEvent<Vector2> OnDrive { get; set; }

    private void Start()
    {
        if (path == null || path.Count == 0)
        {
            Stop = true;
        }
        else
        {
            currentTargetPosition = path[index];
        }
    }

    public void SetPath(List<Vector2> path)
    {
        if (path.Count == 0)
        {
            Destroy (gameObject);
            return;
        }
        this.path = path;
        index = 0;
        currentTargetPosition = this.path[index];

        // make sure car is facing the next position
        Vector2 relativePoint = this.path[index + 1] - this.path[index];
        float angle =
            Mathf.Atan2(relativePoint.y, relativePoint.x) * Mathf.Rad2Deg;

        // Rotate the car
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Stop = false;
    }

    private void Update()
    {
        CheckIfArrived();
        Drive();
    }

    private void Drive()
    {
        if (Stop)
        {
            OnDrive?.Invoke(Vector2.zero);
        }
        else
        {
            // Calculate the direction to the target position
            Vector2 direction =
                (currentTargetPosition - (Vector2) transform.position);

            // Calculate the angle between the current forward direction and the target direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Determine the rotation direction based on the angle
            int rotateCar = 0;
            if (angle > turningAngleOffset)
            {
                rotateCar = 1;
            }
            else if (angle < -turningAngleOffset)
            {
                rotateCar = -1;
            }
            OnDrive?.Invoke(new Vector2(rotateCar, 1));
        }
    }

    private void CheckIfArrived()
    {
        if (Stop == false)
        {
            var distanceToCheck = arriveDistance;
            if (index == path.Count - 1)
            {
                distanceToCheck = lastPointArriveDistance;
            }
            if (
                Vector2.Distance(currentTargetPosition, transform.position) <
                distanceToCheck
            )
            {
                SetNextTargetIndex();
            }
        }
    }

    private void SetNextTargetIndex()
    {
        index++;
        if (index >= path.Count)
        {
            Stop = true;
            Destroy (gameObject);
        }
        else
        {
            currentTargetPosition = path[index];
        }
    }
}
