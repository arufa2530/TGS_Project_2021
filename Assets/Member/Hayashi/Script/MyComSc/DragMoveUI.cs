using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMoveUI : MonoBehaviour
{
    Vector3 mousePos;

    private void OnMouseDown()
    {
        // Object�̒��S���W�ƃ}�E�X�̍��W�Ƃ̍������v�Z�AMousePos�Ɋi�[
        Vector2 obj = RectTransformUtility.WorldToScreenPoint(Camera.main, this.GetComponent<RectTransform>().position);
        mousePos = new Vector3(obj.x - Input.mousePosition.x, obj.y - Input.mousePosition.y, 0f);;
    }

    private void OnMouseUp()
    {
        mousePos = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        //object�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //�}�E�X�̌��݈ʒu��pointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z) + mousePos;

        //pointScreen���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Object�̈ʒu���ApointWorld�ɂ���
        transform.position = pointWorld;
    }
}
