
		** Step to Create Web Api Using Entity Framework-Code First Approach   **

1)First create web Application of web api--
---right click on project ->select Web Application(.Net Framework)->check/select web api ->Ok.
here we create web api application with MVC structure.

2)In controller folder two controller created mvc->home and web api->valuescontroller  
default is values controller of web api use ->Attribute Routing on methods
like -> 	[HttpGet]	->annotation for type of request
			[Route("values/getstudent")]	->Attribute Routing
  then give some hard code for testing purpose that web api is working fine or not.

3)then Run it if successfully run then you will find that result is shown in XML format by default.

for json format you need to go into -> WebApiConfig file to turn off xml format that is by default on  

then we have to write the below code snippet.

			var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
			
	then Run web api again you'll see that result in json format.
	
4)After that we go for Entity Framework code first approach !
 first of all we've to include 	Entity Framework from nuget manager solution.
click on ->tools ->we will get nuget manager ->then browse ->the entity framework ,install it.

then crate Model that you want with its properties(getter/setter) like id ,name etc In Model folder;
Now we've to create Context class for all Models.
then right click on project solution ->>Add item ->Data-> ADO .NET Entity data Model -->select and give class name (it is Context class
for that model class)->then select code ->Empty Code First Model ->finish ->created.


it will create the context class derived from DbContext Interface .

5)then give appropriate connectionString in Web.Config that is sql configuration .add name for connection 
which we use in DbContext constructor. 

and then we add model into DbContext which we will created
	public DbSet<Model_Name> name{get;set;} like that.


6)then go to controller to write db query using LINQ and save it using saveChanges method 
that will save your object into db or retrive data in object fromat and save it.return it to front end.

Note:- In Web api controller by default paramters is in primitive type like int,float,string
		if want to complex type like class type Student s so you've to use [FromUri] annotation.

[FromUri] and [FromBody]	:-
	
	You have seen that by default Web API gets the value of a primitive parameter from the query string and complex type parameter
	from the request body. But, what if we want to change this default behaviour?

	Use [FromUri] attribute to force Web API to get the value of complex type from the query string 
	and [FromBody] attribute to get the value of primitive type from the request body, opposite to the default rules.

