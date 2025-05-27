using UnityEngine;

public class AttachTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // for the Sphere 1
        if (other.CompareTag("Sphere") && GameManager.Instance.CanAttachNextSphere())
        {
            GameManager.Instance.AttachFirstSphere(other.gameObject);
            Debug.Log("First Sphere picked up: " + other.name);
            other.GetComponent<Collider>().enabled = true;
        }
        // for the Sphere 2
        else if (other.CompareTag("Sphere2") && GameManager.Instance.CanAttachNextSphere())
        {
            GameManager.Instance.AttachSecondSphere(other.gameObject);
            Debug.Log("Second Sphere picked up: " + other.name);
            other.GetComponent<Collider>().enabled = true;
        }
        // for the Sphere 3
        else if (other.CompareTag("Sphere3") && GameManager.Instance.CanAttachNextSphere())
        {
            GameManager.Instance.AttachThirdSphere(other.gameObject);
            Debug.Log("Third Sphere picked up: " + other.name);
            other.GetComponent<Collider>().enabled = true;
        }
    }
}
