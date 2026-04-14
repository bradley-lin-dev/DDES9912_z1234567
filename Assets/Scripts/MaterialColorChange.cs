using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialColorChange : MonoBehaviour
{
    [SerializeField]
    uint materialIndex = 1;

    [SerializeField]
    string materialPropertyName = "_EmissionColor";

    [SerializeField]
    ColorHDR[] materialColors;

    [SerializeField]
    AnimationCurve materialColorTransition;

    // Custom serialisable class for separated assignment of color and HDR intensity for Bloom and other effects.
    [System.Serializable]
    public class ColorHDR
    {
        // Base non-HDR color.
        [SerializeField]
        private Color baseColor;

        // HDR intensity. Is separate becuase color serialisation doesn't have intensity beyond 255.
        [SerializeField]
        private float intensity;

        // Property to mimic an HDR color field combining the features of the base color and intensity.
        public Color color
        {
            get
            {
                return baseColor * intensity;
            }
            set
            {
                intensity = new Vector3(baseColor.r, baseColor.g, baseColor.b).magnitude;
                baseColor = new Color(value.r / intensity, value.g / intensity, value.b / intensity, value.a);
            }
        }
    }

    Renderer m_mesh;
    float m_timer;

    float timerInBetween;
    int timerFloor;
    Vector3 colorTest;
    void Start()
    {
        m_mesh = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timerInBetween = m_timer % 1f;
        timerFloor = Mathf.FloorToInt(m_timer);
        Color colorResult = Color.Lerp(materialColors[timerFloor].color, materialColors[(timerFloor + 1) % materialColors.Length].color, materialColorTransition.Evaluate(timerInBetween));
        m_mesh.materials[materialIndex].SetColor(materialPropertyName, colorResult);
        colorTest = new Vector3(colorResult.r, colorResult.g, colorResult.b);
        m_timer += Time.deltaTime;
        m_timer %= materialColors.Length;
    }
}
