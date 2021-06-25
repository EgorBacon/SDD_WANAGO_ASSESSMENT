using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    public float jumpForce;
    public GameObject lazerObj;

    private bool movementPaused = false;
    private bool canvasEnabled = false;
    private Vector3 movementVector;
    private Rigidbody rb;
    private GameObject mainCamera;
	private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start() {
		spawnPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        mainCamera = transform.Find("Main Camera").gameObject;
        if (mainCamera == null)
            print("No object named 'Main Camera' was found as a child of the player");

		ActivatePlayer();
    }

    // Update is called once per frame
    void Update() {
        if (movementPaused)
            return;

        //Rotate to follow the mouse
        float xRotation = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float yRotation = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        transform.Rotate(0,xRotation,0);
        mainCamera.transform.Rotate(-yRotation, 0, 0);

        //Moving forward on input commands
        Vector3 forwardVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 sideVector = transform.right * Input.GetAxis("Horizontal");
        movementVector = new Vector3((forwardVector.x + sideVector.x) * moveSpeed, rb.velocity.y, (forwardVector.z + sideVector.z) * moveSpeed);


	}

    private void FixedUpdate() {
        rb.velocity = movementVector;
    }

	public void LaunchJump() {
		rb.AddForce(0, jumpForce, 0);
	}

	private void OnTriggerStay(Collider other) {
		if (other.transform.tag == "Hostile") {
			RespawnPlayer();
		}

        if (Input.GetKeyDown(KeyCode.E)) {
            if (other.transform.tag == "Keypad" && !canvasEnabled) {
                GameObject.Find("KeypadManager").GetComponent<KeypadManager>().turnOnCanvas();
                canvasEnabled = true;
				DeactivatePlayer();
            } else if (other.transform.tag == "Keypad" && canvasEnabled) {
                GameObject.Find("KeypadManager").GetComponent<KeypadManager>().turnOffCanvas();
                canvasEnabled = false;
				ActivatePlayer();
            }
        }
    }

    public void DeactivatePlayer() {
        movementPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ActivatePlayer() {
        movementPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

	public void RespawnPlayer() {
		transform.position = spawnPosition;
		rb.velocity = Vector3.zero;
	}
}
