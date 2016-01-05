# HDFS C# Connectivity

# Introduction
a hdfs connectivity for C# using http reauest

# Using Library
* add the reference of dll(main/CPA_Connectivity/bin/Debug/ClassLibrary2.dll) in your sln.	
* using CPA_Connectivity
* new a CPA_Connection object which has three method
	* constructor(string _host, string _user, string _port="14000")
	* bool upload(string inputFilePath, string outputFilePath): 
	 	inputFilePath is local file path. outputFilePath is the hdfs path. (it can include dir/file. please see example.)
	* string list_dir(): list the default test dir status
	* string remove_dir(): remove all file in the default test dir.
* you can check the sample code in hdfsCsharpConnectivity/example/hdfs_conn_example/Program.cs

