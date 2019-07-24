To run the test skill project follow the steps below
1. Restore the testdb.bak file into Sql server Express 
2. Edit the hostname of the connection string in Web.config file under BeepoExamProject folder on the "ClientContext"
 a. Change the "Data Source" value to the server name where you restore the testdb database
 b Change the "Initial Catalog" value to the databasename of the testdb restored

3. Change the hostname from the hostname where you run the BeepoExamProject 
	in "BeepoExam/app/WebApiHost.ts", change the value of "host" to the hostname of BeepoExamProject

4. If you use VS Studio run the BeepoExamProject Solution and run
5. Open the Beepo Exam with cmd and run npm  then run ng serve

The projects, the client app and server-side app were running separately.

