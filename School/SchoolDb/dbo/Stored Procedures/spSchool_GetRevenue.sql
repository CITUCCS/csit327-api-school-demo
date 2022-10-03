CREATE PROC spSchool_GetRevenue
	@schoolId INT
AS 
BEGIN 

DECLARE @avgTution DECIMAL = (
	SELECT AverageTuition FROM School WHERE Id=@schoolId
);

DECLARE @count INT = (
	SELECT COUNT(*) FROM Student WHERE SchoolId = @schoolId
);

--IF @avgTution > 100
--	PRINT 'Shet kamahal'
--ELSE
--	PRINT 'Noys'

SELECT @avgTution * @count;
END