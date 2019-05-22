using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;

public class SpawnOnMap : MonoBehaviour
{
  private AbstractMap _map;

    [SerializeField] [Geocode] private string[] _locationStrings;

    public AbstractMap Map
    {
        get => _map;
        set => _map = value;
    }

    public string[] LocationStrings
    {
        get => _locationStrings;
        set => _locationStrings = value;
    }

    public GameObject MarkerPrefab
    {
        get => _markerPrefab;
        set => _markerPrefab = value;
    }

    Vector2d[] _locations;

    [SerializeField] float _spawnScale = 100f;

    [SerializeField] GameObject _markerPrefab;

    List<GameObject> _spawnedObjects;

    void Start()
    {
        _locations = new Vector2d[_locationStrings.Length];
        _spawnedObjects = new List<GameObject>();
        for (int i = 0; i < _locationStrings.Length; i++)
        {
            var locationString = _locationStrings[i];
            _locations[i] = Conversions.StringToLatLon(locationString);
            var instance = Instantiate(_markerPrefab);
            instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
            instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            _spawnedObjects.Add(instance);
        }
    }

    private void Update()
    {
        int count = _spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {
            var spawnedObject = _spawnedObjects[i];
            var location = _locations[i];
            spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
            spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        }
    }
}