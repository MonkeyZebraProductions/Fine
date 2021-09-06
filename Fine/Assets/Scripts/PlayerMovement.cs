using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10;

    private Controls inputs;
    private CharacterController characterController;
    private Vector2 move;
    private bool _canInteract;
    private Interactable _interactable;
    private float speed;


    private void Awake()
    {
        inputs = new Controls();

        inputs.Player.Interact.started += context => Interact();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = Speed / 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = inputs.Player.Move.ReadValue<Vector2>();
        characterController.Move(new Vector3(move.x, 0, move.y) * speed);
    }

    public void HaltMovement()
    {
        speed = 0;
    }

    public void ResumeMovement()
    {
        speed = Speed / 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==8)
        {
            _interactable = other.GetComponent<Interactable>(); ;
            _interactable.ButtonPrompt.SetActive(true);
            _canInteract = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            _interactable = other.GetComponent<Interactable>(); ;
            _interactable.ButtonPrompt.SetActive(false);
            _canInteract = false;
        }

    }

    public void Interact()
    {
        if(_canInteract)
        {
            _interactable.InteractAction.Invoke();
        }
    }
    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
