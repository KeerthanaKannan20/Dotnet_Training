create database ADO_TEST

CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Department VARCHAR(50) NOT NULL,
    YearOfStudy INT NOT NULL
);

CREATE TABLE Courses (
    CourseId INT PRIMARY KEY IDENTITY,
    CourseName VARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    Semester VARCHAR(20) NOT NULL
);

CREATE TABLE Enrollments (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
    CourseId INT FOREIGN KEY REFERENCES Courses(CourseId),
    EnrollDate DATETIME NOT NULL,
    Grade VARCHAR(5) NULL
);


INSERT INTO Students (FullName, Email, Department, YearOfStudy)
VALUES 
('Keerthu', 'keerthu@gmail.com', 'IT', 2),
('Sanjay', 'sanjay@gmail.com', 'AIDS', 3),
('Hari', 'hari@gmail.com', 'IT', 1),
('Dharani', 'dharani@gmail.com', 'CS', 4),
('Umesh', 'umesh@gmail.com', 'CS', 2);

select * from Students

INSERT INTO Courses (CourseName, Credits, Semester)
VALUES 
('DSA', 3, '3'),
('JAVA', 3, '4'),
('C#', 4, '5'),
('PYTHON', 3, '1'),
('OS', 3, '7'),
('HTML', 3, '2');

select * from Courses

INSERT INTO Enrollments (StudentId, CourseId, EnrollDate, Grade)
VALUES
(1, 1, '2025-12-12', 'A'),
(1, 2, '2025-12-11', 'C'),
(2, 3, '2025-10-20', 'A'),
(3, 5, '2025-10-19', 'B'),
(4, 1, '2025-7-05', 'C'),
(5, 4, '2025-08-02', 'A');

select * from Enrollments


---

create procedure usp_getcoursesbysemester (@semester varchar(10))
as
begin
select courseid, coursename, credits, semester from courses
where semester = @semester;
end;

