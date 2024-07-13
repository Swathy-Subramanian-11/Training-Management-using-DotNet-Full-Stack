
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