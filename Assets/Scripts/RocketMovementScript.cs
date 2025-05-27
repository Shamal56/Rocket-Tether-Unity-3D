using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketMovementScript : MonoBehaviour
{
    public float fuel = 100f;
    public float maxFuel = 100f;  
    public float gravity = -2f;  
    public float obstacleCollisionFuelCost = 10f;  

    private float baseFuelConsumption = 1f; 
    private float extraFuelMultiplier = 0.5f; 

    private GameObject currentAttachedSphere;

    public float thrustForce = 5f;  
    public float sidewaysThrustForce = 5f;  
    public float forwardBackwardThrustForce = 5f;

    private Rigidbody rb;
    private bool isThrustingUp = false;
    private bool isThrustingLeft = false;
    private bool isThrustingRight = false;
    private bool isThrustingForward = false;
    private bool isThrustingBackward = false;


    public GameObject gameOverPanel;
    public GameObject missionCompletePanel;
    public Button restartButton;
    public Button missionRestartButton;
    public Slider fuelBar;

    private bool firstSphereDropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        gameOverPanel.SetActive(false);
        missionCompletePanel.SetActive(false);
    }

    void Update()
    {
        HandleMovement();
        HandleThrust();
        HandleFuelConsumption();
        UpdateFuelUI();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))  
        {
            isThrustingUp = true;
        }
        else
        {
            isThrustingUp = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))  
        {
            isThrustingLeft = true;
        }
        else
        {
            isThrustingLeft = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))  
        {
            isThrustingRight = true;
        }
        else
        {
            isThrustingRight = false;
        }

        if (Input.GetKey(KeyCode.W)) 
        {
            isThrustingForward = true;
        }
        else
        {
            isThrustingForward = false;
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            isThrustingBackward = true;
        }
        else
        {
            isThrustingBackward = false;
        }
    }

    private void HandleThrust()
    {

        if (isThrustingUp && fuel > 0)
        {
            rb.AddForce(Vector3.up * thrustForce);
        }

        if (isThrustingLeft && fuel > 0)
        {
            rb.AddForce(Vector3.left * sidewaysThrustForce);
        }

        if (isThrustingRight && fuel > 0)
        {
            rb.AddForce(Vector3.right * sidewaysThrustForce);
        }

        if (isThrustingForward && fuel > 0)
        {
            rb.AddForce(Vector3.forward * forwardBackwardThrustForce);
        }

        if (isThrustingBackward && fuel > 0)
        {
            rb.AddForce(Vector3.back * forwardBackwardThrustForce);
        }
    }
    private void HandleFuelConsumption()
    {
        if (fuel <= 0)
        {
            fuel = 0;
            GameOver();
            return;
        }

        if (isThrustingUp || isThrustingLeft || isThrustingRight || isThrustingForward || isThrustingBackward)
        {
            float extraFuel = 0f;

            if (currentAttachedSphere != null)
            {
                float attachedMass = currentAttachedSphere.GetComponent<Rigidbody>().mass;
                extraFuel = attachedMass * extraFuelMultiplier;
            }

            fuel -= (baseFuelConsumption + extraFuel) * Time.deltaTime;
            fuel = Mathf.Max(0f, fuel);
        }
    }

    void UpdateFuelUI()
    {
        fuelBar.value = fuel;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowMissionComplete()
    {
        missionCompletePanel.SetActive(true);
        missionRestartButton.gameObject.SetActive(true);
        Debug.Log("Mission Completed!");
    }

    public void SetFirstSphereDropped(bool dropped)
    {
        firstSphereDropped = dropped;
    }

    public void SetAttachedSphere(GameObject sphere)
    {
        currentAttachedSphere = sphere;
    }

    public void ClearAttachedSphere()
    {
        currentAttachedSphere = null;
    }

}
