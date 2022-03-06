using System;
using System.IO;
using System.Net;

namespace Downloader
{
    public abstract class HttpDownloader
    {
        public static bool SaveImage(string url, string SavePath, string SaveName = "")
        {
            if (SaveName == "") {
                SaveName = System.IO.Path.GetFileName(url);
            }
            bool Value = false;
            WebResponse response = null;
            Stream stream = null;
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if (!response.ContentType.ToLower().StartsWith("text/")) {
                    Value = SaveBinaryFile(response, SavePath + SaveName);
                }
            } catch (Exception err) {
                string aa = err.ToString();
            }
            return Value;
        }


        private static bool SaveBinaryFile(WebResponse response, string FileName)
        {
            bool Value = true;
            byte[] buffer = new byte[1024];
            try {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                Stream outStream = System.IO.File.Create(FileName);
                Stream inStream = response.GetResponseStream();
                int l;
                do {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                } while (l > 0);

                outStream.Close();
                inStream.Close();
            } catch {
                Value = false;
            }
            return Value;
        }
    }
}
