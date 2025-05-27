using UnityEngine;

public class DropZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            // Stop fuel consumption after the first sphere is dropped
            RocketMovementScript rocketScript = FindObjectOfType<RocketMovementScript>();
            rocketScript.SetFirstSphereDropped(true);

            // Continue with the drop logic
            GameManager.Instance.DropTetherAndSphere();
            Debug.Log(other.name + " dropped in the Drop Zone.");
        }
        else if (other.CompareTag("Sphere2") || other.CompareTag("Sphere3"))
        {
            GameManager.Instance.DropTetherAndSphere();
            Debug.Log(other.name + " dropped in the Drop Zone.");

            if (other.CompareTag("Sphere3"))
            {
                RocketMovementScript rocketScript = FindObjectOfType<RocketMovementScript>();
                rocketScript.ShowMissionComplete();  
            }
        }
    }
}
