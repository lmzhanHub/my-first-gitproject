using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace test02
{
    class Program
    {
        /// <summary>
        /// 安全码
        /// </summary>
        private readonly static string safeCode = "jKEsed18";
        /// <summary>
        /// 账号
        /// </summary>
        private readonly static string account = "FSDDCS";
        static void Main(string[] args)
        {
            string sign = Get32Md5(account + "PEK" + 1 + 1 + 1 + 1 + "SHA" + safeCode);
           
            string postUrl = "http://wstest.51book.com:55779/ltips/services/getAvailableFlightWithPriceAndCommisionServiceRestful1.0/getAvailableFlightWithPriceAndCommision";
            post(postUrl, "agencyCode=" + account + "&airlineCode=MU&sign=" + sign + "&date=2016-04-28&dstAirportCode=PEK&onlyAvailableSeat=1&onlyNormalCommision=1&onlyOnWorkingCommision=1&onlySelfPNR=1&orgAirportCode=SHA");    
        }


        private static string post(string url, string Content)
        {
            byte[] data = Encoding.UTF8.GetBytes(Content);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //发送数据
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            //接收返回值
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            StreamReader sReader = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
            string strBack = sReader.ReadToEnd();
            //Response.Write(strBack);
            sReader.Close();
            res.Close();

            return strBack;
        }


        /// <summary>
        /// 获取32位长度的Md5摘要
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Get32Md5(string input, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            StringBuilder buff = new StringBuilder(32);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(encoding.GetBytes(input));
            foreach (byte t1 in t)
                buff.Append(t1.ToString("x").PadLeft(2, '0'));
            return buff.ToString();
        }
    }
}
