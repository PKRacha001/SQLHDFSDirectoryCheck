using System;
using System.Data.SqlTypes;
using System.IO;
using System.Net;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    /// Path is directory path. for e.g. /user
    public static SqlBoolean HDFSDirectoryExists(SqlString Path)
    {

        string uri = @"http://<hadoopHDPServer>.com:50070/webhdfs/v1" + Path.Value.ToString() + "?op=LISTSTATUS";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

        try
        {
           /* Creating a Http Web Response */
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string res = reader.ReadToEnd();
                /* Console.WriteLine("res = " + res); */
                /* If exception the path is not found */
                if (res.Contains("FileNotFoundException"))
                    return new SqlBoolean(0);
                /* Everthing goes well, we have the path */
                return new SqlBoolean(1);
            }
        }
        /* Exception is being thrown when the path isn't there in the HDFS */
        catch (Exception ex)
        {
            return new SqlBoolean(0);
        }
    }
}
