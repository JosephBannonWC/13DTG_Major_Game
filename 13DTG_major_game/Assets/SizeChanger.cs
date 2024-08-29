using UnityEngine;
using UnityEngine.UI;

public class SizeChanger : MonoBehaviour
{
    // Reference to the Slider component used to change size
    public Slider sizeSlider;

    // Minimum size of the object
    public Vector3 minSize = new Vector3(1, 1, 1);

    // Maximum size of the object
    public Vector3 maxSize = new Vector3(3, 3, 3);

    // Called before the first frame update
    void Start()
    {
        // Add a listener to the slider's value change event
        sizeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Initialize the object's size based on the current slider value
        OnSliderValueChanged(sizeSlider.value);
    }

    // Called when the slider value changes
    void OnSliderValueChanged(float value)
    {
        // Interpolate between minSize and maxSize based on the slider value
        // value is expected to be between 0 and 1
        transform.localScale = Vector3.Lerp(minSize, maxSize, value);
    }
}
