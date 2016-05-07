using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;
namespace NewsReader
{
    class Helper
    {
        /// <summary>
        /// Mã hóa MD5 cho chuỗi string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string str)
        {
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            IBuffer hashBuffer = hashAlgorithm.HashData(buffer);

            return  CryptographicBuffer.EncodeToBase64String(hashBuffer);
            
        }
        /// <summary>
        /// Hàm ghi file 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<bool> writeFile(StorageFile file, string content)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(content);

                using(var wt = await file.OpenStreamForWriteAsync())
                {
                    await wt.WriteAsync(data, 0, data.Length);
                }
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return false;
        }
        /// <summary>
        /// read text from file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<string> readFile(StorageFile file)
        {
            try
            {
                using (var rt = await file.OpenStreamForReadAsync())
                {
                    using( var st = new StreamReader(rt))
                    {
                        return await st.ReadToEndAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return "";
        }
    }
}
