using UnityEngine;

public abstract class Interactable1 : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Hold,
        Minigame
    }

    float holdTime;

    public Transform cameraPos;

    public InteractionType interactionType;

    public abstract void changeCamera();
    public abstract string GetDescription();
    public abstract void Interact();

    public void IncreaseHoldTime() => holdTime += Time.deltaTime;
    public void ResetHoldTime() => holdTime = 0f;

    public float GetHoldTime() => holdTime;
}
