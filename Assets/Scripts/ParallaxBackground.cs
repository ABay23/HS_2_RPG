using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    private float _xPossition;

    [SerializeField] private float _parallaxEffect;

    private void Update() 
    {
        cam = GameObject.Find("Main Camera");
        _xPossition = transform.position.x;
        
    }
}
