CREATE TABLE PurchaseOrders (
    PurchaseOrderId BIGINT IDENTITY(100,1) NOT NULL 
        CONSTRAINT PK_PurchaseOrders_POId PRIMARY KEY (PurchaseOrderId),
    SupplierId INT NOT NULL,
    OrderDate DATE NOT NULL CONSTRAINT DF_PO_Date DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,3) NOT NULL CONSTRAINT CK_PO_Amount CHECK (TotalAmount >= 0),
    Remarks NVARCHAR(255) NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_PO_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT FK_PO_Suppliers FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
)