using System;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [HideInInspector]
    public string[] targetTags = {
        "MissedTarget",
        "OkTarget",
        "GoodTarget",
        "PerfectTarget",
    };

    private Collider2D currentTarget;
    private bool canBePressed = false;

    [SerializeField]
    private KeyCode keyToPress;

    private void Start() {

    }

    private void Update() {
        if (Input.anyKeyDown) {
            HandleKeyDown();
        }
    }

    private void HandleKeyDown() {
        if (!canBePressed) {
            return;
        }

        if (!Input.GetKeyDown(keyToPress)) {
            WrongKey();
            return;
        }

        DoTargetAction();
    }

    private void DoTargetAction() {
        currentTarget.GetComponent<ITarget>().Action();
        Destroy(this);
    }

    private void WrongKey() {
        FindObjectOfType<AudioManager>().Play("WrongKey");
        currentTarget.GetComponent<ITarget>().WrongKey();
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        string otherTag = other.gameObject.tag;

        if (IsValidTarget(otherTag)) {
            canBePressed = true;
            currentTarget = other;
            if (otherTag == "MissedTarget") {
                DoTargetAction();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        string otherTag = other.gameObject.tag;

        if (IsValidTarget(otherTag) && IsSameTarget(otherTag)) {
            canBePressed = false;
        }
    }

    private void OnDestroy() {
        Destroy(gameObject);
    }

    private bool IsValidTarget(string tag) {
        return Array.IndexOf(targetTags, tag) >= 0;
    }

    private bool IsSameTarget(string tag) {
        return tag == currentTarget.gameObject.tag;
    }
}
