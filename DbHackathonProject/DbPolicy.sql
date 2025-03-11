CREATE DATABASE InsuranceDB

CREATE TABLE Policies (
    PolicyID INT PRIMARY KEY,
    PolicyHolderName NVARCHAR(100),
    PolicyType INT,
    StartDate DATETIME,
    EndDate DATETIME
)

select * from Policies