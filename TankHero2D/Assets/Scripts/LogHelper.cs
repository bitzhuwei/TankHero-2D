using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LogHelper : MonoBehaviour
{

    private static StreamWriter writer;
    private static string logFullname;
    private static readonly object synObj = new object();
    void Awake()
    {

    }

    private static void Initialize()
    {
        if (writer == null)
        {
            lock (synObj)
            {
                if (writer == null)
                {
                    string path = Application.dataPath;
                    if (Application.platform == RuntimePlatform.Android)
                    {
                        path = Application.persistentDataPath;
                    }

                    var logFilename = string.Format("{0}.log", System.DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    logFullname = Path.Combine(path, logFilename);
                    writer = new StreamWriter(logFullname, true);
                    Debug.Log(string.Format("log file {0} is ready.", logFullname));
                }
            }
        }
        
    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Log(object message)
    {
        if (writer == null)
        {
            Initialize();
            if (writer == null) { return; }
        }

        writer.WriteLine(message);
    }
    public static void Log(string format, params object[] args)
    {
        if (writer == null)
        {
            Initialize();
            if (writer == null) { return; }
        }

        writer.WriteLine(string.Format(format, args));
    }

    void OnDestroy()
    {
        if (writer != null)
        {
            lock (synObj)
            {
                if (writer != null)
                {
                    Dispose();
                    writer = null;
                }
            }
        }
    }

    private void Dispose()
    {
        writer.Flush();
        writer.Close();
        writer.Dispose();
        Debug.Log(string.Format("log file {0} is closed.", logFullname));
    }
}
