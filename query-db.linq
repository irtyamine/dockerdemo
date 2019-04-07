<Query Kind="Statements">
  <Connection>
    <ID>1322f209-0d88-4ceb-9961-f0d9b9c4fc40</ID>
    <Server>127.0.0.1,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAq8Vq3QaH10iPycVm34DwVQAAAAACAAAAAAAQZgAAAAEAACAAAADKEx8VcN8Rf5/t2LfYDSXW8r4zJZb3ZtlRCMR0+kSyuwAAAAAOgAAAAAIAACAAAACh0Vi465PIZix6zDDgnbB99cjrVXYERhQAooFse8WFlSAAAADvUvqS/klS8MYxedW72IlXoGWc3p1qOCz9I74L9gIGQUAAAADEaNR7ZJDcZq5fvIruf/FqW44ovVZSAYyCA6mRVGq7Z5u11OgEsJ3Cu7BQCVlahfKAA82WFycms0adGAjbqFT0</Password>
    <Database>docker_stuff</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

Persons.InsertAllOnSubmit(new[] {
	new Person
	{
		FirstName = "Yaser",
		LastName = "Adel Mehraban"
	},
	new Person
	{
		FirstName = "Lars",
		LastName = "Klint"
	},
	new Person
	{
		FirstName = "Alex",
		LastName = "Mackey"
	}
});

SubmitChanges();

Persons.Dump();