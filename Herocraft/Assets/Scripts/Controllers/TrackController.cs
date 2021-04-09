using UnityEngine;


public class TrackController
{
    private Track _track;
    private UI _ui;


    public TrackController(Track track, UI ui)
    {
        _track = track;
        _ui = ui;
    }

    public Vector3 GetPoint(float speed)
    {
        return _track.GetPurposePoint(speed);
    }

    public Transform GetStartPonit()
    {
        return _track.GetStartPoint();
    }
}