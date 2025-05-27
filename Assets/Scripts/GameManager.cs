using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject currentSphere;
    public GameObject tether;

    private bool isSphereAttached = false;

    public GameObject firstSphere;
    public bool isFirstSphereAttached = false;

    public GameObject secondSphere;  
    public bool isSecondSphereAttached = false;

    public GameObject thirdSphere;
    public bool isThirdSphereAttached = false;

    public bool CanAttachNextSphere()
    {
        return currentSphere == null;
    }

    void Awake()
    {
        Instance = this;
    }

    public bool IsSphereAttached()
    {
        return currentSphere != null;
    }

    public void AttachFirstSphere(GameObject sphere)
    {
        if (currentSphere == null && !isFirstSphereAttached)
        {
            firstSphere = sphere;
            isFirstSphereAttached = true;

            Rigidbody rb = firstSphere.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            AddFixedJointToSphere(firstSphere);
            currentSphere = firstSphere;
            FindObjectOfType<RocketMovementScript>().SetAttachedSphere(firstSphere);

            Debug.Log("First Sphere attached!");
        }
    }

    public void AttachSecondSphere(GameObject sphere)
    {
        if (currentSphere == null && !isSecondSphereAttached)
        {
            secondSphere = sphere;
            isSecondSphereAttached = true;

            Rigidbody rb = secondSphere.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            AddFixedJointToSphere(secondSphere);
            currentSphere = secondSphere;
            FindObjectOfType<RocketMovementScript>().SetAttachedSphere(secondSphere);

            Debug.Log("Second Sphere attached!");
        }
    }

    public void AttachThirdSphere(GameObject sphere)
    {
        if (currentSphere == null && !isThirdSphereAttached)
        {
            thirdSphere = sphere;
            isThirdSphereAttached = true;

            Rigidbody rb = thirdSphere.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            AddFixedJointToSphere(thirdSphere);
            currentSphere = thirdSphere;
            FindObjectOfType<RocketMovementScript>().SetAttachedSphere(thirdSphere);

            Debug.Log("Third Sphere attached!");
        }
    }

    public void DropTetherAndSphere()
    {
        if (currentSphere != null)
        {
            DropSphere(currentSphere);

            if (currentSphere == firstSphere)
                isFirstSphereAttached = false;
            else if (currentSphere == secondSphere)
                isSecondSphereAttached = false;
            else if (currentSphere == thirdSphere)
                isThirdSphereAttached = false;


            currentSphere = null;
            FindObjectOfType<RocketMovementScript>().ClearAttachedSphere();
            isSphereAttached = false;

            Debug.Log("Sphere dropped!");
        }
    }
   
    private void AddFixedJointToSphere(GameObject sphere)
    {
        FixedJoint fixedJoint = sphere.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = tether.GetComponent<Rigidbody>();  
    }

    private void DropSphere(GameObject sphere)
    {
        FixedJoint fixedJoint = sphere.GetComponent<FixedJoint>();
        if (fixedJoint != null)
        {
            Destroy(fixedJoint);
            Debug.Log("Sphere dropped!");
        }
    }

    

}
