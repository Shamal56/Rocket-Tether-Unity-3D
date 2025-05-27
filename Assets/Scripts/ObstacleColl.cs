using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColl : MonoBehaviour
{
    // Add any behavior for the obstacles here (e.g., movement, destruction, etc.)

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))  // Ensure the rocket hits the obstacle
        {
            RocketMovementScript rocket = collision.gameObject.GetComponent<RocketMovementScript>();

            if (rocket != null)
            {
                // Optionally, apply damage or fuel loss here
                rocket.fuel -= rocket.obstacleCollisionFuelCost; // Deduct fuel on collision
                if (rocket.fuel < 0) rocket.fuel = 0;

                Debug.Log("Rocket collided with obstacle! Fuel remaining: " + rocket.fuel);
            }
        }
    }
}

