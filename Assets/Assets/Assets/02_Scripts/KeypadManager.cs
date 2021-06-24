using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour {
    public string solution;
    public Text textField;
    public CanvasGroup keypadCanvas;
	public GameObject doorObj;

    private string currentInput;
    private string inputOne, inputTwo, inputThree;
    private int order;

    // Start is called before the first frame update
    void Start() {
        ResetKeypad();
        UpdateTextField();
        turnOffCanvas();
    }

    public void turnOnCanvas() {
        keypadCanvas.blocksRaycasts = true;
        keypadCanvas.alpha = 1;
    }

    public void turnOffCanvas() {
        keypadCanvas.blocksRaycasts = false;
        keypadCanvas.alpha = 0;
    }

    public void ResetKeypad() {
        inputOne = "_";
        inputTwo = "_";
        inputThree = "_";
    }

    public void UpdateTextField() {
        currentInput = inputOne + inputTwo + inputThree;
        textField.text = inputOne + " " + inputTwo + " " + inputThree;
    }
    
    public void CheckAnswer() {
        //print("Checking solution: " + solution + " to " + currentInput);
        if (solution.Equals(currentInput)) {
			doorObj.GetComponent<Animator>().SetBool("Open", true);
        }
    }

    public void InsertCharacter(string input) {
        if (inputOne == "_") {
            inputOne = input;
            UpdateTextField();
        } else if (inputTwo == "_") {
            inputTwo = input;
            UpdateTextField();
        } else if (inputThree == "_") {
            inputThree = input;
            UpdateTextField();
            CheckAnswer();
        } else {
            ResetKeypad();
            InsertCharacter(input);
        }
    }
}
