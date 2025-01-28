using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    private float _xPossition;
    private float _distanceMove;

    [SerializeField] private float _parallaxEffect;

    private void Start() 
    {
        cam = GameObject.Find("Main Camera");
        _xPossition = transform.position.x;
        
    }

    private void Update() 
    {
        _distanceMove = cam.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_xPossition +_distanceMove, transform.position.y);
    }
}
