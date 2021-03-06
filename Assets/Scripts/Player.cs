using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    public GameObject textLumber;
    public int force = 1;
    public Arvore arvore;


    private float speed = 7.5f;
    private float jumpSpeed = 8.0f;
    private float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public float life = 100f;
    public float maxLife = 100f;
    public GameObject textLoseScreen;
    public float damageRate = 10f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }

        if (arvore != null)
        {
            textLumber.SetActive(true);
        }
        else
        {
            textLumber.SetActive(false);
        }

        ChopTree();
        life = DeathRate(life);

    }

    private void ChopTree()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (arvore != null)
            {
                arvore.vida = arvore.vida - force;
                if (arvore.vida < 1)
                {
                    arvore.ArvDerrubada();
                }
            }
        }
    }

    private float DeathRate(float playerLife)
    {

        if (playerLife > 0)
        {
            playerLife = playerLife - damageRate * Time.deltaTime;
        }

        if (playerLife <= 0)
        {
            textLoseScreen.SetActive(true);

        }
        return playerLife;

    }
    public void UpdateDamageRate()
    {
        damageRate += 1;
    }
}