﻿
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Hotspot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject ThisPanorama;
    public GameObject TargetPanorama;

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0, 0.5f, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerExit(eventData);
        OnHotspotTransition();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
    }

    public void OnHotspotTransition()
    {
        SetSkyBox();
    }

    private void SetSkyBox()
    {
        if (TourManager.SetCameraPosition != null)
            TourManager.SetCameraPosition(TargetPanorama.transform.position, ThisPanorama.transform.position);
        TargetPanorama.gameObject.SetActive(true);
        ThisPanorama.gameObject.SetActive(false);
    }
}
