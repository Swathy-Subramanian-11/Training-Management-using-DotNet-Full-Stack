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
