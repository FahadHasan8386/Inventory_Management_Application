CREATE TABLE StockTransactions (
    TransactionId BIGINT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_StockTransactions PRIMARY KEY,

    ProductId BIGINT NOT NULL,

    TransactionType NVARCHAR(20) NOT NULL
        CONSTRAINT CK_ST_TransactionType 
        CHECK (TransactionType IN ('IN', 'OUT')),

    Quantity INT NOT NULL
        CONSTRAINT CK_ST_Quantity CHECK (Quantity > 0),

    TransactionDate DATETIME NOT NULL
        CONSTRAINT DF_ST_Date DEFAULT GETDATE(),

    ReferenceType NVARCHAR(20) NULL, -- 'PO', 'SO'
    ReferenceId BIGINT NULL,

    -- BaseModel কলামগুলো এখানে যোগ করা হয়েছে
    InActive BIT NOT NULL 
        CONSTRAINT DF_ST_InActive DEFAULT 0,
    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL 
        CONSTRAINT DF_ST_CreatedAt DEFAULT GETDATE(),
    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME NULL,

    -- Foreign Key
    CONSTRAINT FK_ST_Products
        FOREIGN KEY (ProductId)
        REFERENCES Products(ProductId)
);