```
UPDATE Appointments SET TreatmentID = NULL;
UPDATE Appointments SET EmployeeID = NULL;
UPDATE Appointments SET CustomerID = NULL;

SELECT * FROM Appointments WHERE  EmployeeID != NULL;
```
