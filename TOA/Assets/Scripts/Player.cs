using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float maxMoveSpeed = 8f;
    public float horizontalSpeed = 4f;
    public int lifes = 1;
    private Rigidbody rb;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    public int currentLane;
    public bool isInGround = true;
    public float jumpForce = 100f;
    private bool infiniteLivesCheat;
    private bool isShieldActive;
    private float shieldDuration = 10f;
    private float currentShieldTime;
    public GameObject shieldGameObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(moveSpeed < maxMoveSpeed)
        {
            moveSpeed += 0.1f * Time.deltaTime;
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Began)
            {
                startTouchPos = firstTouch.position;
                endTouchPos = firstTouch.position;
            }
            if (firstTouch.phase == TouchPhase.Ended)
            {
                endTouchPos = firstTouch.position;
                float xDiff = Mathf.Abs(endTouchPos.x - startTouchPos.x);
                float yDiff = Mathf.Abs(endTouchPos.y - startTouchPos.y);
                if (xDiff > yDiff)
                {
                    if (startTouchPos.x > endTouchPos.x)
                    {
                        MoveLeft();
                    }
                    else if (startTouchPos.x < endTouchPos.x)
                    {
                        MoveRight();
                    }
                }
                else
                {
                    if (startTouchPos.y < endTouchPos.y && isInGround == true)
                    {
                        Jump();
                    }
                }
            }
        }

        if (Input.touchCount == 5)
        {
            StatusInfiniteLiveCheat();
        }

        if (isShieldActive && currentShieldTime > 0)
        {
            currentShieldTime -= Time.deltaTime;
            if (currentShieldTime <= 0)
            {
                DisableShield();
            }
        }
    }

    public void MoveLeft()
    {
        currentLane = Mathf.Max(currentLane - 1, 0);
        float x = GameController.controller.lanes[currentLane];
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveRight()
    {
        currentLane = Mathf.Min(currentLane + 1, GameController.controller.lanes.Length - 1);
        float x = GameController.controller.lanes[currentLane];
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void Jump()
    {
        if (isInGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isInGround = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Obstaculo"))
        {
            if (!infiniteLivesCheat && !isShieldActive)
            {
                Destroy(collider.gameObject);
                SceneChanger.instancia.PlayerDeathScene(1);
            }
            else
            {
                Destroy(collider.gameObject);
                if(isShieldActive)
                {
                    DisableShield();
                }
            }
        }
        else if (collider.CompareTag("Coin"))
        {
            GameController.controller.AddPoints(1);
            PointsController pointsController = FindObjectOfType<PointsController>();
            if (pointsController != null)
            {
                pointsController.AttPoints(GameController.controller.currentPoints);
            }
        }
        else if (collider.CompareTag("Shield"))
        {
            ActivateShield();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInGround = true;
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            SceneChanger.instancia.ChangeScene("TelaInicial");
        }
    }

    void EnableInfiniteLivesCheat()
    {
        lifes = 3;
        infiniteLivesCheat = true;
        Debug.Log("Cheat de Vidas Infinitas ativado!");
    }

    void DisableInfiniteLivesCheat()
    {
        lifes = 1;
        infiniteLivesCheat = false;
        Debug.Log("Cheat de Vidas Infinitas desativado!");
    }

    void StatusInfiniteLiveCheat()
    {
        if(infiniteLivesCheat)
        {
            DisableInfiniteLivesCheat();
        }
        else
        {
            EnableInfiniteLivesCheat();
        }
    }

    void ActivateShield()
    {
        isShieldActive = true;
        currentShieldTime = shieldDuration;
        shieldGameObject.SetActive(true);
    }

    void DisableShield()
    {
        isShieldActive = false;
        shieldGameObject.SetActive(false);
    }
}
