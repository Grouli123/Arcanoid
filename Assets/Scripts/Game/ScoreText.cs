using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private IntegerVariable _scoreCounter;
    private Text _scoreTextField;

    private void Start()
    { 
        _scoreTextField = GetComponent<Text>();
        _scoreCounter.Listeners += UpdateTextField;
        UpdateTextField(_scoreCounter.GetValue());
    }

    private void OnDestroy() 
    {
        _scoreCounter.Listeners -= UpdateTextField;
    }

    private void UpdateTextField(int value)
    {
        _scoreTextField.text = value.ToString();
    }
}
