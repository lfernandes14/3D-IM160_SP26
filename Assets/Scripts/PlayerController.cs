using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private InputAction jump;
    private Vector3 playerMovement;
    [SerializeField] private float jumpValue;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private GameObject killBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");

        move.performed += MovePerformed;
        move.canceled += MoveCanceled;

        jump.performed += JumpPerformed;
    }

    private void JumpPerformed(InputAction.CallbackContext obj)
    {
        Jump();
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpValue, rb.linearVelocity.z);
    }

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }

    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = obj.ReadValue<Vector2>().x * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().y * playerSpeed;
        //playerSpeed here so as not to affect vertical movement
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(playerMovement.x, rb.linearVelocity.y, playerMovement.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyHeadTag"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }




    /// <summary>
    /// Deactivates/Removes the inputs
    /// </summary>
    private void OnDestroy()
    {
        move.performed -= MovePerformed;
        move.canceled -= MoveCanceled;
        jump.performed -= JumpPerformed;
    }
}
