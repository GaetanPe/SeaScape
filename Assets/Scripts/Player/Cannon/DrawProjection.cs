using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    #region Attributes

    CannonController cannonController;
    LineRenderer lineRenderer;

    [Header("\t--- Drawing Render")]
    public int numPoints = 50;
    public float timeBetweenPoints = 0.1f;

    [Header("\t--- LayerMask")]
    public LayerMask collidableLayers;

    #endregion


    #region Start/Update

    void Start()
    {
        cannonController = GetComponent<CannonController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineDraw();
    }

    #endregion


    #region LineDrawing

    void lineDraw()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = cannonController.shotPoint.position;
        Vector3 startingVelocity = cannonController.shotPoint.up * cannonController.blastPower;

        // Associate the points to their Vector3 position on the line
        for(float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            // Creates the linepoint
            Vector3 newPoint = startingPosition + (t * startingVelocity);
            newPoint.y = startingPosition.y + (startingVelocity.y * t) + (Physics.gravity.y / 2f * (t * t));
            points.Add(newPoint);

            // Line Collider
            if(Physics.OverlapSphere(newPoint, 2, collidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        // Rendering
        lineRenderer.SetPositions(points.ToArray());
    }

    #endregion
}