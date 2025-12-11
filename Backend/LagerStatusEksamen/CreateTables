CREATE TABLE PackageTypes (
	Name varchar(15) PRIMARY KEY not null,
	Description varchar(255) not null
);

CREATE TABLE Shelves (
	IsStocked bit not null,
	MAC varchar(17) primary key not null,
	PackageTypeName varchar(15) FOREIGN KEY REFERENCES PackageTypes(Name),
	ID int IDENTITY(1,1)
);
