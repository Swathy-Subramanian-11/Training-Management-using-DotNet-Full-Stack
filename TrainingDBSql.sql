-- Create the database
CREATE DATABASE EYTrainingsDB;

-- Use the newly created database
USE EYTrainingsDB;

-- Create the Employee table
CREATE TABLE Employee (
    EmpId INT PRIMARY KEY,
    EmpName VARCHAR(100) NOT NULL,
    Designation VARCHAR(50) NOT NULL,
    EmpPhone VARCHAR(15) NOT NULL,
    EmpEmail VARCHAR(100) NOT NULL UNIQUE
);

-- Create the Trainer table
CREATE TABLE Trainer (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(100) NOT NULL,
    TrainerType CHAR(1) CHECK(TrainerType IN('I','E')) NOT NULL,  -- I: Internal, E: External
    TrainerPhone VARCHAR(15) NOT NULL,
    TrainerEmail VARCHAR(100) NOT NULL UNIQUE
);

-- Create the Technology table
CREATE TABLE Technology (
    TechnologyId INT PRIMARY KEY,
    TechnologyName VARCHAR(100) NOT NULL,
    TechnologyType CHAR(1) CHECK(TechnologyType IN('B', 'I', 'A')) NOT NULL  -- B: Basic, I: Intermediate, A: Advanced
);

-- Create the Training table
CREATE TABLE Training (
    TrainingId INT PRIMARY KEY,
    TechnologyId INT NOT NULL,
    TrainerId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    FOREIGN KEY (TechnologyId) REFERENCES Technology(TechnologyId),
    FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId)
);

-- Create the Trainee table
CREATE TABLE Trainee (
    TrainingId INT NOT NULL,
    EmpId INT NOT NULL,
    Status CHAR(1) CHECK(Status IN('C', 'I')) NOT NULL,  -- C: Complete, I: Incomplete
    PRIMARY KEY (TrainingId, EmpId),
    FOREIGN KEY (TrainingId) REFERENCES Training(TrainingId),
    FOREIGN KEY (EmpId) REFERENCES Employee(EmpId)
);

-- Insert data into the Employee table
INSERT INTO Employee (EmpId, EmpName, Designation, EmpPhone, EmpEmail) VALUES
(1, 'Alan', 'Software Engineer', '1234567890', 'alan@company.com'),
(2, 'Janu', 'Data Scientist', '0987654321', 'janu@company.com'),
(3, 'Alice', 'Project Manager', '5551234567', 'alice@company.com');

-- Insert data into the Trainer table
INSERT INTO Trainer (TrainerId, TrainerName, TrainerType, TrainerPhone, TrainerEmail) VALUES
(1, 'Suresh', 'I', '4449876543', 'suresh@company.com'),
(2, 'Ramesh', 'E', '3336549871', 'ramesh@institute.com');

-- Insert data into the Technology table
INSERT INTO Technology (TechnologyId, TechnologyName, TechnologyType) VALUES
(1, 'Java', 'B'),
(2, 'Python', 'I'),
(3, 'Machine Learning', 'A');

-- Insert data into the Training table
INSERT INTO Training (TrainingId, TechnologyId, TrainerId, StartDate, EndDate) VALUES
(1, 1, 1, '2024-07-01', '2024-07-05'),
(2, 2, 2, '2024-07-10', '2024-07-15'),
(3, 3, 1, '2024-07-20', '2024-07-25');

-- Insert data into the Trainee table
INSERT INTO Trainee (TrainingId, EmpId, Status) VALUES
(1, 1, 'C'),
(1, 2, 'I'),
(2, 2, 'C'),
(2, 3, 'I'),
(3, 1, 'C'),
(3, 3, 'I');

--hiii heloo