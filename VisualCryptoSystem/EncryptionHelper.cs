using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net.Mime;
using System.Security.Cryptography;

namespace VisualCryptoSystem
{
    public static class EncryptionHelper
    {
        public static byte[] EncryptFile(string sInputFilename, string sOutputFilename, string sKey, out string sMsg)
        {
            bool IsSuccess = true;
            byte[] encrypted;
            FileStream fsInput = null;
            FileStream fsEncrypted = null;
            CryptoStream cryptostream = null;
            try
            {
                fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

                fsEncrypted = new FileStream(sOutputFilename,
                                                        FileMode.Create,
                                                        FileAccess.Write);
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                cryptostream = new CryptoStream(fsEncrypted,
                                                            desencrypt,
                                                            CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                fsInput.Close();
                fsEncrypted.Close();
                sMsg = "Encryption is done";

                //Get encrypted array of bytes
                encrypted = bytearrayinput.ToArray();
                return encrypted;
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
                IsSuccess = false;
            }
            finally
            {
                try
                {
                    if (cryptostream != null) cryptostream.Close();
                    if (fsInput != null) fsInput.Close();
                    if (fsEncrypted != null) fsEncrypted.Close();
                }
                catch
                {
                }
            }
            return new byte[3];
        }
        /// <summary>
        /// Decrypt files
        /// </summary>
        /// <param name="sInputFile">input file</param>
        /// <param name="sOutputFile">Decrypt file</param>
        /// <param name="sKey">Decrypt keys</param>
        /// <param name="sMsg">Decrypt result message</param>
        /// <returns>return true or false.</returns>
        public static bool DecryptFile(string sInputFilename, string sOutputFilename, string sKey, out string sMsg)
        {
            FileStream fsread = null;
            StreamWriter fsDecrypted = null;
            bool isSuccess = true;
            try
            {
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                //A 64 bit key and IV is required for this provider.
                //Set secret key For DES algorithm.
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                //Set initialization vector.
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                //Create a file stream to read the encrypted file back.
                fsread = new FileStream(sInputFilename,
                                               FileMode.Open,
                                               FileAccess.Read);
                //Create a DES decryptor from the DES instance.
                ICryptoTransform desdecrypt = DES.CreateDecryptor();
                //Create crypto stream set to read and do a
                //DES decryption transform on incoming bytes.
                CryptoStream cryptostreamDecr = new CryptoStream(fsread,
                                                             desdecrypt,
                                                             CryptoStreamMode.Read);
                //Print out the contents of the decrypted file.
                fsDecrypted = new StreamWriter(sOutputFilename);
                fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                fsDecrypted.Flush();
                fsDecrypted.Close();
                sMsg = "Decrypted is done";
            }
            catch (Exception ex)
            {
                sMsg = ex.Message;
                isSuccess = false;
            }
            finally
            {
                try
                {
                    if (fsread != null) fsread.Close();
                    if (fsDecrypted != null) fsDecrypted.Close();
                }
                catch
                {
                }
            }
            return isSuccess;
        }

        // Function to Generate a 64 bits Key.
        public static string GenerateKey()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            // Use the Automatically generated key for Encryption. 
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }
    }

}
