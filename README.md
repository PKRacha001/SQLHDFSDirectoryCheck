# SQLHDFSDirectoryCheck
This code is to create an assembly function for SQL Server to verify if a directory exists in HDFS
Use case: We have some hadoop/Sqoop jobs import and process data in hadoop and when completed they create a _SUCCESS stamps as folder. From SQL Server to know the completion state of the Hadoop/Sqoop job, we verify the directory exists or not. This code will help that with this simple assembly function.

You can read more about Hadoop WebHDFS Rest API here: https://hadoop.apache.org/docs/r1.0.4/webhdfs.html

Follow the below steps to use this code:
1. Open the project with Visual Studio.
2. Replace <hadoopHDPServer> with your relevant Hadoop HDP service url
3. Now, build the project
4. Publish the project -> Select Target Database -> click Publish
	 (NOTE: For me, publish didn't work correctly. So, I have Generated Script and ran manually on the DB.)

After the successful above steps, you will see a scalar function in destination database named, HDFSDirectoryExists.
Usage: SELECT dbo.HDFSDirectoryExists('/user')

