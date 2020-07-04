using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eye : MonoBehaviour
{
    public InputField eye;

    public void OnEye()
    {
        eye.contentType = InputField.ContentType.Standard;
    }
}
