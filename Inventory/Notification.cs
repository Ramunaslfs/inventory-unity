using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField]
    private Text textField; // Insert your text object inside unity inspector

    private void start()
    {
        textField.enabled = false;
    }

    public void showMessageToPlayer()
    {
        textField.enabled = true;
    }
}
