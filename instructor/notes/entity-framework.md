"Object/Relational Impedence Mismatch"


Customer
	+ OutstandingOrders
	+ OrderHistory


Hibernate - many years. 

NHibernate - 

"Entity Framework"
	- GREAT if you are creating your own database.
	- CAN you use entity framework on an existing databas?
		- Yes.
		- Rarely is it worth it.

	- IF you are working with an existing database (not one you control) consider using other tools.
		- Dapper https://www.learndapper.com/
