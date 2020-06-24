using System;
using System.Globalization;
using System.IO;

namespace DisposablePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Create stream reader object
            StreamReader streamReaderObject = default(StreamReader);

            try
            {
                // Assigns "streamReaderObject" to read from a text file named "file"
                streamReaderObject = new StreamReader("file.txt");

                // Reads all characters from the current position to the end of the stream.
                string fileContents = streamReaderObject.ReadToEnd();

                // Close StreamReader
                streamReaderObject.Close();

                Console.Write(fileContents);

                // Write amount of string elements to Console.
                Console.WriteLine($"\nThe file has {new StringInfo(fileContents).LengthInTextElements}");


            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File can not be found");
            }
            // Invoking the Dispose method in a finally block
            // Finally block will always execute
            finally
            {
                if(streamReaderObject != null)
                {
                    // Release all resources. Call the Dispose method
                    streamReaderObject.Dispose();
                }
            }

        }
    }
}
