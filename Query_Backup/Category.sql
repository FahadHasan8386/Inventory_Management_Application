use IMS

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) NOT NULL 
        CONSTRAINT PK_Categories_CategoryId PRIMARY KEY (CategoryId),
    CategoryName NVARCHAR(100) NOT NULL,
    CategoryDescription NVARCHAR(255) NULL,
    InActive BIT NOT NULL 
        CONSTRAINT DF_Categories_InActive DEFAULT 0,
    CreatedBy NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL 
        CONSTRAINT DF_Categories_CreatedAt DEFAULT GETDATE(),
    ModifiedBy NVARCHAR(50) NULL,
    ModifiedAt DATETIME NULL
) 