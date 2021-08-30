using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMoveUI : MonoBehaviour
{
    Vector3 MousePos;

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position);
        Vector2 mouse = RectTransformUtility.WorldToScreenPoint(Camera.main, this.GetComponent<RectTransform>().position);
        MousePos = new Vector3(mouse.x - Input.mousePosition.x, mouse.y - Input.mousePosition.y, 0f);
        Debug.Log(MousePos);
    }

    private void OnMouseUp()
    {
        MousePos = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        //Cube�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //Cube�̌��݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z) + MousePos;

        //Cube�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Cube�̈ʒu���ApointWorld�ɂ���
        transform.position = pointWorld;
    }
}
