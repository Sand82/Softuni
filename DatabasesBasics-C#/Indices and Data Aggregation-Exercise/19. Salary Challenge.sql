SELECT TOP(10)
	   FirstName,
	   LastName,
	   DepartmentID
FROM Employees AS emp
WHERE Salary > (SELECT AVG(Salary)
				FROM Employees
				WHERE DepartmentID = emp.DepartmentID
				GROUP BY DepartmentID)
ORDER BY DepartmentID





