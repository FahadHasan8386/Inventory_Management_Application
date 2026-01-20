CREATE TABLE SalesOrders (
    SalesOrderId BIGINT IDENTITY(100,1) NOT NULL
        CONSTRAINT PK_SalesOrders_SOId PRIMARY KEY,

    CustomerId INT NOT NULL,

    OrderDate DATE NOT NULL 
        CONSTRAINT DF_SO_Date DEFAULT GETDATE(),

    TotalAmount DECIMAL(18,3) NOT NULL,

    InActive BIT NOT NULL 
        CONSTRAINT DF_SO_InActive DEFAULT 0,

    CreatedBy NVARCHAR(50) NOT NULL,

    CreatedAt DATETIME NOT NULL 
        CONSTRAINT DF_SO_CreatedAt DEFAULT GETDATE(),

    -- Foreign Key
    CONSTRAINT FK_SalesOrders_Customers_CustomerId
        FOREIGN KEY (CustomerId)
        REFERENCES Customers(CustomerId)
);
