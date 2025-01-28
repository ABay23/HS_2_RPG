using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    private float _xPosition;
    private float _lenght;
    private float _distanceMoved;
    private float _distanceToMove;

    [SerializeField] private float _parallaxEffect;

    private void Start() 
    {
        cam = GameObject.Find("Main Camera");
        _xPosition = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    private void Update() 
    {
        _distanceToMove = cam.transform.position.x * _parallaxEffect;
        _distanceMoved= cam.transform.position.x * (1 - _parallaxEffect);

        transform.position = new Vector3(_xPosition +_distanceToMove, transform.position.y);

        if (_distanceMoved > _xPosition + _lenght)
            _xPosition = _xPosition + _lenght;
        else if (_distanceMoved < _xPosition - _lenght)
            _xPosition = _xPosition - _lenght;
    }
}
