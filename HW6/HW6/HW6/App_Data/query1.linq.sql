Query Kind="Expression">
  <Connection>
    <ID>ea5a082d-51a0-4de3-bf76-15f39c03de11</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Users\Scot Morse\Repositories\WOU\seniorproject_2017-18\mvc_examples\Northwind\Northwind\bin\Northwind.dll</CustomAssemblyPath>
    <CustomTypeName>Northwind.Models.NorthwindContext</CustomTypeName>
    <AppConfigPath>C:\Users\Scot Morse\Repositories\WOU\seniorproject_2017-18\mvc_examples\Northwind\Northwind\Web.config</AppConfigPath>
  </Connection>
</Query>

// Find a particular entity via it

Shippers.Find(2)

// Output a list of all entities
ProductCategory.ToList()