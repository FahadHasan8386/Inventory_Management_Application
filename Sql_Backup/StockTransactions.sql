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

    CreatedBy NVARCHAR(50) NOT NULL,

    CONSTRAINT FK_ST_Products
        FOREIGN KEY (ProductId)
        REFERENCES Products(ProductId)
);
