using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEditor.ShaderData;

public class dangkytaikhoan : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_InputField thongbao;

    private IEnumerator DangKy()
    {
        WWWForm Form = new WWWForm();
        Form.AddField("user", username.text);
        Form.AddField("passwd", password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", Form);
        yield return www.SendWebRequest();
        if (!www.isDone)
        {
            thongbao.text = "Kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;
            switch (get)
            {
                case "exist": thongbao.text = " tài khoản đã tồn tại"; break;
                case "OK": thongbao.text = "Đăng kí thành công"; break;
                case "ERROR": thongbao.text = "Đăng kí không thành công"; break;
            }
        }
    }
}
