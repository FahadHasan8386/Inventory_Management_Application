CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_Customers_CustomerId PRIMARY KEY (CustomerId),
    CustomerName NVARCHAR(150) NOT NULL,
    ContactPerson NVARCHAR(100) NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(MAX) NULL,
    TotalCreditLimit DECIMAL(18,3) NOT NULL 
        CONSTRAINT DF_Customers_CreditLimit DEFAULT 0,
    InActive BIT NOT NULL 
        CONSTRAINT DF_Customers_InActive DEFAULT 0,
    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL 
        CONSTRAINT DF_Customers_CreatedAt DEFAULT GETDATE(),
    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME NULL
)