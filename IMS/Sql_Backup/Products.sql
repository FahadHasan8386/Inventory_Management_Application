CREATE TABLE Products (
    ProductId BIGINT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_Products_ProductId PRIMARY KEY,

    ProductName NVARCHAR(200) NOT NULL,

    CategoryId INT NOT NULL,

    UnitPrice DECIMAL(18,2) NOT NULL 
        CONSTRAINT DF_Products_UnitPrice DEFAULT 0,

    StockQuantity INT NOT NULL 
        CONSTRAINT DF_Products_Stock DEFAULT 0,

    InActive BIT NOT NULL 
        CONSTRAINT DF_Products_InActive DEFAULT 0,

    CreatedBy NVARCHAR(50) NOT NULL,

    CreatedAt DATETIME NOT NULL 
        CONSTRAINT DF_Products_CreatedAt DEFAULT GETDATE(),

    -- Foreign Key Reference
    CONSTRAINT FK_Products_Categories_CategoryId
        FOREIGN KEY (CategoryId)
        REFERENCES Categories(CategoryId)
);
