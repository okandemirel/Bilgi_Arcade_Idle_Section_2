using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {

        if (Input.anyKey)
        {
            EventManager.Instance.onInputDragged?.Invoke(InputValues);
        }
        else
        {
            EventManager.Instance.onInputReleased?.Invoke();
        }
    }
    private Vector2 InputValues => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
}
