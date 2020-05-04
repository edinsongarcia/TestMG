using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MGapp.DataManager
{
    public class EmployeeManager
    {
        public string GetDataEmployees()
        {
			try
			{
                string data = "";
                string urlAddress = "http://masglobaltestapi.azurewebsites.net/api/Employees";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response =  (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();

                    return data;
                }
                else
                {
                    data = "Error";
                    return data;
                }
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
