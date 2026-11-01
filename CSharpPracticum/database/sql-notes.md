## Tasks 03 - 10

### SQL
```sql
-- Задание 3. SELECT + WHERE

SELECT EmployeeName, Salary FROM Employees WHERE Salary > 50000;

SELECT EmployeeName, HireDate FROM Employees WHERE YEAR(HireDate) = 2023;

SELECT EmployeeName FROM Employees WHERE EmployeeName LIKE 'А%';

SELECT EmployeeName FROM Employees WHERE DepartmentId = 2;

SELECT EmployeeName, Salary FROM Employees WHERE Salary BETWEEN 40000 AND 60000;
 
 GO

 -- Задание 4. ORDER BY + TOP

SELECT TOP 3 EmployeeName, Salary FROM Employees ORDER BY Salary DESC;

SELECT TOP 5 EmployeeName, HireDate FROM Employees ORDER BY HireDate ASC;

SELECT DepartmentId, EmployeeName, Salary FROM Employees 
ORDER BY DepartmentId ASC, Salary DESC;

GO

-- Задание 5. Агрегация

SELECT 
    COUNT(*) AS TotalEmployees,
    SUM(Salary) AS TotalSalary,
    ROUND(AVG(Salary), 2) AS AvgSalary,
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary,
    COUNT(CASE WHEN Salary > 50000 THEN 1 END) AS RichEmployees
FROM Employees;

GO

-- Задание 6. GROUP BY

SELECT 
    DepartmentId, 
    COUNT(*) AS EmpCount, 
    AVG(Salary) AS AvgSalary, 
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AvgSalary DESC;

GO

-- Задание 7. GROUP BY + HAVING

SELECT DepartmentId, COUNT(*) FROM Employees GROUP BY DepartmentId HAVING COUNT(*) > 2;

SELECT DepartmentId, AVG(Salary) FROM Employees GROUP BY DepartmentId HAVING AVG(Salary) > 55000;

SELECT DepartmentId, SUM(Salary) FROM Employees GROUP BY DepartmentId HAVING SUM(Salary) > 150000;

GO

-- Задание 8. INNER JOIN

SELECT e.EmployeeName, d.DepartmentName, e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;

GO

-- Задание 9. LEFT JOIN (Сотрудники без проектов)

SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL;

GO

-- Задание 10. Множественный JOIN

SELECT 
    e.EmployeeName, 
    d.DepartmentName, 
    p.ProjectName, 
    ep.Hours
FROM Employees e
JOIN Departments d ON e.DepartmentId = d.DepartmentId
JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
JOIN Projects p ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName;

### Результат

-- Задание 3
EmployeeName	Salary
Анна Иванова	65000.00
Пётр Сидоров	72000.00
Мария Кузнецова	55000.00
Ольга Смирнова	61000.00
Дмитрий Орлов	58000.00
Елена Волкова	52000.00
Алексей Лебедев	90000.00

EmployeeName	HireDate
Иван Петров	2023-02-10
Елена Волкова	2023-06-01

EmployeeName
Анна Иванова
Алексей Лебедев

EmployeeName
Ольга Смирнова
Дмитрий Орлов
Елена Волкова

EmployeeName	Salary
Мария Кузнецова	55000.00
Иван Петров	48000.00
Дмитрий Орлов	58000.00
Елена Волкова	52000.00
Сергей Морозов	45000.00
Наталья Соколова	43000.00

-- Задание 4
EmployeeName	Salary
Алексей Лебедев	90000.00
Пётр Сидоров	72000.00
Анна Иванова	65000.00

EmployeeName	HireDate
Алексей Лебедев	2018-05-25
Пётр Сидоров	2019-07-01
Анна Иванова	2020-03-15
Ольга Смирнова	2020-09-05
Мария Кузнецова	2021-11-20

DepartmentId	EmployeeName	Salary
1	            Пётр Сидоров	72000.00
1	            Анна Иванова	65000.00
1	            Мария Кузнецова	55000.00
1	            Иван Петров	    48000.00
2	            Ольга Смирнова  61000.00
2	            Дмитрий Орлов	58000.00
2	            Елена Волкова   52000.00
3	            Сергей Морозов  45000.00

-- Задание 5
TotalEmployees	TotalSalary	AvgSalary	MinSalary	MaxSalary	RichEmployees
10	            589000.00	58900.000000 43000.00	90000.00	7

-- Задание 6
DepartmentId	EmpCount	AvgSalary	TotalSalary
4	            1	        90000.000000	90000.00
1	            4	        60000.000000	240000.00
2	            3	        57000.000000	171000.00
3	            2	        44000.000000	88000.00

-- Задание 7
DepartmentId	(Отсутствует имя столбца)
1	            4
2	            3

DepartmentId	(Отсутствует имя столбца)
1	            60000.000000
2	            57000.000000
4	            90000.000000

DepartmentId	(Отсутствует имя столбца)
1	            240000.00
2	            171000.00

-- Задание 8
EmployeeName	DepartmentName	Salary
Елена Волкова	Аналитика	    52000.00
Алексей Лебедев	Менеджмент	    90000.00
Пётр Сидоров	Разработка	    72000.00
Анна Иванова	Разработка	    65000.00
Мария Кузнецова	Разработка	    55000.00
Иван Петров	    Разработка	    48000.00
Сергей Морозов	Тестирование	45000.00
Наталья Соколова Тестирование	43000.00

-- Задание 9
EmployeeId	EmployeeName
9	        Наталья Соколова

-- Задание 10
EmployeeName	DepartmentName	ProjectName	Hours
Дмитрий Орлов	Аналитика	    AI Assistant	50
Дмитрий Орлов	Аналитика	    Data Warehouse	70
Елена Волкова	Аналитика	    Mobile App	    95
Ольга Смирнова	Аналитика	    Data Warehouse	110
Алексей Лебедев	Менеджмент	    AI Assistant	200
Алексей Лебедев	Менеджмент	    CRM System	    30
Анна Иванова	Разработка	    CRM System	    120
Анна Иванова	Разработка	    Data Warehouse	80
Иван Петров	    Разработка	    Legacy Refactor	40
Иван Петров	    Разработка	    Mobile App	    90
Мария Кузнецова	Разработка	    Mobile App	    100
Пётр Сидоров	Разработка	    AI Assistant	60
Пётр Сидоров	Разработка	    CRM System	    150
Сергей Морозов	Тестирование	Legacy Refactor	130