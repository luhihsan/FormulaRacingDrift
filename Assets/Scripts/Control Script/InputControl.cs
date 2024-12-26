using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public bool isUIInput = false;

    Vector2 inputVector = Vector2.zero;

    // Components
    TopDownCarController topDownCarController;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
    }

    // Update is called once per frame and is frame dependent
    void Update()
    {
        if (!isUIInput)
        {
            inputVector = Vector2.zero;

            // Player 1 menggunakan mouse
            if (Input.GetMouseButton(0)) // Klik tombol gas
            {
                inputVector.y = 0.5f;
            }
            else if (Input.GetMouseButton(1)) // Klik tombol rem
            {
                inputVector.y = -0.5f;
            }

            // Player 1 menggunakan mouse untuk belok
            float turnInput = Input.GetAxis("Horizontal"); // Use the built-in "Horizontal" axis for A and D keys
            inputVector.x = turnInput;
        }

        // Send the input to the car controller.
        topDownCarController.SetInputVector(inputVector);
    }

    public void SetInput(Vector2 newInput)
    {
        inputVector = newInput;
    }
}
