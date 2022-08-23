
Reatial API:

Inside APP_DATA, there is a mdf file which has SALE transaction data.

for simplicity ,i havnt created Customer table, only using Customer ID, which has to be resolved relating it to cutomer table( future addition to do)

Design:

ASP.net Web API using dot net framework 4.6
using

> Entity framework 5.0 with Database first approach.
> Respository pattern used to loosely couple DAL and business layer.

> Controller has below 4 APIs defined with custom routing,

api/getSalesByCustomer/{customerId}

	get all the transaction by the customer

api/getrewards/{customerId}
	
	get the rewards calcuated for a particular customer ID( total rewards calcualted for all tranasaction)


api/getrewards/{customerId}

	get rewards calculated for each customer for all his/her transactions.( returns a dictionary)


api/getrewards/{customerId}

	Get the rewards calculated for all the transaction ( returns a dictionary with transaction number and rewards)


Instruction to run the code:
===========================

1. Clone the repository to your local. Using Visual Studio ( preferably VS 2019), open the solution bydouble clicking it.
2. Rebuild the solution,if require resotre the Nuget pacakges from Nuget pacakage manager.
3. Run the solution, to get the web API up and running in <https://localhost:44336/api/getrewards/201>
4. Refer the attached Output document for sample outputs. 
5. Implemented Swagger UI for documentation, after running the solution access the below URLfor swagger UI.
	https://localhost:44336/swagger/ui/index
