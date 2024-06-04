using UnityEngine;
using Google.Maps;
using Google.Maps.Coord;

public class GoogleMapController : MonoBehaviour
{
    public GoogleMap googleMap;

    void Start()
    {
        // Khởi tạo bản đồ Google Maps
        googleMap.InitMap(new LatLng(37.7749, -122.4194), 16, MapId.Satellite);

        // Thêm một marker vào bản đồ
        googleMap.AddMarker(new LatLng(37.7749, -122.4194), "San Francisco");
    }
}
