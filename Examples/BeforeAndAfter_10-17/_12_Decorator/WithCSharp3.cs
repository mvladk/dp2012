using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace _12_Decorator
{
    public class WithCSharp3
    {
        public static void Run()
        {
            /// polymorphic streams:
            MemoryStream memoryStream = new MemoryStream();
            NetworkStream networkStream = new NetworkStream(null);
            FileStream fileStream = new FileStream(@"C:\data.txt", FileMode.OpenOrCreate);
 
            /// decorators and strategies:
            BufferedStream bufferedStream = new BufferedStream(fileStream);
            CryptoStream cryptoStream = new CryptoStream(bufferedStream, new SHA1CryptoServiceProvider(), CryptoStreamMode.Write);

            /// writers and strategies
            BinaryWriter binaryWriter = new BinaryWriter(cryptoStream);
            binaryWriter.Write("hello world");  ///binary formatted, encrypted, write to file

            StreamWriter streamWriterASCII =
                new StreamWriter(fileStream, new ASCIIEncoding());
            streamWriterASCII.Write("hello world"); ///ascii text formatted, write to file

            StreamWriter streamWriterUnicode =
                new StreamWriter(fileStream, new UnicodeEncoding());
            streamWriterUnicode.Write("hello world"); ///unicode text formatted, write to file

            StreamWriter streamWriterWithCryptoUnicode =
                new StreamWriter(cryptoStream, new UnicodeEncoding());
            streamWriterWithCryptoUnicode.Write("hello world"); ///unicode text formatted, encrypted, write to file

            fileStream.Close();
        }
    }
}
