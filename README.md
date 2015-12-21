# hdfsCsharpConnectivity

# Introduction
a hdfs connectivity for C# using http reauest

# Using Library
	* add the reference of dll(main/CPA_Connectivity/bin/Debug/ClassLibrary2.dll) in your sln.	
	* using CPA_Connectivity
	* new a CPA_Connection object which has three method
		* constructor(string _host, string _user, string _port="14000")
		* bool upload(string inputFilePath, string outputFilePath): inputFilePath is local file path. outputFilePath is the hdfs path. (it can include dir/file. please see example.)
		* string list_dir(string dirPath): dirPath is the hdfs dir path. it will response the status of this dir.