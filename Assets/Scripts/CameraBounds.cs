using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public GameObject player;

    public GameObject rightBorder, leftBorder, topBorder, bottomBorder;
    float distanceToBorder = 13f;
    float vertBuffer = 8f;
    Vector2 maxPos; 
    Vector2 minPos;
    int zPos = -10;

    bool withinMaxX;
    bool withinMinX;
    bool withinMaxY;
    bool withinMinY;
    bool withinX;
    bool withinY;
    bool playerWithin;

    void Start()
    {
        CalculateBounds();
    }

    public void CalculateBounds()
    {
        maxPos = new Vector2(rightBorder.transform.position.x - distanceToBorder, topBorder.transform.position.y - distanceToBorder + vertBuffer);
        minPos = new Vector2(leftBorder.transform.position.x + distanceToBorder, bottomBorder.transform.position.y + distanceToBorder - vertBuffer);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
    }

    void Update() {
        checkBounds();
        if (playerWithin) {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
        } else {
            if (!withinX && withinY) {
                if (!withinMaxX) {
                    transform.position = new Vector3(maxPos.x, player.transform.position.y, zPos);
                } else {
                    transform.position = new Vector3(minPos.x, player.transform.position.y, zPos);
                }
            }

            if (withinX && !withinY) {
                if (!withinMaxY) {
                    transform.position = new Vector3(player.transform.position.x, maxPos.y, zPos);
                } else {
                    transform.position = new Vector3(player.transform.position.x, minPos.y, zPos);
                }
            }

            if (!withinX && !withinY) {
                if (!withinMaxX && !withinMaxY) {
                    transform.position = new Vector3(maxPos.x, maxPos.y, zPos);
                } else if (!withinMaxX && !withinMinY) {
                    transform.position = new Vector3(maxPos.x, minPos.y, zPos);
                } else if (!withinMinX && !withinMaxY) {
                    transform.position = new Vector3(minPos.x, maxPos.y, zPos);
                } else if (!withinMinX && !withinMinY) {
                    transform.position = new Vector3(minPos.x, minPos.y, zPos);
                }
            }
        }
    }   

    void checkBounds() {
        if (player.transform.position.x > maxPos.x) {
            withinMaxX = false;
        } else {
            withinMaxX = true;
        }

        if (player.transform.position.x < minPos.x) {
            withinMinX = false;
        } else {
            withinMinX = true;
        }

        if (player.transform.position.y > maxPos.y) {
            withinMaxY = false;
        } else {
            withinMaxY = true;
        }

        if (player.transform.position.y < minPos.y) {
            withinMinY = false;
        } else {
            withinMinY = true;
        }

        if (withinMaxX && withinMinX) {
            withinX = true;
        } else {
            withinX = false;
        }

        if (withinMaxY && withinMinY) {
            withinY = true;
        } else {
            withinY = false;
        }

        if (player.transform.position.x < maxPos.x && player.transform.position.x > minPos.x && 
        player.transform.position.y < maxPos.y && player.transform.position.y > minPos.y) {
            playerWithin = true;
        } else {
            playerWithin = false;
        }
    }
}
