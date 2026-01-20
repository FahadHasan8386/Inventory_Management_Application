CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_Suppliers_SupplierId PRIMARY KEY (SupplierId),
    SupplierName NVARCHAR(150) NOT NULL,
    ContactPerson NVARCHAR(100) NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(MAX) NULL,
    InActive BIT NOT NULL CONSTRAINT DF_Suppliers_InActive DEFAULT 0,
    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_Suppliers_CreatedAt DEFAULT GETDATE()
)