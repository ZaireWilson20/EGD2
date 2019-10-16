using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ExternalGameTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            }


    public void Activate(string filepath)
    {
        //int exitCode;
        //var processInfo = new ProcessStartInfo("cmd.exe", "Assets/Scripts/terraria_start.bat");
        //processInfo.CreateNoWindow = true;
        //processInfo.UseShellExecute = true;
        //Process process = Process.Start(processInfo);
        //exitCode = process.ExitCode;
        //process.Close();
        Process.Start("C:\\Users\\weisea3\\Desktop\\EGD\\Project2\\EGD2\\EGD Project 2\\Assets\\Scripts\\terraria_start.bat");
    }
}
